$collectionWithItems = New-Object System.Collections.ArrayList
$customer1 = New-Object System.Object
$customer1 | Add-Member -MemberType NoteProperty -Name "id" -Value "0"
$customer1 | Add-Member -MemberType NoteProperty -Name "firstName" -Value "Daniel"
$customer1 | Add-Member -MemberType NoteProperty -Name "lastName" -Value "Osterbro"
$customer1 | Add-Member -MemberType NoteProperty -Name "age" -Value "32"
$collectionWithItems.Add($customer1) | Out-Null

$customer2 = New-Object System.Object
$customer2 | Add-Member -MemberType NoteProperty -Name "id" -Value "0"
$customer2 | Add-Member -MemberType NoteProperty -Name "firstName" -Value "Henry"
$customer2 | Add-Member -MemberType NoteProperty -Name "lastName" -Value "Tar"
$customer2 | Add-Member -MemberType NoteProperty -Name "age" -Value "22"
$collectionWithItems.Add($customer2) | Out-Null

$customer3 = New-Object System.Object
$customer3 | Add-Member -MemberType NoteProperty -Name "id" -Value "0"
$customer3 | Add-Member -MemberType NoteProperty -Name "firstName" -Value "Maria"
$customer3 | Add-Member -MemberType NoteProperty -Name "lastName" -Value "Sun"
$customer3 | Add-Member -MemberType NoteProperty -Name "age" -Value "11"
$collectionWithItems.Add($customer3) | Out-Null

$customer4 = New-Object System.Object
$customer4 | Add-Member -MemberType NoteProperty -Name "id" -Value "0"
$customer4 | Add-Member -MemberType NoteProperty -Name "firstName" -Value "Arne"
$customer4 | Add-Member -MemberType NoteProperty -Name "lastName" -Value "Simonsen"
$customer4 | Add-Member -MemberType NoteProperty -Name "age" -Value "34"
$collectionWithItems.Add($customer4) | Out-Null

foreach($item in $collectionWithItems)
{
  $JSON = @"
  {
    "id": $($item.id),
    "firstName": `"$($item.firstName)`",
    "lastName": "$($item.lastName)",
    "age": $($item.age)
  }
"@
Write-Host $JSON
$response = Invoke-RestMethod -Uri "https://localhost:44350/api/Customer" -Method Post -Body $JSON -ContentType "application/json"
Write-Host $response
}