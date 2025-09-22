## Copyright (c) Down Syndrome Education Enterprises CIC. All Rights Reserved.
## Information contained herein is Proprietary and Confidential.

[CmdletBinding(PositionalBinding = $false)]
param (
  [string]$target = "test",
  [string]$configuration = "Debug",
  [string]$coverage = "false",
  [string]$coverage_output,
  [string]$coverage_output_format = "cobertura",
  [string[]]$target_frameworks = @("net9.0", "net10.0")
)

Set-StrictMode -version 2.0
$ErrorActionPreference = "Stop"

try {
  . (Join-Path $PSScriptRoot "utils.ps1")

  Write-Host
  Write-Host "------------------------------------------------------------------------------------------------------------------------" -ForegroundColor Green
  Write-Host "Running tests" -ForegroundColor Green
  Write-Host "------------------------------------------------------------------------------------------------------------------------" -ForegroundColor Green
  Write-Host "Target:                   $target"
  Write-Host "Configuration:            $configuration"
  Write-Host "Coverage:                 $coverage"
  Write-Host "Coverage output:          $coverage_output"
  Write-Host "Coverage output format:   $coverage_output_format"
  Write-Host "Target frameworks:        $($target_frameworks -join ', ')"
  Write-Host "------------------------------------------------------------------------------------------------------------------------" -ForegroundColor Green
  Write-Host

  if (-not (Test-Path $target)) {
    throw "Path does not exist: $target"
  }

  $exit_code = 0
  $item = Get-Item $target

  $failed_count = 0
  $failed_executions = @()

  if ($item -is [System.IO.DirectoryInfo]) {

    $tests = Get-ChildItem -Path $item -Recurse -Filter *Tests.csproj

    foreach ($test in $tests) {

      foreach ($tfm in $target_frameworks) {

        Write-Host
        Write-Host "------------------------------------------------------------------------------------------------------------------------" -ForegroundColor Green
        Write-Host "Running tests in $($test.FullName) (framework: $tfm)" -ForegroundColor Green
        Write-Host "------------------------------------------------------------------------------------------------------------------------" -ForegroundColor Green
        Write-Host

        $dotnet_args = @(
          "run",
          "--project", $test.FullName,
          "--configuration", $configuration,
          "--ignore-exit-code", "8"
        )

        if (-not [string]::IsNullOrWhiteSpace($tfm)) {
          $dotnet_args += @("--framework", $tfm)
        }

        if ($coverage -eq "true") {

          $dotnet_args += "--coverage"

          if (-not [string]::IsNullOrWhiteSpace($coverage_output)) {
            $dotnet_args += @("--coverage-output", $coverage_output)
          }

          if (-not [string]::IsNullOrWhiteSpace($coverage_output_format)) {
            $dotnet_args += @("--coverage-output-format", $coverage_output_format)
          }
        }

        Write-Host "dotnet $($dotnet_args -join ' ')"

        & dotnet @dotnet_args

        if ($LASTEXITCODE -ne 0) {
          Write-Host
          Write-Host "********************************************************************************" -ForegroundColor Red
          Write-Host "Test execution FAILED with exit code $LASTEXITCODE" -ForegroundColor Red
          Write-Host "Project: $($test.FullName)" -ForegroundColor Red
          Write-Host "Framework: $tfm" -ForegroundColor Red
          Write-Host "********************************************************************************" -ForegroundColor Red
          Write-Host
          $exit_code = $LASTEXITCODE
          $failed_count += 1
          $failed_executions += "$($test.FullName) [$tfm]"
        }
      }
    }
  }
  else {
    throw "Invalid path: $target"
  }

  if ($failed_count -ne 0) {
    Write-Host
    Write-Host
    Write-Host "========================================================================================================================" -ForegroundColor Red
    Write-Host "A total of $failed_count test executions failed" -ForegroundColor Red
    Write-Host "========================================================================================================================" -ForegroundColor Red
    Write-Host "Failing test projects:" -ForegroundColor Red
    foreach ($fe in $failed_executions) {
      Write-Host " - $fe" -ForegroundColor Red
    }
  }
  else {
    Write-Host
    Write-Host "------------------------------------------------------------------------------------------------------------------------" -ForegroundColor Green
    Write-Host "------------------------------------------------------------------------------------------------------------------------" -ForegroundColor Green
    Write-Host "All test executions passed" -ForegroundColor Green
    Write-Host "------------------------------------------------------------------------------------------------------------------------" -ForegroundColor Green
    Write-Host "------------------------------------------------------------------------------------------------------------------------" -ForegroundColor Green
    Write-Host
  }

  exit $exit_code
}
catch {
  Write-Host $_
  Write-Host $_.Exception
  exit 1
}
