. "$PSScriptRoot\Definitions.ps1"

Set-Location $StartupProject
echo "npm install..."
npm install

echo "remove old modules from wwwroot\lib..."
Remove-Item "$StartupProject\wwwroot\lib\*" -Recurse

echo "move new modules..."
Move-Item -Path "$StartupProject\node_modules\*" -Destination "$StartupProject\wwwroot\lib"