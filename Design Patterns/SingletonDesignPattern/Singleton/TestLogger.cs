using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingletonDesignPattern.Singleton
{
    class TestLogger
    {
        static void Main(string[] args)
        {
            Console.WriteLine("---Singleton---");
            Logger obj1 = Logger.GetInstance();
            Logger obj2 = Logger.GetInstance();
            Console.WriteLine(obj1.GetHashCode());
            Console.WriteLine(obj2.GetHashCode());
            Console.WriteLine("---Non-Singleton---");
            Test obj3 = new Test();
            Test obj4 = new Test();
            Console.WriteLine(obj3.GetHashCode());
            Console.WriteLine(obj4.GetHashCode());
            Console.ReadKey();
        }
    }

    class Test
    {
        public Test()
        {

        }
    }

}
