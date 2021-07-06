using System;

namespace EnumOOP
{
    class Program
    {
        static void Main(string[] args)
        {
            User user = new User();
            user.Username = Console.ReadLine();
            user.Password = Console.ReadLine();
            Console.WriteLine(user.ID);
            User secondUser = new User("Kiki", "124Kik", Race.Marsian);
            Console.WriteLine(secondUser.Weight);
        }
    }

    enum Race
    {
        Human,
        Marsian,
        Namibian,
        Veloran
    }

    class User
    {
        private int weight;
        public static int currentID;
        public readonly int ID;
        private string username;
        private string password;
        private Race race;
        public User()
        {
            currentID++;
            ID = currentID;
        }

        public User(string username, string password,Race race)
        {
            this.username = username;
            this.password = password;
            this.race = race;
            if(race == Race.Marsian)
            {
                weight = 180;
            }
            else if(race == Race.Human)
            {
                weight = 80;
            }
            else if(race == Race.Namibian)
            {
                weight = 90;
            }
            else if(race == Race.Veloran)
            {
                weight = 120;
            }
            else
            {
                weight = 100;
            }
            currentID++;
            ID = currentID;
        }

        public string Username
        {
            get
            {
                return username;
            }
            set
            {
                if (value.Length <= 3 || value == "")
                {
                    Console.WriteLine("The username you set is not proper!");
                }
                else
                {
                    value = username;
                }
            }
        }

        public string Password
        {
            get
            {
                return password;
            }
            set
            {
                if (value.Length <= 3 || value == "")
                {
                    Console.WriteLine("The password you set is not proper!");
                }
                else
                {
                    value = password;
                }
            }
        }

        public Race Race { get; set; }

        public int Weight { get; set; }
    }
}

