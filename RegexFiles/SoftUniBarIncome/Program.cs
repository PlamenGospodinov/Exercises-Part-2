using System;
using System.Text.RegularExpressions;

namespace SoftUniBarIncome
{
    class Program
    {
        static void Main(string[] args)
        {
            Regex regex = new Regex(@"^[^|$%.]*%(?<customer>[A-Z][a-z]+)%[^|$%.]*<(?<product>\w+)>[^|$%.]*\|(?<quantity>\d+)\|[^|$%.]*?(?<price>(\d+\.?\d*))[^|$%.]*\$$");

            double income = 0;
            while (true)
            {
                string line = Console.ReadLine();
                if(line == "end of shift")
                {
                    break;
                }

                Match match = regex.Match(line);
                if (!match.Success)
                {
                    continue;
                }

                string customer = match.Groups["customer"].Value;
                string product = match.Groups["product"].Value;
                int quantity = int.Parse(match.Groups["quantity"].Value);
                double price = double.Parse(match.Groups["price"].Value);

                double totalCustomerIncome = price * quantity;
                Console.WriteLine($"{customer}: {product} - {totalCustomerIncome:F2}");
                income += totalCustomerIncome;
            }
            Console.WriteLine($"Total income: {income:F2}");
        }
    }
}
