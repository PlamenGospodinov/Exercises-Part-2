using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactoryPattern
{
    interface IFirst
    {
        string Name();
    }

    interface ILeast
    {
        string Name();
    }

    class ProductOne : IFirst
    {
        public string Name()
        {
            return "ProductOne";
        }
    }

    class ProductTwo : ILeast
    {
        public string Name()
        {
            return "ProductTwo";
        }
    }

    enum MANUFACTURERS
    {
        ManufacturerOne,
        ManufacturerTwo,
        ManufacturerThree
    }

    interface IProductFactory
    {
        IFirst GetFirst();
        ILeast GetLeast();
    }

    class ManufacturerOneFactory : IProductFactory
    {
        public IFirst GetFirst()
        {
            return new ProductOne();
        }

        public ILeast GetLeast()
        {
            return new ProductTwo();
        }
    }

    class ManufacturerTwoFactory : IProductFactory
    {
        public IFirst GetFirst()
        {
            return new ProductOne();
        }

        public ILeast GetLeast()
        {
            return new ProductTwo();
        }
    }

    class ManufacturerThreeFactory : IProductFactory
    {
        public IFirst GetFirst()
        {
            return new ProductOne();
        }

        public ILeast GetLeast()
        {
            return new ProductTwo();
        }
    }

    class ProductTypeChecher
    {
        IProductFactory factory;
        MANUFACTURERS manu;
        public ProductTypeChecher(MANUFACTURERS m)
        {
            manu = m;
        }

        public void CheckProducts()
        {
            switch (manu)
            {
                case MANUFACTURERS.ManufacturerOne:
                    factory = new ManufacturerOneFactory();
                    break;
                case MANUFACTURERS.ManufacturerTwo:
                    factory = new ManufacturerTwoFactory();
                    break;
                case MANUFACTURERS.ManufacturerThree:
                    factory = new ManufacturerThreeFactory();
                    break;
            }

            Console.WriteLine(manu.ToString() + ":\nFirst Product: " +
                factory.GetFirst().Name() + ":\nLeast Product: " +
                factory.GetLeast().Name());
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
