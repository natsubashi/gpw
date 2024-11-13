Set-StrictMode -Version 2.0

Add-Type .\Main.cs, .\form1.cs `
-OutputAssembly gpw.exe `
-ReferencedAssemblies `
System.Windows.Forms,`
System.Drawing,`
System.Threading.Tasks,`
System.ComponentModel,`
System.Data,`
".\Npgsql.dll",`
".\Mono.Security.dll" <#`
-OutputType WindowsApplication#>
Write-Host "success"

.\gpw.exe

