using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkerOOP
{
    class Program
    {
        static void Main(string[] args)
        {

            List<string> input = ReadInput();
            List<Worker> workers = ParseInput(input);

            workers.ForEach(p => Console.WriteLine("{0} {1}", p, p.CalculateWagePerHour()));
        }

        private static List<string> ReadInput()
        {
            List<string> input = new List<string>();
            Int32 numberOfLines;

            string firstLineOfInput = Console.ReadLine();
            numberOfLines = Int32.Parse(firstLineOfInput);

            for(int lineCounter = 0;lineCounter < numberOfLines; lineCounter++)
            {
                string line = Console.ReadLine();
                input.Add(line);
            }

            return input;
        }

        private static List<Worker> ParseInput(List<string> input)
        {
            const Int32 firstNameIndex = 0,lastNameIndex = 1,wageIndex = 2,workerHours = 3;
            Char[] separators = new Char[] { ' ' };
            List<Worker> workers = new List<Worker>();
            foreach(String line in input)
            {
                String[] words = line.Split(separators, StringSplitOptions.RemoveEmptyEntries);

                Worker worker = new Worker(words[firstNameIndex], words[lastNameIndex], Decimal.Parse(words[wageIndex]), Double.Parse(words[workerHours]));
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
            if(obj == null) return false;
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
        public Decimal Wage { get; set; }
        public double WorkedOutHours { get; set; }

        public Worker(string firstName,string lastName) : base(firstName, lastName)
        {

        }

        public Worker(string firstName,string lastName,Decimal wage,double workedOutHours) : this(firstName, lastName)
        {
            this.Wage = wage;
            this.WorkedOutHours = workedOutHours;
        }

        public Decimal CalculateWagePerHour()
        {
            Decimal wagePerHour = Wage / Convert.ToDecimal(WorkedOutHours);
            return wagePerHour;
        }
    }
}
