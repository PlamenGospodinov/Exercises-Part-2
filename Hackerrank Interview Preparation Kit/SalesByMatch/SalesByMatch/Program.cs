using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesByMatch
{
    class Result
    {

        /*
         * Complete the 'sockMerchant' function below.
         *
         * The function is expected to return an INTEGER.
         * The function accepts following parameters:
         *  1. INTEGER n
         *  2. INTEGER_ARRAY ar
         */

        public static int sockMerchant(int n, List<int> ar)
        {
            int numberOfPairs = 0;
            Dictionary<int, int> numberOfSocks = new Dictionary<int, int>();
            
            foreach (int num in ar)
            {
                if (numberOfSocks.ContainsKey(num))
                {
                    numberOfSocks[num]++;
                }
                else
                {
                    numberOfSocks.Add(num, 1);
                }
            }

            foreach(int dictKey in numberOfSocks.Values)
            {
                int pairs = dictKey / 2;
                numberOfPairs += pairs;
            }

            return numberOfPairs;
        }

    }

    class Solution
    {
        public static void Main(string[] args)
        {
            TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

            int n = Convert.ToInt32(Console.ReadLine().Trim());

            List<int> ar = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arTemp => Convert.ToInt32(arTemp)).ToList();

            int result = Result.sockMerchant(n, ar);

            textWriter.WriteLine(result);

            textWriter.Flush();
            textWriter.Close();
        }
    }
}
