. "$PSScriptRoot\Definitions.ps1"

dotnet ef migrations remove --force --project $MigrationProject --startup-project $StartupProject