Set-StrictMode -Version 2.0

Add-Type -Path .\moduleAutom.cs `
-OutputAssembly moduleAutom.exe `
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
Write-Host "successwrapper"

#.\moduleAutom.exe
