using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Дан двумерный массив.
            // [7 3 2] [4 9 6] [1 8 5]
            // Отсортировать данные в нем по возрастанию.
            // [1 2 3] [4 5 6] [7 8 9]
            // Вывести результат на печать.

            int[,] a = { { 7, 3, 2 }, { 4, 9, 6 }, { 1, 8, 5 } };
            int y = a.GetLength(0);
            int x = a.GetLength(1);
            int[] sort = new int[x * y];
            int counter = 0;
            for (int i = 0; i < y; i++)
            {
                for (int j = 0; j < x; j++)
                {
                    sort[counter] = a[i, j];
                    counter++;
                }
            }
            Array.Sort(sort);
            counter = 0;
            for (int i = 0; i < y; i++)
            {
                for (int j = 0; j < x; j++)
                {
                    a[i, j] = sort[counter];
                    counter++;
                    Console.Write(a[i, j] + " ");
                }
                Console.WriteLine();
            }
        }

    }
}
