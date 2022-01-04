$data = @("Daniel Osterbro", "Karla West", "Simon Mania", "Barry West", "Carry Angie", "Anna Tiara", "Tina Miarage", "Amin Simonsen", "Wallace Janit", "Silvia Jensen", "Tobias Olafsen", "Valentina Fernandez", "Maria Fernandez", "Fernando Diaz", "Lorren Tamal")

foreach($item in $data)
{
  $JSON = @"
  {
    "id": 0,
    "firstName": `"$($item.Split(" ")[0])`",
    "lastName": "$($item.Split(" ")[1])",
    "age": $(Get-Random -Minimum 18 -Maximum 50)
  }
"@
Write-Host $JSON
$response = Invoke-RestMethod -Uri "https://localhost:54918/api/Customer" -Method Post -Body $JSON -ContentType "application/json"
Write-Host $response
}