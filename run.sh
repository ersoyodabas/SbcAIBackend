#!/bin/bash

# SbcAI Backend & Extension Launcher
echo "🚀 SbcAI Backend ve Extension başlatılıyor..."
echo ""

# Cleanup function: kill all tracked child processes and their descendants
cleanup() {
    echo ""
    echo "⏹️  Kapatılıyor..."
    for pid in "${CHILD_PIDS[@]}"; do
        if [ -n "$pid" ]; then
            # Kill the entire process group rooted at $pid
            kill -- -"$pid" 2>/dev/null || kill "$pid" 2>/dev/null
        fi
    done
    echo "⏹️  Tüm sistemler kapatıldı"
    exit 0
}

start_in_new_session() {
    if command -v setsid >/dev/null 2>&1; then
        setsid "$@" &
    elif command -v perl >/dev/null 2>&1; then
        perl -e 'use POSIX qw(setsid); setsid() or die "setsid failed: $!"; exec @ARGV or die "exec failed: $!";' "$@" &
    else
        "$@" &
    fi
}

CHILD_PIDS=()
trap cleanup SIGINT SIGTERM EXIT

# Get the root directory
ROOT_DIR="$(dirname "$0")"
WORKSPACE_DIR="$(cd "$ROOT_DIR/.." && pwd)"

# Step 1: Start Backend Server in background
echo "🔧 Step 1: Backend Server başlatılıyor..."
cd "$WORKSPACE_DIR/Backend/API" || exit
start_in_new_session dotnet run
BACKEND_PID=$!
CHILD_PIDS+=("$BACKEND_PID")
echo "✅ Backend Server PID: $BACKEND_PID"
echo ""

# Wait for backend to be ready
sleep 3
echo ""

# Step 2: Build Extension
echo "🔨 Step 2: Extension Build başlatılıyor..."
cd "$WORKSPACE_DIR/Extension" || exit

if [ ! -x "node_modules/.bin/vite" ]; then
    echo "📥 Extension bağımlılıkları yükleniyor..."
    npm install
    if [ $? -ne 0 ]; then
        echo "❌ Extension bağımlılıkları yüklenemedi!"
        kill $BACKEND_PID 2>/dev/null
        exit 1
    fi
fi

npm run build
if [ $? -ne 0 ]; then
    echo "❌ Extension build başarısız oldu!"
    kill $BACKEND_PID 2>/dev/null
    exit 1
fi
echo "✅ Extension Build tamamlandı"
echo ""

# Step 3: Start Extension Dev Server in background
echo "📦 Step 3: Extension Dev Server başlatılıyor..."
start_in_new_session npm run dev
EXTENSION_PID=$!
CHILD_PIDS+=("$EXTENSION_PID")
echo "✅ Extension Dev Server PID: $EXTENSION_PID"
echo ""

# Wait for extension to be ready
sleep 2
echo ""

# Step 4: Start SbcAI UI Web Server in foreground
echo "🌐 Step 4: SbcAI UI Web Server başlatılıyor..."
cd "$WORKSPACE_DIR/UI" || exit

if [ ! -d "node_modules" ]; then
    echo "📥 UI bağımlılıkları yükleniyor..."
    npm install
    if [ $? -ne 0 ]; then
        echo "❌ UI bağımlılıkları yüklenemedi!"
        kill $BACKEND_PID 2>/dev/null
        kill $EXTENSION_PID 2>/dev/null
        exit 1
    fi
fi

if [ -f "node_modules/.bin/vite" ] && [ ! -x "node_modules/.bin/vite" ]; then
    chmod +x node_modules/.bin/vite
fi

if [ ! -d "node_modules/@rollup/rollup-darwin-arm64" ] && [ "$(uname -s)" = "Darwin" ] && [ "$(uname -m)" = "arm64" ]; then
    echo "🛠️  Eksik Rollup macOS ARM bağımlılığı onarılıyor..."
    npm install
    if [ $? -ne 0 ]; then
        echo "❌ UI Rollup bağımlılığı onarılamadı!"
        kill $BACKEND_PID 2>/dev/null
        kill $EXTENSION_PID 2>/dev/null
        exit 1
    fi
fi

# UI foreground — when it exits (or Ctrl+C), trap handles cleanup
npm run dev

