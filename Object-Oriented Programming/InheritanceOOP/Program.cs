using System;

namespace InheritanceOOP
{
    public class Felidae
    {
        private bool male;

        public Felidae() : this(true)
        {

        }

        public Felidae(bool male)
        {
            this.male = male;
        }

        public bool Male
        {
            get
            {
                return male;
            }
            set
            {
                this.male = value;
            }
        }
    }

    public class Lion : Felidae
    {
        private int weight;

        public Lion(int weight,bool male) : base(male)
        {
            this.weight = weight;
        }

        public int Weight
        {
            get
            {
                return weight;
            }
            set
            {
                this.weight = value;
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Lion lion = new Lion(240, true);
            Console.WriteLine("The lion is male: " + lion.Male);
        }
    }
}
