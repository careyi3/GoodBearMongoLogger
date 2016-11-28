#
# Build.ps1
#
Import-LocalizedData -BaseDirectory .\DevOps\en-GB -FileName Config.psd1 -BindingVariable ConfigData

$MSBuild = $ConfigData.MSBuild
$NuGet = $ConfigData.NuGet

& $NuGet restore $ConfigData.Solution

& $MSBuild $ConfigData.Solution /target:Clean /target:Build