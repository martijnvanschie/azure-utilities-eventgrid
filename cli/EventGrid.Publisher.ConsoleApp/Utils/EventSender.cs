using Reduct.Azure.EventGrid;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventGrid.Publisher.ConsoleApp.Utils
{
    internal class EventSender
    {
        internal static async Task SendFileToEventGridAsync(FileInfo file, string topic, string accesskey, string region = "westeurope-1", bool overrideId = false)
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
    }
}
