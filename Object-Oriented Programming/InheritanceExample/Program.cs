using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InheritanceExample
{
    class A
    {
        public virtual void MethodA()
        {
            Console.WriteLine("A-HA-A");
        }
    }

    class B : A
    {
        public override void MethodA()
        {
            Console.WriteLine("B-HA-B");
        }

        public void MethodB()
        {
            Console.WriteLine("A-HA-B");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("A obj");
            A objA = new A();
            objA.MethodA();

            Console.WriteLine("B obj");
            B objB = new B();
            objB.MethodA();
            objB.MethodB();

            Console.WriteLine("A or B?");
            //superclass obj1 = subclass();
            A obj1 = new B();
            obj1.MethodA();
            //cannot be done like subclass obj1 = superclass();

            //casting
            ((B)obj1).MethodB();
        }
    }
}
