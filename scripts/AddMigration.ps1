. "$PSScriptRoot\Definitions.ps1"

$migrationName = $args[0]

dotnet ef migrations add $migrationName --project $MigrationProject --startup-project $StartupProject
