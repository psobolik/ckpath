using System;
using System.Collections.Generic;
using System.Linq;

namespace ckpath
{
    internal static class Program
    {
        private static void Main()
        {
            WriteList("PATH:", PathChecker.GetAllFolders);
            WriteList("Missing folders in PATH:", PathChecker.GetMissingFolders);
            WriteList("Duplicate folders in PATH:", PathChecker.GetDuplicateFolders);
        }

        private static void WriteList(string header, Func<IEnumerable<string>> func)
        {
            const ConsoleColor headerColor = ConsoleColor.Green;
            const ConsoleColor infoColor = ConsoleColor.Yellow;
            const ConsoleColor listColor = ConsoleColor.White;
        
            static void WriteValue(string value, ConsoleColor foregroundColor)
            {
                Console.ForegroundColor = foregroundColor;
                Console.WriteLine(value);
                Console.ResetColor();
            }

            WriteValue(header, headerColor);
            var values = func().ToArray();
            if (values.Any())
            {
                foreach (var value in values)
                {
                    WriteValue(value, listColor);
                }
            }
            else
            {
                WriteValue("[None]", infoColor);
            }
        }
    }
}
