using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplatePattern
{
    class Program
    {
        static void Main(string[] args)
        {
            DataProcessor obj1 = new ExcelFile();
            obj1.ReadProcessAndSave();

            TextFile obj2 = new TextFile();
            obj2.ReadProcessAndSave();
        }
    }
}
