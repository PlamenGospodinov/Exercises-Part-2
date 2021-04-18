using System;
using System.Text.RegularExpressions;

namespace EmailExtractor
{
    class Program
    {
        static void Main(string[] args)
        {
            Regex regex = new Regex(@"(^|(?<=\s))[A-Za-z\d]+([-._][A-Za-z\d]+)*@[A-Za-z]+(\-[A-Za-z]+)*(\.[A-Za-z]+)+");

            string text = Console.ReadLine();

            MatchCollection matches = regex.Matches(text);


            Console.WriteLine("All emails are: ");
            foreach(Match match in matches)
            {
                Console.WriteLine(match);
            }
        }
    }
}
