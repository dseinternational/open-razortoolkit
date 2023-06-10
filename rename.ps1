
$files = Get-ChildItem -File -Recurse

foreach ($i in $files) {
    if ($i.Name.StartsWith("RazorToolkit.")) {
        Write-Host $i.FullName
        Rename-Item -Path $i -NewName $i.FullName.Replace("\RazorToolkit.","\DSE.Open.RazorToolkit.")
    }
}