using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualMethodsExample
{
    public abstract class Felidae
    {
        private bool male;
        public Felidae() : this(true) { }

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

        public abstract void CatchPray(object pray);
    }

    public interface Reproducible<T> where T : Felidae
    {
        T[] Reproduce(T mate);
    }

    public class Lion : Felidae,Reproducible<Lion>
    {
        private int weight;

        public Lion(bool male,int weight) : base(male)
        {
            this.weight = weight;
        }

        Lion[] Reproducible<Lion>.Reproduce(Lion mate)
        {
            return new Lion[] { new Lion(true, 12), new Lion(false, 10) };
        }

        public override void CatchPray(object pray)
        {
            Console.WriteLine("Lion.CatchPray");
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

    public class AfricanLion : Lion
    {
        public AfricanLion(bool male, int weight) : base(male, weight)
        {

        }

        public override string ToString()
        {
            return string.Format("(AfricanLion, male {0}, weight: {1})", this.Weight, this.Male);
        }

        public override void CatchPray(object pray)
        {
            Console.WriteLine("AfricanLion.CatchPray");
            Console.WriteLine("Calling base.CatchPray");
            Console.Write("\t");
            base.CatchPray(pray);
            Console.WriteLine(".. end of call");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Lion lion = new Lion(true, 80);
            lion.CatchPray(null);

            AfricanLion lionAfrica = new AfricanLion(true, 120);
            lionAfrica.CatchPray(null);

            Lion lionUnknown = new AfricanLion(true, 150);
            lionUnknown.CatchPray(null);
            Console.ReadLine();
        }
    }
}
