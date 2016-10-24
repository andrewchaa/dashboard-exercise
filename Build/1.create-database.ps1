[reflection.assembly]::LoadWithPartialName("Microsoft.SqlServer.Smo")

$server = new-object ("Microsoft.SqlServer.Management.Smo.Server") .

$dbExists = $FALSE
foreach ($db in $server.databases) {
  if ($db.name -eq "Dashboard") {
    Write-Host "Dashboard already exists."
    $dbExists = $TRUE
  }
}

if ($dbExists -eq $FALSE) {
  $db = New-Object -TypeName Microsoft.SqlServer.Management.Smo.Database -argumentlist $server, "Dashboard"
  $db.Create()

}
