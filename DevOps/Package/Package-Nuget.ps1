#
# Package_Nuget.ps1
#
Import-LocalizedData -BaseDirectory .\DevOps\en-GB -FileName Config.psd1 -BindingVariable ConfigData

$NuGet = $ConfigData.NuGet

& $NuGet pack .\GoodBearMongoLogger\GoodBearMongoLogger.nuspec