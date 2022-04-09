using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace EventGrid.Publisher.ConsoleApp
{
    internal class VersionInfo
    {
        public static void PrintVerionInfo()
        {
            var version = typeof(Program).Assembly.GetName().Version;
            Console.WriteLine($"{AppContext.BaseDirectory}");

            if (myOperatingSystem.isWindows())
            {
                var path = Path.Combine(AppContext.BaseDirectory, "evgtpub.exe");
                var fv = FileVersionInfo.GetVersionInfo(path);

                AnsiConsole.MarkupLine("");
                AnsiConsole.MarkupLine($"Event Grid Publisher - [lightgoldenrod2_1]{fv.FileMajorPart}.{fv.FileMinorPart}.{fv.FileBuildPart}[/]");
                AnsiConsole.MarkupLine($"Part of the [cyan1]Azure Utilities Collection[/]");
                AnsiConsole.MarkupLine($"[dim]Build info - {fv.ProductVersion}[/]");
            }

            if (myOperatingSystem.isLinux())
            {
                var path = Path.Combine(AppContext.BaseDirectory, "evgtpub");
                var fv = FileVersionInfo.GetVersionInfo(path);

                AnsiConsole.MarkupLine("");
                AnsiConsole.MarkupLine($"Event Grid Publisher - [lightgoldenrod2_1]{fv.FileMajorPart}.{fv.FileMinorPart}.{fv.FileBuildPart}[/]");
                AnsiConsole.MarkupLine($"Part of the [cyan1]Azure Utilities Collection[/]");
                AnsiConsole.MarkupLine($"[dim]Build info - {fv.ProductVersion}[/]");
            }
        }
    }

    public static class myOperatingSystem
    {
        public static bool isWindows() =>RuntimeInformation.IsOSPlatform(OSPlatform.Windows);
        public static bool isMacOS() =>RuntimeInformation.IsOSPlatform(OSPlatform.OSX);
        public static bool isLinux() =>RuntimeInformation.IsOSPlatform(OSPlatform.Linux);
    }
}
