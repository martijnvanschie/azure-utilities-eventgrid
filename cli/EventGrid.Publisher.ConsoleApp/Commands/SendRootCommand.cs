using System.CommandLine;

namespace EventGrid.Publisher.ConsoleApp.Commands
{
    internal class SendRootCommand : Command
    {
        internal SendRootCommand() : base("send", "Send events to the event grid.")
        {
            this.AddCommand(new SendFileCommand("Send messages, based on a file, to the event grid."));
            this.AddCommand(new SendFolderCommand("Send all messages from a folder to the event grid."));
        }
    }
}
