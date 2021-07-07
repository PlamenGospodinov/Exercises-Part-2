using System;

namespace StaticMembers
{

    public class Sequence
    {
        private static int currentValue = 0;
        private Sequence()
        {

        }

        public static int NextValue()
        {
            currentValue++;
            return currentValue;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Sequence[1...3]: {0},{1},{2}",Sequence.NextValue(), Sequence.NextValue(), Sequence.NextValue());
        }
    }
}
