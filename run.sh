#!/bin/bash

# SbcAI Backend & Extension Launcher
echo "🚀 SbcAI Backend ve Extension başlatılıyor..."
echo ""

# Get the root directory
ROOT_DIR="$(dirname "$0")"

# Step 1: Start Backend Server in background
echo "🔧 Step 1: Backend Server başlatılıyor..."
cd "$ROOT_DIR/SbcAIBackend" || exit
dotnet run &
BACKEND_PID=$!
echo "✅ Backend Server PID: $BACKEND_PID"
echo ""

# Wait for backend to be ready
sleep 3
echo ""

# Step 2: Build Extension
echo "🔨 Step 2: Extension Build başlatılıyor..."
cd "$ROOT_DIR/SbcAIExtension" || exit
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
npm run dev &
EXTENSION_PID=$!
echo "✅ Extension Dev Server PID: $EXTENSION_PID"
echo ""

# Wait for extension to be ready
sleep 2
echo ""

# Step 4: Start SbcAI UI Web Server in foreground
echo "🌐 Step 4: SbcAI UI Web Server başlatılıyor..."
cd "$ROOT_DIR/SbcAIUI" || exit
npm run dev

# Cleanup: Kill all processes when UI stops
kill $BACKEND_PID 2>/dev/null
kill $EXTENSION_PID 2>/dev/null
echo ""
echo "⏹️  Tüm sistemler kapatıldı"

