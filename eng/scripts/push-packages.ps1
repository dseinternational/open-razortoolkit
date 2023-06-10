param (
    [string]$api_key
)

Set-StrictMode -version 2.0
$ErrorActionPreference = "Stop"

function Push-Packages() {

    . (Join-Path $PSScriptRoot "utils.ps1")

    Write-Host
    Write-Host "--------------------------------------------------------------------------------"
    Write-Host "Push-Packages"
    Write-Host "--------------------------------------------------------------------------------"
    Write-Host

    if (!$api_key) {
        throw "API key is required."
    }

    $packages = Get-ChildItem ./src/**/*.nupkg -Recurse;

    foreach ($pkg in $packages) {

        Write-Host "Packing $($pkg)"

        [int] $attempts = 0;
        [int] $max_attempts = 3;
        
        for ($i = 0; $i -lt $max_attempts; $i++) {
            
            try {
                Write-Host "Attempt $($i)"

                & dotnet nuget push $pkg.FullName --source "dseinternational" --api-key $($api_key) --skip-duplicate

                if ($LASTEXITCODE -ne 0) {
                    Write-Host    
                    Write-Host -ForegroundColor Red "Error executing 'dotnet nuget push'";
                    Write-Host
                    Exit $LASTEXITCODE;
                }
                
                break;
            }
            catch {
                if ($attempts -eq ($max_attempts - 1)) {
                    throw $_.Exception;
                }
                $attempts++;
                Write-Host "Error: waiting 5 seconds." -ForegroundColor Red
                Start-Sleep -Seconds 5;
            }
        }
    }
}

try {
    Push-Packages
}
catch {
    Write-Host $_
    Write-Host $_.Exception
    exit 1
}
