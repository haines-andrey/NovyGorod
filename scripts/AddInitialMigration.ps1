. "$PSScriptRoot\Definitions.ps1"

dotnet ef migrations add Initial --project $EfProject --startup-project $StartupProject