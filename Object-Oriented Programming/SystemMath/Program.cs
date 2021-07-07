using System;

namespace SystemMath
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Calculator of isosceles triangle's area");
            Console.WriteLine("Length of the first side: ");
            double firstSide = double.Parse(Console.ReadLine());
            Console.WriteLine("Length of the second side: ");
            double secondSide = double.Parse(Console.ReadLine());
            Console.WriteLine("Size of the angle in degrees: ");
            int angle = int.Parse(Console.ReadLine());

            double angleInRadians = Math.PI * angle / 180.0;
            double area = 0.5 * firstSide * secondSide * Math.Sin(angleInRadians);
            Console.WriteLine("Area of the triangle: {0:F2}",area);
        }
    }
}
