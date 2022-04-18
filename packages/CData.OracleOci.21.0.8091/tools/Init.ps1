param($installPath, $toolsPath, $package, $project)
[System.Reflection.Assembly]::LoadFile("$($installPath)\lib\net35\System.Data.CData.OracleOci.dll")
[System.Data.CData.OracleOci.Nuget]::CheckNugetLicense("nuget")