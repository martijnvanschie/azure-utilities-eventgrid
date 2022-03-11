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

## Resources

### Versioning

This project follow the below versioning guidelines.

| Version              | Format                                    | Description |
| -------------------- | ----------------------------------------- | ----------- |
| AssemblyVersion      | `major.minor.0.0`                         | Scoped to only major and minor version changes. Indicates backward compatibility. |
| FileVersion          | `major.minor.patch.build`                 | Includes a patch and build numer, indicating the exact version of the application. |
| InformationalVersion | `major.minor.patch-pre-release`           | Includes a pre-release identifier. This is the informational version used to communicate. |
| PackageVersion       | `major.minor.patch-pre-release+commit-id` | Includes the commit id. This is the most specific version and has a direct reference to the github commit. |

[Versioning and .NET Libraries](https://docs.microsoft.com/en-us/dotnet/standard/library-guidance/versioning)

[Semantic Versioning 2.0.0](https://semver.org/)