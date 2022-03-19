using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventGrid.Publisher.ConsoleApp.Utils
{
    internal class FileReader
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        /// <exception cref="FileNotFoundException"></exception>
        internal static BinaryData ReadFile(string filename)
        {
            FileInfo file = new FileInfo(filename);

            if (!file.Exists)
            {
                AnsiConsole.MarkupLine($"File with name [cyan1]{filename}[/] was not found.");
                throw new FileNotFoundException("File not found.", filename);
            }

            return BinaryData.FromBytes(File.ReadAllBytes(file.FullName));
        }
    }
}
