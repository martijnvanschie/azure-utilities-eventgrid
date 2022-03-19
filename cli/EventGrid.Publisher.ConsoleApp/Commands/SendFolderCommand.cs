using EventGrid.Publisher.ConsoleApp.Options;
using EventGrid.Publisher.ConsoleApp.Utils;
using Reduct.Azure.EventGrid;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.CommandLine;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventGrid.Publisher.ConsoleApp.Commands
{

    internal class SendFolderCommand : Command
    {
        internal SendFolderCommand(string? description = null) : base("folder", description)
        {
            AddOptions();
        }

        private void AddOptions()
        {
            var topicName = new Option<string>("--topic", "The name of the topic where the event should be sennd to.");
            topicName.AddAlias("-t");
            topicName.IsRequired = true;
            AddOption(topicName);


            var accessKey = new Option<string>("--accesskey", "The access keys used to authenticate the application to publishing events to this Azure Event Grid Topic.");
            accessKey.IsRequired = true;
            AddOption(accessKey);

            var folder = new Option<string>("--folder", () => "events/", "The folder containing the messages that should be send to the Event Grid Topic.");
            folder.AddAlias("-f");
            AddOption(folder);

            var pattern = new Option<string>("--search-pattern", () => "*.json", "The search string to match against the names of files.");
            AddOption(pattern);

            var overrideEventId = new Option<bool>("--override-eventid", () => false, "Indicates if the event id is overwritten with a new id.");
            overrideEventId.ArgumentHelpName = "A new guid is generated as an id.";
            AddOption(overrideEventId);

            var region = new Option<string>("--region", () => "westeurope-1", "The region where the topic is located. Used to format the url to publish the event.");
            region.AddAlias("-r");
            AddOption(region);

            this.SetHandler(async (string topic, string region, string accesskey, string folder, bool overrideId, string pattern) =>
            {
                AnsiConsole.MarkupLine($"Publishing events from folder [[{folder}]] to topic [cyan1]{topic}[/].");

                DirectoryInfo di = new DirectoryInfo(folder);
                if (!di.Exists)
                {
                    AnsiConsole.MarkupLine($"[{ConsoleColors.Warning}]The message folder [[{di.FullName}]] does not exist.[/].");
                    await Task.Delay(100);
                    return;
                }

                AnsiConsole.MarkupLine($"Searching folder [cyan1]{di.FullName}[/].");
                var files = di.GetFiles(pattern);
                foreach (var file in files)
                {
                    try
                    {
                        AnsiConsole.MarkupLine($"File found [cyan1]{file.FullName}[/].");
                        var binary = FileReader.ReadFile(file.FullName);
                        string? id = overrideId ? Guid.NewGuid().ToString() : null;
                        EventPublisher publisher = new EventPublisher(topic, region, accesskey);

                        AnsiConsole.MarkupLine($"Publishing message.");
                        await publisher.PublishBinaryDataAsync(binary, id);
                    }
                    catch (ArgumentNullException ex)
                    {
                        AnsiConsole.MarkupLine($"[{ConsoleColors.Warning}]File [[{file.FullName}]] containts invalid event message. [[{ex.Message}]][/].");
                    }
                    catch (InvalidOperationException ex)
                    {
                        AnsiConsole.MarkupLine($"[{ConsoleColors.Warning}]Unable to process file [[{file.FullName}]]. [[{ex.Message}]][/].");
                    }
                    finally
                    {
                        AnsiConsole.MarkupLine($"");
                    }
                }

            }, topicName, region, accessKey, folder, overrideEventId, pattern);
        }
    }
}
