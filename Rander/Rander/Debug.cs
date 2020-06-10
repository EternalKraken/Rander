using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rander
{
    public static class Debug
    {
        public static void Log(string Text)
        {
            Console.WriteLine(Text);
        }

        public static void LogWarning(string Text)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(Text);
            Console.ResetColor();
        }

        public static void LogSuccess(string Text)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(Text);
            Console.ResetColor();
        }

        public static void LogError(string Text)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(Text);
            Console.ResetColor();
        }
    }
}
