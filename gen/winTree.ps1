Set-StrictMode -Version 2.0

Add-Type -Path .\wintree.cs `
-OutputAssembly wintree.exe `
-ReferencedAssemblies `
System.Windows.Forms,`
System.Drawing,`
System.Threading.Tasks,`
System.ComponentModel,`
System.Data,`
System.Collections,`
System.Runtime.InteropServices,`
System.IO,`
SYstem.Threading,`
UIAutomationTypes,`
UIAutomationClient,`
WindowsBase
<#`
-OutputType WindowsApplication#>
Write-Host "success"

.\wintree.exe
