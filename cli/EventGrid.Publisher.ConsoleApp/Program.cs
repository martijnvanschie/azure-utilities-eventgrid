// See https://aka.ms/new-console-template for more information
using EventGrid.Publisher.ConsoleApp;
using Spectre.Console;
using System.CommandLine;
using System.Diagnostics;

var version = typeof(Program).Assembly.GetName().Version;
Console.WriteLine($"{AppContext.BaseDirectory}");

var path = Path.Combine(AppContext.BaseDirectory, "evgtpub.exe");
var fileversion = FileVersionInfo.GetVersionInfo(path).FileVersion;
AnsiConsole.MarkupLine($"Event Grid Publisher - [lightgoldenrod2_1]{fileversion}[/]");
AnsiConsole.MarkupLine($"Part of the [cyan1]Azure Utilities Collection[/]");

Console.WriteLine();

var rootCommand = new CommandLineParser();
await rootCommand.Command.InvokeAsync(args);

Console.WriteLine();
AnsiConsole.MarkupLine("Please let me know how i'm doing: [cyan1]https://github.com/martijnvanschie/azure-utilities-eventgrid[/]");