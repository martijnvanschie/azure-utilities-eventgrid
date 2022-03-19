targetScope = 'subscription'

@description('Specifies the location for all resources.')
param location string

@description('Specifies the location for all resources.')
param groupName string

resource resourceGroup 'Microsoft.Resources/resourceGroups@2021-04-01' = {
  name: groupName
  location: location
}
