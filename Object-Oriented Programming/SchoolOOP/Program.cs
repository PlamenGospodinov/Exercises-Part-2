using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolOOP
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> input = ReadInput();
            List<Person> people = ParseInput(input);

            people.Sort();
            people.ForEach(p => Console.WriteLine(p));
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

        private static List<Person> ParseInput(List<string> input)
        {
            const Int32 firstNameIndex = 1, lastNameIndex = 2,
                studentNumberIndex = 3, disciplinesStartIndex = 3;
            Char[] separators = new Char[] { ' ' };
            List<Person> people = new List<Person>();

            foreach (String line in input)
            {
                String[] words = line.Split(separators, StringSplitOptions.RemoveEmptyEntries);

                switch (words[0].ToLower())
                {
                    case "teacher":
                        List<Discipline> disciplines = ParseDisciplines(words, disciplinesStartIndex);
                        Teacher teacher = new Teacher(words[firstNameIndex], words[lastNameIndex], disciplines);
                        people.Add(teacher);
                        break;
                    case "student":
                        Student student = new Student(words[firstNameIndex], words[lastNameIndex], Int32.Parse(words[studentNumberIndex]));
                        people.Add(student);
                        break;
                    default:
                        throw new ArgumentException("Unknown type!");
                }
            }
            return people;
        }

        private static List<Discipline> ParseDisciplines(String[] words,Int32 startIndex)
        {
            List<Discipline> disciplines = new List<Discipline>();

            for(int i = startIndex; i < words.Length; i++)
            {
                Discipline discipline = new Discipline(words[i]);
                disciplines.Add(discipline);
            }

            return disciplines;
        }

        class Class : IComparable, IEnumerable
        {
            private List<Student> students;
            public String ID { get; set; }

            public Class(string id)
            {
                this.ID = id;
                this.students = new List<Student>();
            }

            public void Add(Student student)
            {
                if(student == null)
                {
                    throw new NullReferenceException();
                }

                if (this.students.Contains(student))
                {
                    throw new ArgumentException("The class has a student with the same number!");
                }

                this.students.Add(student);
            }

            public bool Contains(Student student)
            {
                if(student == null)
                {
                    throw new NullReferenceException();
                }

                return this.students.Contains(student);
            }

            public void Remove(Student student)
            {
                if (student == null)
                {
                    throw new NullReferenceException();
                }

                if (!this.Contains(student))
                {
                    throw new Exception("Class does not contain a student with this number!");
                }

                this.students.Remove(student);
            }

            public override bool Equals(object obj)
            {
                if(obj == null)
                {
                    return false;
                }

                if(this.GetType() != obj.GetType())
                {
                    return false;
                }

                Class otherClass = (Class)obj;

                return this.ID.Equals(otherClass.ID);
            }

            public override string ToString()
            {
                return this.ID;
            }

            public override int GetHashCode()
            {
                return this.ID.GetHashCode();
            }

            public int CompareTo(object obj)
            {
                if (null == obj) return 1;

                Class otherClass = obj as Class;

                if (otherClass != null)
                {
                    return this.ID.CompareTo(otherClass.ID);
                }
                else
                {
                    throw new ArgumentException("Object is not a Cell");
                }
            }

            public IEnumerator GetEnumerator()
            {
                return new StudentEnum(this.students);
            }
        }

        class StudentEnum : IEnumerator
        {
            List<Student> students;

            int position = -1;

            public StudentEnum(List<Student> students)
            {
                this.students = students;
            }

            public bool MoveNext()
            {
                position++;
                return (position < students.Count);
            }

            public void Reset()
            {
                position = -1;
            }

            object IEnumerator.Current
            {
                get
                {
                    return Current;
                }
            }

            public Student Current
            {
                get
                {
                    try
                    {
                        return students[position];
                    }
                    catch(IndexOutOfRangeException)
                    {
                        throw new InvalidOperationException();
                    }
                }
            }
        }

        class Discipline
        {
            const Int32 defaultNumberOfLectures = 25;
            const Int32 defaultNumberOfExercises = 25;

            public string Name { get; set; }
            public Int32 NumberOfLectures { get; set; }
            public Int32 NumberOfExercises { get; set; }

            public Discipline(string name) : this(name, defaultNumberOfLectures, defaultNumberOfExercises)
            {

            }

            public Discipline(string name,Int32 numberOfLectures,Int32 numberOfExercises)
            {
                this.Name = name;
                this.NumberOfLectures = numberOfLectures;
                this.NumberOfExercises = numberOfExercises;
            }

            public override string ToString()
            {
                return this.Name;
            }

        }

        class Person : IComparable
        {
            public String FirstName { get; set; }
            public String LastName { get; set; }

            public Person(string firstName,string lastName)
            {
                this.FirstName = firstName;
                this.LastName = lastName;
            }

            public override string ToString()
            {
                return String.Format("{0} {1}", this.FirstName, this.LastName);
            }

            public int CompareTo(object obj)
            {
                if (null == obj) return 1;

                Person otherPerson = obj as Person;

                if(otherPerson != null)
                {
                    Int32 firstNameComparisson = this.FirstName.CompareTo(otherPerson.FirstName);
                    if(firstNameComparisson == 0)
                    {
                        firstNameComparisson = this.LastName.CompareTo(otherPerson.LastName);
                    }

                    return firstNameComparisson;
                }
                else
                {
                    throw new ArgumentException("Object is not a person");
                }
            }

            public override bool Equals(object obj)
            {
                if (obj == null) return false;

                if (this.GetType() != obj.GetType()) return false;

                Person otherPerson = (Person)obj;

                bool firstNamesAreEqual = this.FirstName == otherPerson.FirstName;
                bool lastNamesAreEqual = this.LastName == otherPerson.LastName;

                return firstNamesAreEqual && lastNamesAreEqual;
            }

            public override int GetHashCode()
            {
                return (this.FirstName + this.LastName).GetHashCode();
            }
        }

        class Teacher : Person
        {
            public List<Discipline> Disciplines { get; set; }

            public Teacher(string firstName,string lastName) : base(firstName, lastName)
            {
                this.Disciplines = new List<Discipline>();
            }

            public Teacher(string firstName,string lastName,List<Discipline> disciplines) : base(firstName,lastName)
            {
                this.Disciplines = disciplines;
            }

            public override string ToString()
            {
                return String.Format("{0} {1}", base.ToString(), this.ConvertDisciplineToString());
            }

            private string ConvertDisciplineToString()
            {
                StringBuilder outputString = new StringBuilder();
                foreach(Discipline discipline in this.Disciplines)
                {
                    outputString.Append(discipline.ToString() + " ");
                }

                return outputString.ToString().Trim();
            }
        }

        class Student : Person
        {
            public Int32 Number { get; set; }
            public Student(string firstName,string lastName,Int32 number) : base(firstName, lastName)
            {
                this.Number = number;
            }

            public override bool Equals(object obj)
            {
                if (obj == null) return false;

                if (this.GetType() != obj.GetType()) return false;

                Student otherPerson = (Student)obj;
                return this.Number.Equals(otherPerson.Number);
            }

            public override int GetHashCode()
            {
                return this.Number.GetHashCode();
            }

            public override string ToString()
            {
                return String.Format("{0} {1}", base.ToString(), this.Number);
            }
        }
    }
}
