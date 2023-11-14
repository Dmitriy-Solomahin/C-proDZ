namespace Lesson2_6
{
    internal interface ICalc
    {
        double Result { get; set; }
        void Sum(double x, double y);
        void Sub(double x, double y);
        void Multy(double x, double y);
        void Divide(double x, double y);
        void CancelLast();
        event EventHandler<EventArgs> MyEventHandler;

    }
}