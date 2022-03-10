// See https://aka.ms/new-console-template for more information
using EventGrid.Publisher.ConsoleApp;
using Spectre.Console;
using System.CommandLine;

AnsiConsole.MarkupLine("Azure Utilities - Event Grid Publisher - [lightgoldenrod2_1]0.1.0-alpha[/]");
Console.WriteLine();

var rootCommand = new CommandLineParser();
await rootCommand.Command.InvokeAsync(args);

Console.WriteLine();
AnsiConsole.MarkupLine("Please let me know how i'm doing: [cyan1]https://github.com/martijnvanschie[/]");