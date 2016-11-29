#
# Package_Nuget.ps1
#
Import-LocalizedData -BaseDirectory .\DevOps\en-GB -FileName Config.psd1 -BindingVariable ConfigData

$NuGet = $ConfigData.NuGet

& $NuGet pack .\GoodBearMongoLogger\GoodBearMongoLogger.nuspec  -properties Configuration=Release

& $NuGet pack .\GoodBearMongoLogger.Autofac\GoodBearMongoLogger.Autofac.nuspec  -properties Configuration=Release