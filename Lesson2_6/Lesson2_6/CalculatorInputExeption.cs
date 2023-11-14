using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson2_6
{
    internal class CalculatorInputExeption : CalculatorExeption
    {
        public CalculatorInputExeption() { }
        public CalculatorInputExeption(string masseg) : base(masseg) { }
    }
}
