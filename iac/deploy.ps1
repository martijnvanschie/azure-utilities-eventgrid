if (!$env:IAC_SUBSCRIPTION_ID) {
    Write-Host "Missing IAC_SUBSCRIPTION_ID Environmental variable" -ForegroundColor Red
    exit 1
}

az deployment sub create -c --subscription $env:IAC_SUBSCRIPTION_ID `
                            --location "West Europe" `
                            --template-file main.bicep