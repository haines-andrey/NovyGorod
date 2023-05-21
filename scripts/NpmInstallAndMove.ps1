﻿. "$PSScriptRoot\Definitions.ps1"

Set-Location $StartupProject
echo "npm install..."
npm install

echo "remove old modules from wwwroot\lib..."
$directory = "$StartupProject\wwwroot\lib"
if (Test-Path $directory) {
    Remove-Item "$directory\*" -Recurse
} else {
    New-Item -ItemType "directory" $directory
}

echo "move new modules..."
Move-Item -Path "$StartupProject\node_modules\*" -Destination $directory