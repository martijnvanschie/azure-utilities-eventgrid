# Azure Event Grid Utility

## Purpose

This is a small cli tool that let's you send a event grid message to a topic using Command-Line interface. It reuires a topic, access token and a file.

## Prerequisites

The event grid cli expects the event grid to be setupo for it to work. The information of the grid is then used as options for the cli to send the prepared message (json file) to the event grid.

## Usage

Run the following command from the command line to get the cli usage information.

`evgtpub -h`

Example command that takes the default file (`event.json`) from the working directory

`evgtpub --topic evgt-demo --accesskey "sometoken"`

You can specify a different file using the `--filename` option.

`evgtpub --topic evgt-demo --accesskey "sometoken" --filename "someevent.json"`

As the event id is a required field it should be in the file or the serilization file fail. To prevent duplicate id's you can tell the cli to override the id with a guid prior to sending it to the event grid. Use the `` option to enforce a new id.

`evgtpub --topic evgt-demo --accesskey "sometoken" --override-eventid true`

## Enjoy

Just enjoy this really simple cli and use it well :)