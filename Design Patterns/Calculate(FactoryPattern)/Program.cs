using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculate_FactoryPattern_
{
    class Program
    {
        static void Main(string[] args)
        {
            bool result;
            double num1;
            double num2;
            Console.WriteLine("Enter the first number: ");
            result = Double.TryParse(Console.ReadLine(), out num1);
            if (!result)
            {
                Console.WriteLine("Please enter the first number: ");
                return;
            }

            Console.WriteLine("Enter the second number: ");
            result = Double.TryParse(Console.ReadLine(), out num2);
            if (!result)
            {
                Console.WriteLine("Please enter the second number: ");
                return;
            }

            Console.WriteLine("Enter Add,Subtract,Divide or Multiply: ");
            CalculateFactory factory = new CalculateFactory();
            ICalculate obj = factory.GetCalculation(Console.ReadLine());
            obj.Calculate(num1, num2);

        }
    }
}
