using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplatePattern
{
    public class ExcelFile : DataProcessor
    {
        
        public override void ReadData()
        {
            Console.WriteLine("Reads data from excel file");
        }

        public override void ProcessData()
        {
            Console.WriteLine("Processes data from excel file");
        }

        
    }
}
