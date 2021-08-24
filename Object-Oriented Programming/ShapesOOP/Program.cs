using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapesOOP
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> input = ReadInput();
            List<Shape> shapes = ParseInput(input);
            shapes.ForEach(s => Console.WriteLine("{0:0.0000}",s.CalculateSurface()));
        }

        private static List<string> ReadInput()
        {
            List<string> input = new List<string>();
            Int32 numberOfLines;

            string firstLineOfInput = Console.ReadLine();
            numberOfLines = Int32.Parse(firstLineOfInput);

            for (int lines = 0; lines < numberOfLines; lines++)
            {
                string line = Console.ReadLine();
                input.Add(line);
            }

            return input;
        }

        private static List<Shape> ParseInput(List<string> input)
        {
            const Int32 shapeTypeIndex = 0, circleDiameterIndex = 1, widthIndex = 1, heightIndex = 2;
            Char[] separators = new Char[] { ' ' };
            List<Shape> shapes = new List<Shape>();
            foreach(String line in input)
            {
                String[] words = line.Split(separators, StringSplitOptions.RemoveEmptyEntries);
                switch (words[shapeTypeIndex].ToLower())
                {
                    case "circle":
                        Circle circle = new Circle(double.Parse(words[circleDiameterIndex]));
                        shapes.Add(circle);
                        break;
                    case "rectangle":
                        Rectangle rectangle = new Rectangle(double.Parse(words[heightIndex]), double.Parse(words[widthIndex]));
                        shapes.Add(rectangle);
                        break;
                    case "triangle":
                        Triangle triangle = new Triangle(double.Parse(words[heightIndex]), double.Parse(words[widthIndex]));
                        shapes.Add(triangle);
                        break;
                    default:
                        throw new ArgumentException("Unknown type");
                        
                }
            }

            return shapes;
        }
    }

    

    


abstract class Shape
    {
        public Double Width { get; set; }
        public Double Height { get; set; }

        public abstract double CalculateSurface();
    }

    class Triangle : Shape
    {
        public Triangle(double height,double width)
        {
            this.Height = height;
            this.Width = width;
        }

        public override double CalculateSurface()
        {
            return (this.Height * this.Width) / 2;
        }
    }

    class Rectangle : Shape
    {
        public Rectangle(double height, double width)
        {
            this.Height = height;
            this.Width = width;
        }

        public override double CalculateSurface()
        {
            return this.Height * this.Width;
        }
    }

    class Circle : Shape
    {
        public Double Diameter { get; set; }

        public Circle(double diameter)
        {
            this.Diameter = diameter;
            this.Width = diameter;
            this.Height = diameter;
        }

        public override double CalculateSurface()
        {
            return Math.PI * Math.Pow((this.Diameter / 2), 2);
        }
    }
}
