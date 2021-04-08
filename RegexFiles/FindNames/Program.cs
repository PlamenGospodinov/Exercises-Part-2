using System;
using System.Text.RegularExpressions;

namespace FindNames
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"(?<firstName>[A-Z][a-z]+) (?<lastName>[A-Z][a-z]+)";
            Regex reg = new Regex(pattern);
            string input = Console.ReadLine();
            var matches = reg.Matches(input);
            foreach(var match in matches)
            {
                Console.WriteLine(match);
            }
        }
    }
}
