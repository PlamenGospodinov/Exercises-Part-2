using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkersArrayOOP
{
    class Program
    {
        static void Main(string[] args)
        {

            List<string> input = ReadInput();
            List<Worker> workers = ParseInput(input);

            workers.Sort();
            workers.ForEach(p => Console.WriteLine(p));
        }

        private static List<string> ReadInput()
        {
            List<string> input = new List<string>();
            Int32 numberOfLines;

            string firstLineOfInput = Console.ReadLine();
            numberOfLines = Int32.Parse(firstLineOfInput);

            for(int lines = 0;lines < numberOfLines; lines++)
            {
                string line = Console.ReadLine();
                input.Add(line);
            }

            return input;
        }

        private static List<Worker> ParseInput(List<string> input)
        {
            const Int32 firstNameIndex = 0, lastNameIndex = 1,wageIndex = 2;
            Char[] separators = new char[] { ' ' };
            List<Worker> workers = new List<Worker>();
            foreach(String line in input)
            {
                String[] words = line.Split(separators, StringSplitOptions.RemoveEmptyEntries);
                Worker worker = new Worker(words[firstNameIndex], words[lastNameIndex], double.Parse(words[wageIndex]));

                workers.Add(worker);
            }

            return workers;
        }
    }


    class Human : IComparable
    {

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public Human(string firstName,string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
        }
        public int CompareTo(object obj)
        {
            if (null == obj) return 1;

            Human otherHuman = obj as Human;
            if(otherHuman != null)
            {
                Int32 firstNameComparisson = this.FirstName.CompareTo(otherHuman.FirstName);
                if(firstNameComparisson == 0)
                {
                    return this.LastName.CompareTo(otherHuman.LastName);
                }
                else
                {
                    return firstNameComparisson;
                }
            }
            else
            {
                throw new ArgumentException("Object is not a Cell");
            }
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;

            if (this.GetType() != obj.GetType()) return false;

            Human otherHuman = (Human)obj;
            bool firstNamesAreEqual = this.FirstName == otherHuman.FirstName;
            bool lastNamesAreEqual = this.LastName == otherHuman.LastName;

            return firstNamesAreEqual && lastNamesAreEqual;
        }

        public override int GetHashCode()
        {
            return (this.FirstName + this.LastName).GetHashCode();
        }

        public override string ToString()
        {
            return String.Format("{0} {1}", this.FirstName, this.LastName);
        }
    }

    class Worker : Human, IComparable
    {
        public double Wage { get; set; }
        public double WorkedOutHours { get; set; }

        public Worker(string firstName,string lastName) : base(firstName, lastName)
        {

        }

        public Worker(string firstName, string lastName,double wage) : base(firstName, lastName)
        {
            this.Wage = wage;
        }

        public Worker(string firstName, string lastName, double wage,double workedOutHours) : base(firstName, lastName)
        {
            this.Wage = wage;
            this.WorkedOutHours = workedOutHours;
        }

        public double CalculateWagePerHour()
        {
            double wagePerHour = Wage / WorkedOutHours;
            return wagePerHour;
        }

        public int CompareTo(object obj)
        {
            if (null == obj) return 1;

            Worker otherWorker = obj as Worker;
            if(otherWorker != null)
            {
                return otherWorker.Wage.CompareTo(this.Wage);
            }
            else
            {
                throw new ArgumentException("Object is not a worker!");
            }
        }

        public override string ToString()
        {
            return base.ToString() + " " + this.Wage;
        }
    }
}
