using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson2_6
{
    internal class CalculatorInputDubleExeption : CalculatorInputExeption
    {
        public CalculatorInputDubleExeption() { }
        public CalculatorInputDubleExeption(string masseg) : base(masseg) { }
    }
}
