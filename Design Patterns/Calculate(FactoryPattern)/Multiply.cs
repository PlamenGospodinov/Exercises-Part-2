﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculate_FactoryPattern_
{
    class Multiply : ICalculate
    {
        public void Calculate(double a, double b)
        {
            Console.WriteLine("a*b = {0}",a*b);
        }
    }
}
