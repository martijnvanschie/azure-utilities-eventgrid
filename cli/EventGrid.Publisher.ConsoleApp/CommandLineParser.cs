using EventGrid.Publisher.ConsoleApp.Commands;
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

            Command.AddCommand(new SendRootCommand());
        }
    }
}
