targetScope = 'resourceGroup'

@description('Specifies the location for all resources.')
param location string

param environment string

var uniquePart = substring(uniqueString(az.subscription().id), 0, 4)

resource eventGrid 'Microsoft.EventGrid/topics@2021-12-01' = {
  name: 'egt-${environment}'
  location: location
}

resource storage 'Microsoft.Storage/storageAccounts@2021-08-01' = {
  name: 'sa${environment}${uniquePart}'
  location: location
  sku: {
    name: 'Standard_LRS'
  }
  kind: 'StorageV2'
}

resource queueService 'Microsoft.Storage/storageAccounts/queueServices@2021-08-01' = {
  name: 'default'
  parent: storage
}

resource symbolicname 'Microsoft.Storage/storageAccounts/queueServices/queues@2021-08-01' = {
  name: 'sq-eventgrid-publisher'
  parent: queueService
  properties: {
    metadata: {}
  }
}

resource eventSubscription 'Microsoft.EventGrid/eventSubscriptions@2021-12-01' = {
  name: 'es-${storage.name}'
  scope: eventGrid
  properties: {
    destination: {
      endpointType: 'StorageQueue'
      properties: {
        queueMessageTimeToLiveInSeconds: 1000
        queueName: symbolicname.name
        resourceId: storage.id
      }
    }
  }
}
