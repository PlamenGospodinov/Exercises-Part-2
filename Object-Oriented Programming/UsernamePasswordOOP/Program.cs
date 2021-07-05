using System;

namespace UsernamePasswordOOP
{
    class Program
    {
        static void Main(string[] args)
        {
            User user = new User();
            user.Username = Console.ReadLine();
            user.Password = Console.ReadLine();
        }
    }

    class User 
    {

        private string username;
        private string password;
        public User()
        {

        }

        public User(string username,string password)
        {
            this.username = username;
            this.password = password;
        }

        public string Username
        {
            get
            {
                return username;
            }
            set
            {
                if (value.Length <=3 || value == "")
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
    }
}
