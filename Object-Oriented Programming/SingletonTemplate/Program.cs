using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingletonTemplate
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    class Singleton
    {
        //Single instance
        private static Singleton instance;

        //Initialize the single instance
        static Singleton()
        {
            instance = new Singleton();
        }

        //The property for taking the single instance
        public static Singleton Instance
        {
            get
            {
                return instance;
            }
        }

        //Private constructor - protests direct instantiation
        private Singleton()
        {

        }
    }
}
