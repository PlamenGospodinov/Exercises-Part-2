using System;
using System.Collections.Generic;
using System.Text;

namespace WarriorFightsOOP
{
    public static class Additional
    {
        public static void ColorWriteLine(string message,ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(message);
            Console.ResetColor();
        }
    }
}
