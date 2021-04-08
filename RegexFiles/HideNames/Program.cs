using System;
using System.Text.RegularExpressions;

namespace HideNames
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"(?<firstName>[A-Z][a-z]+) (?<lastName>[A-Z][a-z]+)";
            Regex reg = new Regex(pattern);
            string input = Console.ReadLine();
            var hidden = reg.Replace(input,"*** ***");
            Console.WriteLine(hidden);
        }
    }
}
