using EventGrid.Publisher.ConsoleApp.Utils;
using Reduct.Azure.EventGrid;
using Spectre.Console;
using System.CommandLine;

namespace EventGrid.Publisher.ConsoleApp.Commands
{
    internal class SendFileCommand : Command
    {
        internal SendFileCommand(string? description = null) : base("file", description)
        {
            AddOptions();
        }

        private void AddOptions()
        {
            var topicName = new Option<string>("--topic", "The name of the topic where the event should be sennd to.");
            topicName.AddAlias("-t");
            topicName.IsRequired = true;
            AddOption(topicName);

            var region = new Option<string>("--region", () => "westeurope-1", "The region where the topic is located. Used to format the url to publish the event.");
            region.AddAlias("-r");
            AddOption(region);

            var accessKey = new Option<string>("--accesskey", "The access keys used to authenticate the application to publishing events to this Azure Event Grid Topic.");
            accessKey.IsRequired = true;
            AddOption(accessKey);

            var filename = new Option<string>("--filename", () => "event.json", "The message that should be send to the Event Grid Topic.");
            filename.AddAlias("-f");
            AddOption(filename);

            var overrideEventId = new Option<bool>("--override-eventid", () => false, "Indicates if the event id is overwritten with a new id.");
            overrideEventId.ArgumentHelpName = "A new guid is generated as an id.";
            AddOption(overrideEventId);

            this.SetHandler(async (string topic, string region, string accesskey, string filename, bool overrideId) =>
            {
                AnsiConsole.MarkupLine($"Publishing event to topic [cyan1]{topic}[/].");
                AnsiConsole.MarkupLine($"Reading file [cyan1]{filename}[/].");

                var file = new FileInfo(filename);    
                await EventSender.SendFileToEventGridAsync(file, topic, accesskey, region, overrideId);

            }, topicName, region, accessKey, filename, overrideEventId);
        }
    }
}
