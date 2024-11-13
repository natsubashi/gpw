Add-Type -Path .\Npgsql.dll

$conn_str = "Server=localhost;Port=5432;User ID=postgres;Database=postgres";
$conn = New-Object Npgsql.NpgsqlConnection $conn_str;
$conn | Out-string
$conn.Open();
Write-Host "aj";
