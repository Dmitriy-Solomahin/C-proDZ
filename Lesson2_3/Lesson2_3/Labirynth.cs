using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson2_3
{
    internal class Labirynth
    {
        //Доработайте приложение поиска пути в лабиринте, но на этот раз вам нужно определить сколько всего выходов имеется в лабиринте:
        
        

        public static int HasExit(int startI, int startJ, int[,] l)
        {
            int exit = 0;
            if( CheckStartPosition(startI, startJ, l))
            {
                var stack = new Stack<Tuple<int, int>>();
                stack.Push(new Tuple<int,int>(startI, startJ));

                while (stack.Count > 0)
                {
                    var pos = stack.Pop();
                    if (l[pos.Item1, pos.Item2] == 2) exit++;

                    l[pos.Item1, pos.Item2] = 1;

                    if (pos.Item2 > 0 && l[pos.Item1, pos.Item2 - 1] != 1) 
                        stack.Push(new Tuple<int, int>(pos.Item1, pos.Item2 - 1));//вверх
                    if (pos.Item1 > 0 && l[pos.Item1 - 1, pos.Item2] != 1)
                        stack.Push(new Tuple<int, int>(pos.Item1 - 1, pos.Item2));//влево
                    if (pos.Item2 + 1 < l.GetLength(1) && l[pos.Item1, pos.Item2 + 1] != 1)
                        stack.Push(new Tuple<int, int>(pos.Item1, pos.Item2 + 1));//вниз
                    if (pos.Item1 + 1 < l.GetLength(0) && l[pos.Item1 + 1, pos.Item2] != 1)
                        stack.Push(new Tuple<int, int>(pos.Item1 + 1, pos.Item2));//вправо
                }
            }
            return exit;
        }

        private static bool CheckStartPosition(int startI, int startJ, int[,] l)
        {
            if (l[startI, startJ] == 0) return true;
            else if (l[startI, startJ] == 2)
            {
                Console.WriteLine("вы находитесь на выходе");
                return true;
            }
            Console.WriteLine("Неверная точка старта");
            return false;
        }
    }
}
