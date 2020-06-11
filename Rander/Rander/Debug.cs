using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
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

        public static void LogError(string Text, bool CloseWindow = false, int traceBackAmount = 2)
        {
            StackFrame frame = new StackFrame(traceBackAmount, true);
            string MethodName = frame.GetMethod().Name;
            string ScriptName = frame.GetFileName();
            int Line = frame.GetFileLineNumber();

            // Writes to the console
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n-----Error Report-----");
            Console.WriteLine(Text + "\n");
            Console.WriteLine("Method: " + MethodName);
            Console.WriteLine("Line: " + Line);
            Console.WriteLine("Script Path: " + ScriptName);
            Console.WriteLine("----------------------");
            Console.ResetColor();

            if (CloseWindow == true)
            {
                // Closes the game window and keeps the console open
                Game.Close();
                if (Console.ReadKey() != null)
                {
                    // Waits for the console window to close, then terminates the program
                }
            }
        }
    }
}