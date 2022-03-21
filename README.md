# Azure Event Grid Utility

## Purpose

This is a small cli tool that let's you send a event grid message to a topic using a Command-Line interface. It requires a topic, access token and a file.

## Prerequisites

The event grid cli expects the event grid to be deployed for it to work. The information of the grid is then used as options for the cli to send the prepared message (json file) to the event grid.

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

## Enjoy

Just enjoy this really simple cli and use it well :)
