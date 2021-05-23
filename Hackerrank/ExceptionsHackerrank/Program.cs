using System;

namespace ExceptionsHackerrank
{
    class Solution
    {
        public static void Main(string[] args)
        {
            string S = Console.ReadLine();
            try
            {
                int number = int.Parse(S);
                Console.WriteLine(number);
            }
            catch(Exception e)
            {
                Console.WriteLine("Exception detected!");
            }
        }
    }
}
