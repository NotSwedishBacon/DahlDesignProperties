$content = 'public string PluginVersion => "1.18.0";'
if ($content -match 'public string PluginVersion => "(?<major>\d+)\.(?<minor>\d+)\.(?<patch>\d+)";') {
    $major = $matches.major
    $minor = $matches.minor
    $patch = [int]$matches.patch + 1
    $newVersion = "$major.$minor.$patch"
    $content = $content -replace 'public string PluginVersion => "[^"]+";', "public string PluginVersion => `"$newVersion`";"
    Write-Host $content
}
