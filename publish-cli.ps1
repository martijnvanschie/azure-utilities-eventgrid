$publishingfolder = "c:\apps\Azure utils"
$singlefile = "true"

dotnet publish `
    .\cli\EventGrid.Publisher.ConsoleApp\EventGrid.Publisher.ConsoleApp.csproj `
    -p:PublishSingleFile=$singlefile `
    --output $publishingfolder `
    --runtime win-x64 `
    --configuration "Release" `
    --no-self-contained