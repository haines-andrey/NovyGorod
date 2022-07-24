. "$PSScriptRoot\Definitions.ps1"

dotnet ef database update --project $MigrationProject --startup-project $StartupProject
