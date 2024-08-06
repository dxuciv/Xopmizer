Write-Host "Desinstalando aplicaciones predeterminadas de Microsoft..."
Set-ExecutionPolicy Unrestricted
Get-AppxProvisionedPackage -online | where-object {$_.packagename -notlike "*Microsoft.WindowsStore*"} | where-object {$_.packagename -notlike "*Microsoft.WindowsCalculator*"} | where-object {$_.packagename -notlike "*Microsoft.Windows.Photos*"} |Remove-AppxProvisionedPackage -online