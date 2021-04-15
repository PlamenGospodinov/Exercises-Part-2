using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Furniture
{
    class Program
    {
        static void Main(string[] args)
        {
            Regex regex = new Regex(@">>(?<name>[A-Za-z]+)<<(?<price>\d+\.?\d*)!(?<quantity>\d+)");
            List<string> furnitures = new List<string>();
            double totalSum = 0;
            while (true)
            {
                string line = Console.ReadLine();
                if(line == "Purchase")
                {
                    break;
                }

                Match match = regex.Match(line);
                if (!match.Success)
                {
                    continue;
                }

                string name = match.Groups["name"].Value;
                double price = double.Parse(match.Groups["price"].Value);
                double quantity = int.Parse(match.Groups["quantity"].Value);
                furnitures.Add(name);
                totalSum += price * quantity;
            }

            Console.WriteLine("Furnitures: ");
            foreach(string f in furnitures)
            {
                Console.WriteLine(f);
            }
            Console.WriteLine("Total price: {0:F2}", totalSum);
        }
    }
}
