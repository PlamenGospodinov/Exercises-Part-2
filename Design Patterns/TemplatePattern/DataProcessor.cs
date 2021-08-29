using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplatePattern
{
    public abstract class DataProcessor
    {
        public void ReadProcessAndSave()
        {
            ReadData();
            ProcessData();
            SaveData();
        }

        public abstract void ReadData();

        public abstract void ProcessData();

        public void SaveData()
        {
            Console.WriteLine("Save data to DB");
        }
    }
}
