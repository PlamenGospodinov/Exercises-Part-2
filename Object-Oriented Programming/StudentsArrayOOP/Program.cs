using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsArrayOOP
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            int num = Int32.Parse(input);
            Students[] list = new Students[num];
            string[] temp = new string[3];

            for(int i = 0; i < num; i++)
            {
                input = Console.ReadLine();
                temp = input.Split(' ');
                string firstName = temp[0].ToString().ToLower().ToUpperFirstLetter();
                string lastName = temp[1].ToString().ToLower().ToUpperFirstLetter();
                byte score = byte.Parse(temp[2]);

                list[i] = new Students(firstName + " " + lastName, score);
            }
            Array.Sort(list);
            PrintStudents(list);
        }

        static void PrintStudents(Students[] students)
        {
            foreach(Students st in students)
            {
                Console.WriteLine("{0} {1}",st.Name,st.Score);
            }
        }
    }

    class Students : IComparable
    {
        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private byte score;
        public byte Score
        {
            get { return score; }
            set { score = value; }
        }

        public Students(string name,byte score)
        {
            this.name = name;
            this.score = score;
        }

        public int CompareTo(object obj)
        {
            Students temp = (Students)obj;
            return score.CompareTo(temp.Score);
        }
    }

    public static class StringExtention
    {
        public static string ToUpperFirstLetter(this string source)
        {
            if (string.IsNullOrEmpty(source))
            {
                return string.Empty;
            }
            char[] letters = source.ToCharArray();
            letters[0] = char.ToUpper(letters[0]);
            return new string(letters);
        }
    }
}
