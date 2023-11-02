using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson2_5
{
    internal interface ICalc
    {
        public double Result {get; set;}
        public event EventHandler<EventArgs> MyEventHandler;
        void Sum(int x);
        void Sub(int x);
        void Mult(int x);
        void Div(int x);
        string CancelAction();
    }
}
