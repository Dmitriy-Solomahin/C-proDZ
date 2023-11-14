using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson2_6
{
    internal class CalculateOperationCauseOverflowException : CalculatorExeption
    {
        public CalculateOperationCauseOverflowException()
        {

        }
        public CalculateOperationCauseOverflowException(string message) : base(message)
        {

        }
    }
}
