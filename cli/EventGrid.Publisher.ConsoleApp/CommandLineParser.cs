using Spectre.Console;
using System;
using System.Collections.Generic;
using System.CommandLine;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventGrid.Publisher.ConsoleApp
{
    internal class CommandLineParser
    {
        internal RootCommand Command { get; private set; }
        public CommandLineParser()
        {
            Command = new RootCommand();
            Command.Description = "Azure Event Grid Publisher";

            AddOptions();
        }

        private void AddOptions()
        {
            var topicName = new Option<string>("--topic", "The name of the topic where the event should be sennd to.");
            topicName.AddAlias("-t");
            topicName.IsRequired = true;
            Command.AddOption(topicName);

            var region = new Option<string>("--region", () => "westeurope-1", "The region where the topic is located. Used to format the url to publish the event.");
            region.AddAlias("-r");
            Command.AddOption(region);

            var accessKey = new Option<string>("--accesskey", "The access keys used to authenticate the application to publishing events to this Azure Event Grid Topic.");
            accessKey.IsRequired = true;
            Command.AddOption(accessKey);

            var filename = new Option<string>("--filename", () => "event.json", "The message that should be send to the Event Grid Topic.");
            filename.AddAlias("-f");
            Command.AddOption(filename);

            var overrideEventId = new Option<bool>("--override-eventid", () => false, "Indicates if the event id is overwritten with a new id.");
            overrideEventId.ArgumentHelpName = "A new guid is generated as an id.";
            Command.AddOption(overrideEventId);

            Command.SetHandler(async (string topic, string region, string accesskey, string filename, bool overrideId) =>
            {
                AnsiConsole.MarkupLine($"Publishing event to topic [cyan1]{topic}[/].");

                FileInfo file = new FileInfo(filename);

                if (!file.Exists)
                {
                    AnsiConsole.MarkupLine($"File with name [cyan1]{filename}[/] was not found.");
                    return;
                }

                var binary = BinaryData.FromBytes(File.ReadAllBytes(file.FullName));

                AnsiConsole.MarkupLine($"Reading file [cyan1]{file.FullName}[/].");

                EventPublisher publisher = new EventPublisher(topic, region, accesskey);

                string? id = overrideId ? Guid.NewGuid().ToString() : null;

                await publisher.PublishBinaryDataAsync(binary, id);

            }, topicName, region, accessKey, filename, overrideEventId);
        }
    }
}
