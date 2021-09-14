using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JumpingOnTheClouds
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> list = new List<int>();
            
            int numberOfDigits = int.Parse(Console.ReadLine());
            int[] arr = new int[numberOfDigits];
            string[] whole = Console.ReadLine().Split(' ');
            for (int i = 0; i < numberOfDigits; i++)
            {
                int num = int.Parse(whole[i]);
                list.Add(num);
            }

            Console.WriteLine(jumpingOnClouds(list));
            Console.ReadLine();
        }

        public static int jumpingOnClouds(List<int> c)
        {
            int[] arrOfDigits = new int[c.Count];
            for (int i = 0; i < arrOfDigits.Length; i++)
            {
                arrOfDigits[i] = c[i];
            }

            int numberOfJumps = 0;
            int doubleJumpChecker = 0;
            bool prevIsZero = false;
            bool prevIsOne = false;
            for (int index = 1; index < arrOfDigits.Length; index++)
            {
                if (arrOfDigits[index] == 1)
                {
                    numberOfJumps += 0;
                    prevIsOne = true;
                    prevIsZero = false;
                    doubleJumpChecker = 0;
                }
                else if (doubleJumpChecker == 2 && arrOfDigits[index] == 0)
                {
                    numberOfJumps += 0;
                    prevIsZero = true;
                    doubleJumpChecker = 1;
                }
                else if (arrOfDigits[index] == 0 && index == 1)
                {
                    numberOfJumps++;
                    prevIsZero = true;
                    prevIsOne = false;
                    doubleJumpChecker += 2;
                }
                else if (arrOfDigits[index] == 0)
                {
                    numberOfJumps++;
                    prevIsZero = true;
                    prevIsOne = false;
                    doubleJumpChecker++;
                }

            }




            return numberOfJumps;
        }
    }

    
}
