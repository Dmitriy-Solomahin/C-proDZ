using System.Runtime.Serialization;

namespace Lesson2_6
{
    [Serializable]
    internal class CalculatorDivideByZeroException : CalculatorExeption
    {
        public CalculatorDivideByZeroException()
        {
        }

        public CalculatorDivideByZeroException(string message) : base(message)
        {
        }
    }
}