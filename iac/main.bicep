targetScope = 'subscription'

@description('Specifies the location for all resources.')
param location string = 'westeurope'

@description('Specifies the location for all resources.')
param resourceGroupName string = 'rg-eventgridpublisher-test'

@description('Specifies the location for all resources.')
param environment string = 'dev'

module resourceGroup 'modules/resourcegroup.bicep' = {
  name: 'Azure.Demos.EventGrid.ResourceGroup'
  scope: az.subscription()
  params: {
    groupName: resourceGroupName
    location: location
  }
}

module topicAndQueue 'modules/eventtopicandqueue.bicep' = {
  name: 'Azure.Demos.EventGrid.TopicAndQueue'
  scope: az.resourceGroup(resourceGroupName)
  params: {
    location: location
    environment: environment
  }
  dependsOn: [
    resourceGroup
  ]
}
