. "$PSScriptRoot\Definitions.ps1"
. "$PSScriptRoot\UserSecrets.ps1"

dotnet user-secrets init --project $StartupProject
dotnet user-secrets init --project $DbSeederProject

foreach ($key in $userSecrets.Keys)
{
    dotnet user-secrets set $key $userSecrets[$key] --project $StartupProject
    dotnet user-secrets set $key $userSecrets[$key] --project $DbSeederProject
}
