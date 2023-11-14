using System.Runtime.Serialization;

namespace Lesson2_6
{
    [Serializable]
    internal class NegativeNumberExeption : CalculatorExeption
    {
        public NegativeNumberExeption()
        {
        }

        public NegativeNumberExeption(string message) : base(message)
        {
        }
    }
}