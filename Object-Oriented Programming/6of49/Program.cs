using System;

namespace _6of49
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rand = new Random();
            for(int i = 0; i < 6; i++)
            {
                int randomNumber = rand.Next(49) + 1;
                Console.Write("{0} ",randomNumber);
            }
        }
    }
}
