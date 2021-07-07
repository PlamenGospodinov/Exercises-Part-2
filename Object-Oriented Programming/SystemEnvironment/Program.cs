using System;

namespace SystemEnvironment
{
    class Program
    {
        static void Main(string[] args)
        {
            int sum = 0;
            int startTime = Environment.TickCount;

            for(int i = 0; i < 10000000; i++)
            {
                sum++;
            }

            int endTime = Environment.TickCount;
            Console.WriteLine("The time elapsed is: {0} seconds.",(endTime-startTime)/1000.0);
        }
    }
}
