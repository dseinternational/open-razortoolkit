## Copyright (c) Down Syndrome Education International and Contributors. All Rights Reserved.
## Down Syndrome Education International and Contributors licence this file to you under the MIT license.

# Assumes nbgv tool is installed and on path (https://github.com/dotnet/Nerdbank.GitVersioning/blob/main/doc/nbgv-cli.md)

[CmdletBinding(PositionalBinding = $false)]
param (
    [bool]$publicRelease = $false
)

Set-StrictMode -version 2.0
$ErrorActionPreference = "Stop"

function Set-Version() {

    . (Join-Path $PSScriptRoot "utils.ps1")

    Write-Host
    Write-Host "Setting version..."
    Write-Host

    $version = nbgv get-version --format json | Out-String | ConvertFrom-Json;

    $properties =
    "<!-- Autogenerated during build -->`n" + `
        "<Project>`n" + `
        "  <PropertyGroup>`n" + `
        "    <Version>$($version.Version)</Version>`n" + `
        "    <AssemblyVersion>$($version.AssemblyVersion)</AssemblyVersion>`n" + `
        "    <FileVersion>$($version.AssemblyFileVersion)</FileVersion>`n" + `
        "    <InformationalVersion>$($version.AssemblyInformationalVersion)</InformationalVersion>`n" + `
        "    <PackageVersion>$($version.NuGetPackageVersion)</PackageVersion>`n" + `
        "  </PropertyGroup>`n" + `
        "</Project>`n"

    Write-Host "version.props:`n"
    Write-Host $properties `n`n
    $properties | Out-File "./version.props" -Encoding utf8NoBOM

    if ($on_agent) {
        $version | ConvertTo-Json -Depth 8 | Out-File "./version-latest.json" -Encoding utf8NoBOM
    }

    Write-Host
    Write-Host "Version set"
    Write-Host
}

try {
    Set-Version
}
catch {
    Write-Host $_
    Write-Host $_.Exception
    exit 1
}
