using System;
using System.Text.RegularExpressions;

namespace SplitString
{
    class Program
    {
        static void Main(string[] args)
        {
            string numbers = "1   5  3 2 111 888      5 6";
            string[] splitted = Regex.Split(numbers, @"\s+");
            Console.WriteLine(string.Join(',',splitted));
        }
    }
}
