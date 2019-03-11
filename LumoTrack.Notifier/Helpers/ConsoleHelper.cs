using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LumoTrack.Notifier.Helpers
{
    internal static class ConsoleHelper
    {
        internal static void WriteError(string message)
        {
            Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine(message);

            Console.ResetColor();
        }

        internal static void WriteWarning(string message)
        {
            Console.BackgroundColor = ConsoleColor.DarkYellow;
            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine(message);

            Console.ResetColor();
        }

        internal static void WriteTitle(string message)
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.DarkGray;

            Console.WriteLine(message);

            Console.ResetColor();
        }

        internal static void WriteSubtitle(string message)
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Gray;

            Console.WriteLine(message);

            Console.ResetColor();
        }

        internal static void WriteMessage(string message)
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine(message);

            Console.ResetColor();
        }

        internal static void WriteSeparator()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Black;

            Console.WriteLine("-----------------------------------------------");

            Console.ResetColor();
        }

        internal static void ClearCurrentConsoleLine()
        {
            int currentLineCursor = Console.CursorTop;
            Console.SetCursorPosition(0, Console.CursorTop);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, currentLineCursor);
        }
    }
}
