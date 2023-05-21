. "$PSScriptRoot\Definitions.ps1"

Set-Location $StartupProject
echo "npm install..."
npm install

$directory = "$StartupProject\wwwroot\lib"
echo "remove old modules from $directory ..."
if (Test-Path $directory) {
    Remove-Item "$directory\*" -Recurse
} else {
    New-Item -ItemType "directory" $directory
}

echo "move new modules..."
Move-Item -Path "$StartupProject\node_modules\*" -Destination $directory