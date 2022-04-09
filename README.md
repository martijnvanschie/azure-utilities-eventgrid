# Azure Event Grid Utility

![GitHub tag (latest by date)](https://img.shields.io/github/v/tag/martijnvanschie/azure-utilities-eventgrid?label=Latest%20Release&logo=github) ![GitHub Release Date](https://img.shields.io/github/release-date/martijnvanschie/azure-utilities-eventgrid?logo=github) ![GitHub Workflow Status](https://img.shields.io/github/workflow/status/martijnvanschie/azure-utilities-eventgrid/Continues%20Integration?label=CI%20build&logo=github)

## Purpose

This is a small cli tool that let's you send a event grid message to a topic using a Command-Line interface. It requires a topic, access token and a file.

## Getting started

### Download

To get started, download the [latest](https://github.com/martijnvanschie/azure-utilities-eventgrid/releases/latest) release from the release page. Alternatively you can choose any of the pre-release versions available or just fork the code and build it yourself.

Currently the following downloads are available

| Artifact                                        | Description      	|
|-------------------------------------------------|------------------	|
| evgtpub-win-x64-{version}.zip                	  | A windows x64 based version which requires .NET Runtime to be installed 	|
| evgtpub-win-x64-self-contained-{version}.zip 	  | A windows x64 based version which is self contained and does not require .NET Runtime to be installed	|
| evgtpub-linux-x64-{version}.zip                	| A linux x64 based version which requires .NET Runtime to be installed 	|
| evgtpub-linux-x64-self-contained-{version}.zip 	| A linux x64 based version which is self contained and does not require .NET Runtime to be installed	|

> The linux package should run on most desktop distributions like CentOS, Debian, Fedora, Ubuntu, and derivatives.

### Prerequisites

Depending on the artifact you download you need to have [.NET 6.0 Runtime](https://dotnet.microsoft.com/en-us/download/dotnet/6.0/runtime) installed on your machine.

The event grid cli also expects the event grid to be deployed for it to work. It will not create one automatically. The information of the grid is then used as options for the cli to send the prepared message (json file) to the event grid.

## Usage

Run the following command from the command line to get the cli usage information.

`evgtpub -h`

The command line currently has two commands:

- Sending a single file
- Sending a set of files from a folder

### Send a single file to the event grid

Example command that takes the default file (`event.json`) from the working directory

`evgtpub send file --topic evgt-demo --accesskey "sometoken"`

You can specify a different file using the `--filename` option.

`evgtpub send file --topic evgt-demo --accesskey "sometoken" --filename "someevent.json"`

### Send files from a folder to the event grid

Example command that takes the default file (`events`) folder in the working directory

`evgtpub send folder --topic evgt-demo --accesskey "sometoken"`

You can specify a different folder using the `--folder` option.

`evgtpub send folder --topic evgt-demo --accesskey "sometoken" --folder "messages"`

### Override event id's

The event id is a required field according to it's [schema](https://docs.microsoft.com/en-us/azure/event-grid/event-schema) and should therefor be set in the file. If the id is missing from the file the serialization will fail. To prevent duplicate id's you can tell the cli to override the id with a guid prior to sending it to the event grid. Use the `--override-eventid` option to enforce a new id.

`evgtpub send file --topic evgt-demo --accesskey "sometoken" --override-eventid true`

### Authentication

The Event Grid utility uses a token to authenticate against the Event Grid topic. No additional credentials are required.

## Enjoy

Just enjoy this really simple cli and use it well :)
