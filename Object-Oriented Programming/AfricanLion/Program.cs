using System;

namespace AfricanLion
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

    public class AfricanLion : Lion
    {
        public AfricanLion(int weight,bool male) : base(weight, male)
        {

        }

        public override string ToString()
        {
            return string.Format("(AfricanLion, male {0}, weight: {1})",this.Weight,this.Male);
        }
    }

    public class Lion : Felidae
    {
        private int weight;

        public Lion(int weight, bool male) : base(male)
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
            AfricanLion lion = new AfricanLion(225, true);
            Console.WriteLine(lion.ToString()); 
        }
    }
}
