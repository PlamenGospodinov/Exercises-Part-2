using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountingValleys
{
    class Result
    {

        /*
         * Complete the 'countingValleys' function below.
         *
         * The function is expected to return an INTEGER.
         * The function accepts following parameters:
         *  1. INTEGER steps
         *  2. STRING path
         */


        public static int countingValleys(int steps, string path)
        {
            int seaLevel = 0;
            int currentLevel = 0;
            bool firstStepBelow = false;
            int valleys = 0;
            char[] pathArr = path.ToCharArray();
            for (int currentSteps = 0; currentSteps < steps; currentSteps++)
            {
                if (pathArr[currentSteps] == 'D')
                {
                    if (currentLevel == seaLevel)
                    {
                        firstStepBelow = true;
                    }
                    currentLevel -= 1;
                }
                else if (pathArr[currentSteps] == 'U')
                {
                    if (currentLevel == seaLevel - 1)
                    {
                        firstStepBelow = false;
                        valleys++;
                    }
                    currentLevel++;
                }
            }

            return valleys;
        }

    }

    class Solution
    {
        public static void Main(string[] args)
        {
            //TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

            int steps = Convert.ToInt32(Console.ReadLine().Trim());

            string path = Console.ReadLine();

            int result = Result.countingValleys(steps, path);

            Console.WriteLine(result);
            Console.ReadLine();
            //textWriter.Flush();
            //textWriter.Close();
        }
    }
}
