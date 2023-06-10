Set-StrictMode -version 2.0
$ErrorActionPreference = "Stop"

[string]$repoPath = Resolve-Path (Join-Path $PSScriptRoot "../..")
[string]$srcPath = Resolve-Path (Join-Path $repoPath "src")
[string]$testPath = Resolve-Path (Join-Path $repoPath "test")
[bool]$runningOnBuildAgent = 0;

if ($env:GITHUB_ACTIONS) {
    $runningOnBuildAgent = 1;
}

$tempDir = Join-Path $repoPath "_temp";

$agentTempDirectory = $env:AGENT_TEMPDIRECTORY;

if ($agentTempDirectory) {
    $tempDir = $agentTempDirectory;
}

$buildSourceBranch = $env:BUILD_SOURCEBRANCH

function Exec([scriptblock]$cmd, [string]$errorMessage = "Error executing command: " + $cmd) { 
    & $cmd

    if ((-not $?) -or ($lastexitcode -ne 0)) {
        throw $errorMessage 
    }
}


function Write-BuildProperties() {
    Write-Host
    Write-Host "--------------------------------------------------------------------------------"
    Write-Host "BUILD PROPERTIES"
    Write-Host "--------------------------------------------------------------------------------"
    Write-Host "Workflow    : $($env:GITHUB_WORKFLOW)"
    Write-Host "Action      : $($env:GITHUB_ACTION)"
    Write-Host "Actor       : $($env:GITHUB_ACTOR)"
    Write-Host "--------------------------------------------------------------------------------"
}
