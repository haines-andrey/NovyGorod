. "$PSScriptRoot\Definitions.ps1"
. "$PSScriptRoot\UserSecrets.ps1"

dotnet user-secrets init --project $StartupProject

foreach ($key in $userSecrets.Keys)
{
    dotnet user-secrets set $key $userSecrets[$key] --project $StartupProject
}
