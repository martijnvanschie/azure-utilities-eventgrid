### Run the following command to enable execution of unsigned scripts in current sessions.
### Set-ExecutionPolicy -ExecutionPolicy Unrestricted -Scope Process
###


$publishingfolder = "c:\apps\Azure utils\packages"
$singlefile = "true"

dotnet publish `
    .\cli\EventGrid.Publisher.ConsoleApp\EventGrid.Publisher.ConsoleApp.csproj `
    -p:PublishSingleFile=$singlefile `
    --output $publishingfolder\win-64-self-contained `
    --runtime win-x64 `
    --configuration "Release" `
    --self-contained true

dotnet publish `
    .\cli\EventGrid.Publisher.ConsoleApp\EventGrid.Publisher.ConsoleApp.csproj `
    -p:PublishSingleFile=$singlefile `
    --output $publishingfolder\win-64 `
    --runtime win-x64 `
    --configuration "Release" `
    --self-contained false    

dotnet publish `
    .\cli\EventGrid.Publisher.ConsoleApp\EventGrid.Publisher.ConsoleApp.csproj `
    -p:PublishSingleFile=$singlefile `
    --output $publishingfolder\linux-x64-contained `
    --runtime linux-x64 `
    --configuration "Release" `
    --self-contained true    
    
    dotnet publish `
    .\cli\EventGrid.Publisher.ConsoleApp\EventGrid.Publisher.ConsoleApp.csproj `
    -p:PublishSingleFile=$singlefile `
    --output $publishingfolder\linux-x64 `
    --runtime linux-x64 `
    --configuration "Release" `
    --self-contained false     

$publishingfolder = "c:\apps\Azure utils"

dotnet publish `
    .\cli\EventGrid.Publisher.ConsoleApp\EventGrid.Publisher.ConsoleApp.csproj `
    -p:PublishSingleFile=$singlefile `
    --output $publishingfolder `
    --runtime win-x64 `
    --configuration "Release" `
    --self-contained false 