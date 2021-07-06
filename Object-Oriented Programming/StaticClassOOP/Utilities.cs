using System;
using System.Collections.Generic;
using System.Text;

namespace StaticClassOOP
{
    static class Utilities
    {

        public static void ColorConsoleWrite(string message,ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(message);
            Console.ResetColor();
        }
    }
}
