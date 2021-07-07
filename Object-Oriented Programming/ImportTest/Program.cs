using System;
using System.Collections.Generic;

namespace ImportTest
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> ints = new List<int>();
            List<double> doubles = new List<double>();

            while (true)
            {
                int intResult;
                double doubleResult;
                Console.WriteLine("Enter an int or a double: ");
                string input = Console.ReadLine();
                if(int.TryParse(input,out intResult))
                {
                    ints.Add(intResult);
                }
                else if(double.TryParse(input,out doubleResult))
                {
                    doubles.Add(doubleResult);
                }
                else
                {
                    break;
                }
            }

            Console.Write("You entered {0} ints:", ints.Count);
            foreach(int i in ints)
            {
                Console.Write(" " + i);
            }
            Console.WriteLine();

            Console.Write("You entered {0} doubles:", doubles.Count);
            foreach (double i in doubles)
            {
                Console.Write(" " + i);
            }
            Console.WriteLine();

        }
    }
}
