content='public string PluginVersion => "1.18.0";'
new_content=$(echo "$content" | perl -pe 's/(public string PluginVersion => ")(\d+\.\d+\.)(\d+)(";\s*)/$1 . $2 . ($3 + 1) . $4/e')
echo "$new_content"
