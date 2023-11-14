namespace Lesson2_6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool exit = true;

            while (exit)
            {
                //Доработайте класс калькулятора способным работать как с целочисленными так и с дробными числами. (возможно стоит задействовать перегрузку операций).
                //заменить Convert.ToDouble на собственный DoubleTryPars и обрабатываем ошибку
                //проверить что введенное число небыло отрицательное (вывести ошибку Exeption , отловить Catch)
                // сумма не может быть отрицательной (при делении и вычитании)

                var calc = new Calc();
                calc.MyEventHandler += Calc_MyEventHandler;
                double number1, number2 = 0;
                int symbol = 0;
                try
                {
                    Console.WriteLine("Enter first number");
                    CheckInput(Console.ReadLine() ?? "0", out number1);
                    Console.WriteLine("Enter second number");
                    CheckInput(Console.ReadLine() ?? "0", out number2);
                    Console.WriteLine("Select an action \n1. + \n2. - \n3. * \n4. /");
                    symbol = Convert.ToInt32(Console.ReadLine());
                }
                catch (CalculatorInputExeption ex)
                {
                    Console.WriteLine(ex.Message);
                    continue;
                }
                

                switch (symbol)
                {
                    case 1: calc.Sum(number1, number2); break;
                    case 2: 
                        try {calc.Sub(number1, number2); } 
                        catch(NegativeNumberExeption ex) {Console.WriteLine(ex.Message);} 
                        break;
                    case 3: calc.Multy(number1, number2); break;
                    case 4:
                        try {calc.Divide(number1, number2);}
                        catch (CalculatorDivideByZeroException ex) {Console.WriteLine(ex.Message);}
                        catch (CalculatorExeption ex) {Console.WriteLine(ex);}
                        catch (Exception ex) {Console.WriteLine(ex);}
                        break;
                }
                Console.WriteLine("Continue ?");
                Console.WriteLine("Press F to finish");

                if (Console.ReadKey().Key == ConsoleKey.F)
                {
                    exit = false;
                }
                Console.Clear();
            }



        }
        private static void CheckInput(string str, out double num)
        {
            num = DoubleTryPars(str);
            if (num < 0) {throw new CalculatorInputNegativeNumberExeption("Число меньше 0. Неиспользуй отрецательные значение!");}
        }

        private static double DoubleTryPars(string str)
        {
            try
            {
                double number = Convert.ToDouble(str);
                return number;
            }
            catch { throw new CalculatorInputDubleExeption("Невозможно конвертировать в число! Используй цыфры и ,"); }
        }

        private static void Calc_MyEventHandler(object? sender, EventArgs e)
        {
            if (sender is Calc)
            {
                double answ = ((Calc)sender).Result;
                if (answ < 0)
                {
                    throw new NegativeNumberExeption("Ответ отрецательный");
                }
                Console.WriteLine($"Answer: {answ}");
            }

        }
    }    
}