using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson2_6
{
    internal class CalculatorInputNegativeNumberExeption : CalculatorInputExeption
    {
        public CalculatorInputNegativeNumberExeption() { }
        public CalculatorInputNegativeNumberExeption(string masseg) : base(masseg) { }
    }
}
