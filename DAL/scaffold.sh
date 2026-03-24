#!/usr/bin/env bash
set -euo pipefail

# Always run from GelinApp.DAL directory
SCRIPT_DIR="$(cd "$(dirname "${BASH_SOURCE[0]}")" && pwd)"
cd "$SCRIPT_DIR"

# Full scaffold for all entities into Models/db
SCAFFOLD_ARGS=(
  --use-database-names
  --no-pluralize
  -o Models/Entity
  -f
  --no-build
  -c _DbContext
)

dotnet ef dbcontext scaffold "Server=94.73.146.3;Database=u2211892_sbcmons;User Id=u2211892_sbcmons;Password=z:S5-5_SF_iRig85;TrustServerCertificate=True;" Microsoft.EntityFrameworkCore.SqlServer "${SCAFFOLD_ARGS[@]}"

echo "✅ Scaffold completed: Models/Entity updated."