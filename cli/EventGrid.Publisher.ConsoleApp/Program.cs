// See https://aka.ms/new-console-template for more information
using EventGrid.Publisher.ConsoleApp;
using Spectre.Console;
using System.CommandLine;
using System.Diagnostics;
using System.Reflection;

VersionInfo.PrintVerionInfo();
Console.WriteLine();

var rootCommand = new CommandLineParser();
await rootCommand.Command.InvokeAsync(args);

Console.WriteLine();
AnsiConsole.MarkupLine("Please let me know how i'm doing: [cyan1]https://github.com/martijnvanschie/azure-utilities-eventgrid[/]");