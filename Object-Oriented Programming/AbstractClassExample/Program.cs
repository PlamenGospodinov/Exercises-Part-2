using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractClassExample
{
    public abstract class Animal
    {
        public void PrintInformation()
        {
            Console.WriteLine("I am {0}.",this.GetType().Name);
            Console.WriteLine(GetTypicalSound());
        }

        protected abstract String GetTypicalSound();
    }

    public class Cat : Animal
    {
        protected override string GetTypicalSound()
        {
            return "Meowwww";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Animal cat = new Cat();
            cat.PrintInformation();
            Console.ReadLine();
        }
    }
}
