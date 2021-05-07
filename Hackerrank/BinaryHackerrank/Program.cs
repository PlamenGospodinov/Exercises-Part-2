using System;
using System.Linq;

namespace BinaryHackerrank
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter your number: ");
            int number = int.Parse(Console.ReadLine());
            string numberInBinaryReversed = "";
            int remainder = 0;
            int longestSequenceOf1s = 0;
            int currentLongestSequence = 0;

            while(number > 0)
            {
                remainder = number % 2;
                if(remainder == 1)
                {
                    currentLongestSequence++;
                    if(currentLongestSequence > longestSequenceOf1s)
                    {
                        longestSequenceOf1s = currentLongestSequence;
                    }
                }
                else
                {
                    currentLongestSequence = 0;
                }
                numberInBinaryReversed += remainder;
                number /= 2;
            }

            string numberInBinary = "";
            for(int i = numberInBinaryReversed.Length-1; i >= 0; i--)
            {
                numberInBinary += numberInBinaryReversed[i];
            }
            int intBinary = int.Parse(numberInBinary);
            Console.WriteLine(intBinary);
            Console.WriteLine(longestSequenceOf1s);
            
        }
    }
}
