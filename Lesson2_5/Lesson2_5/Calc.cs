using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson2_5
{
    internal class Calc : ICalc
    {
        public double Result { get; set; } = 0D;
        Stack<double> LastResult { get; set; } = new Stack<double>();

        public event EventHandler<EventArgs> MyEventHandler;

        void PrintResult()
        {
            MyEventHandler?.Invoke(this, new EventArgs());
        }

        public string CancelAction()
        {
            if (LastResult.TryPop(out double res)) { 
                Result = res;
                PrintResult();
                return "Последнее действие отменено";
            }
            return "Невозможно отменить последние действие";
        }

        public void ResetCalculation()
        {
            LastResult.Clear();
            Result = 0;
        }

        public void Div(int x)
        {
            LastResult.Push(Result);
            Result /= x;
            PrintResult();
        }

        public void Mult(int x)
        {
            LastResult.Push(Result);
            Result *= x;
            PrintResult();
        }
        public void Sub(int x)
        {
            LastResult.Push(Result);
            Result -= x;
            PrintResult();
        }

        public void Sum(int x)
        {
            LastResult.Push(Result);
            Result += x;
            PrintResult();
        }
    }
}
