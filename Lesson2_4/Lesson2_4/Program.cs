namespace Lesson2_4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Дан массив и число. Найдите три числа в массиве сумма которых равна искомому числу.
            //Подсказка: если взять первое число в массиве, можно ли найти в оставшейся его части два числа равных по сумме первому.

            int[] array = { 2, 5, 7, 1, 15, 4, 9 };
            int number = 10;

            //FindTrioEqualTarget(array, number);
            FindTrioEqualTarget2(array, number);

        }

        private static void FindTrioEqualTarget(int[] array, int number)
        {
            
            for (int i = 0; i < array.Length - 2; i++)
            {
                for (int j = 0; j < array.Length - 1; j++)
                {
                    for (int k = 0; k < array.Length; k++)
                    {
                        if ((array[i] + array[j] + array[k]) == number) {
                            Console.WriteLine($" { array[i]} + {array[j]} + {array[k]} = {number} ");
                        } 
                    }
                }
            }
            Console.WriteLine($"во множестве нет 3х чисел сумма которых равна {number}");
        }


        private static void FindTrioEqualTarget2(int[] array, int number)
        {
            var sortList = array.OrderBy(x => x).Where(x => x < number - array.Min()).ToList();
            for (int i = 0; i < sortList.Count - 2; i++)
            {
                for (int j = i+1; j < sortList.Count - 1; j++)
                {
                    int x = number - (sortList[i] + sortList[j]);
                    if (sortList.Contains(x))
                    {
                        Console.WriteLine($" {sortList[i]} + {sortList[j]} + {x} = {number} ");
                    }
                }
            }
            Console.WriteLine($"во множестве нет 3х чисел сумма которых равна {number}");
        }

    }
}