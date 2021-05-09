using System;
using System.Collections.Generic;
using System.Linq;

namespace Hourglass
{
    class Program
    {
        static void Main(string[] args)
        {
            List<List<int>> arr = new List<List<int>>();

            for (int i = 0; i < 6; i++)
            {
                arr.Add(Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToInt32(arrTemp)).ToList());
            }

            int bestSum = int.MinValue;
            int currentSum = 0;
            for (int row = 0; row < 4; row++)
            {
                for(int col = 0; col < 4; col++)
                {
                    currentSum = arr[row][col] + arr[row][col+1] + arr[row][col+2] + arr[row+1][col+1]+ arr[row+2][col] + arr[row+2][col+1] + arr[row+2][col+2];
                    if(currentSum > bestSum)
                    {
                        bestSum = currentSum;
                    }
                    currentSum = 0;
                }
            }
            Console.WriteLine(bestSum);
        }
    }
}
