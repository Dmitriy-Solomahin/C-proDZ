namespace Lesson2_6
{
    internal class CalculatorExeption : Exception
    {
        public CalculatorExeption()
        {

        }
        public CalculatorExeption(string message) : base(message)
        {

        }
    }
}