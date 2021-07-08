using System;
using System.Text;

namespace Advertising
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();
            string[] phrases = new string[] {"Продуктът е отличен!",
                       "Това е страхотен продукт",
                       "Постоянно ползвам този продукт.",
                       "Това е най-добрият продукт от тази категория!"};
            string[] phrases2 = new string[] {"Вече се чувствам добре.",
                       "Успях да се променя.",
                       "Той направи чудо.",
                       "Опитайте и вие.Аз съм много доволна!"};
            string[] names = new string[] {"Диана",
                       "Ивана","Петя","Гергана",
                       "Рени","Йони","Деница"};
            string[] lastNames = new string[] {"Великова",
                       "Узунска","Христова",
                       "Трифонова","Мирославова",
                       "Иванова","Георгиева"};
            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine("{0} {1}\n-- {2} {3}",phrases[rnd.Next(4)],phrases2[rnd.Next(4)],names[rnd.Next(7)],lastNames[rnd.Next(7)]);
        }
    }
}
