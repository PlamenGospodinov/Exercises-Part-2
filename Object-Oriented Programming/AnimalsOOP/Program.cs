using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalsOOP
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Animal> list = new List<Animal>();
            string input = Console.ReadLine();
            int n = Int32.Parse(input);
            for(int i = 0; i < n; i++)
            {
                input = Console.ReadLine();
                string[] array = input.Split(' ');
                string type = array[0];
                string name = array[1];
                int age = Int32.Parse(array[2]);
                string gender = array[3];
                switch (type.ToLower())
                {
                    case "cat":
                        if(gender.ToLower() == "male")
                        {
                            list.Add(new Cat(age, name, Gender.Male));
                        }
                        else
                        {
                            list.Add(new Cat(age, name, Gender.Female));
                        }
                        break;
                    case "tomcat":
                        list.Add(new Tomcat(age, name));
                        break;
                    case "kitten":
                        list.Add(new Kitten(age, name));
                        break;
                    case "frog":
                        if (gender.ToLower() == "male")
                        {
                            list.Add(new Frog(age, name, Gender.Male));
                        }
                        else
                        {
                            list.Add(new Frog(age, name, Gender.Female));
                        }
                        break;
                    case "dog":
                        if (gender.ToLower() == "male")
                        {
                            list.Add(new Dog(age, name, Gender.Male));
                        }
                        else
                        {
                            list.Add(new Dog(age, name, Gender.Female));
                        }
                        break;
                }
            }

            foreach(Animal animal in list)
            {
                Console.Write(animal.Name.ToString().ToLower().ToUpperFirstLetter());
                Console.Write(" " + animal.Age + " " + animal.MakeNoise());
                Console.WriteLine();
            }

            Console.ReadLine();
        }
    }

    public enum Gender
    {
        Male,
        Female
    }

    class Animal : IComparable
    {
        public int Age { get; set; }
        public string Name { get; set; }
        public Gender Gender { get; set; }

        public Animal(int age,string name,Gender gender)
        {
            this.Age = age;
            this.Name = name;
            this.Gender = gender;
        }

        public int CompareTo(object obj)
        {
            if (null == obj) return 1;

            Animal otherAnimal = obj as Animal;
            if(otherAnimal != null)
            {
                return this.Name.CompareTo(otherAnimal.Name);
            }
            else
            {
                throw new ArgumentException("Object is not a Animal");
            }
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;

            if (this.GetType() != obj.GetType()) return false;

            Animal otherAnimal = (Animal)obj;

            return this.Name.Equals(otherAnimal.Name);
        }

        public override int GetHashCode()
        {
            return this.Name.GetHashCode();
        }

        public override string ToString()
        {
            return this.Name;
        }

        public virtual string MakeNoise()
        {
            return "AArrghh!";
        }

        public static string IdentifyAnimal(string sound)
        {
            switch (sound)
            {
                case "Miauuu!":
                    return "Cat!";
                case "Miau!":
                    return "Kitten!";
                case "Kwak!":
                    return "Frog!";
                case "Miauuuuuu!":
                    return "Tomcat!";
                case "Wooof!":
                    return "Dog!";
                default:
                    throw new ArgumentException("Cannot recognise the animal!");
            }
        }
    }

    class Cat : Animal
    {
        public Cat(int age,string name,Gender gender) : base(age,name,gender)
        {

        }

        public override string MakeNoise()
        {
            return "Miauuu!";
        }
    }

    class Dog : Animal
    {
        public Dog(int age, string name, Gender gender) : base(age, name, gender)
        {

        }

        public override string MakeNoise()
        {
            return "Wooof!";
        }
    }

    class Frog : Animal
    {
        public Frog(int age, string name, Gender gender) : base(age, name, gender)
        {

        }

        public override string MakeNoise()
        {
            return "Kwak!";
        }
    }

    class Tomcat : Animal
    {
        public Tomcat(int age, string name) : base(age, name, Gender.Male)
        {

        }

        public override string MakeNoise()
        {
            return "Miauuuuuu!";
        }
    }

    class Kitten : Animal
    {
        public Kitten(int age, string name) : base(age, name, Gender.Female)
        {

        }

        public override string MakeNoise()
        {
            return "Miau!";
        }
    }

    public static class StringExtension
    {
        public static string ToUpperFirstLetter(this string source)
        {
            if (string.IsNullOrEmpty(source)) return string.Empty;

            char[] letters = source.ToCharArray();
            letters[0] = char.ToUpper(letters[0]);
            return new string(letters);
        }
    } 

}
