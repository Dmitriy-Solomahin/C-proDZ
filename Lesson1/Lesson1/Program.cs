using System;
using System.Collections.Generic;

namespace Lesson1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            if (args.Length >= 3 && args.Length % 2 == 1)
            {
                List<int> nums = new List<int>();
                List<string> operations = new List<string>();
                for (int i = 0;i < args.Length; i++)
                {
                    if(i % 2 == 0)
                    {
                        nums.Add(int.Parse(args[i]));
                    }
                    if (i % 2 == 1)
                    {
                        operations.Add(args[i]);
                    }
                }

                for (int i = 0; i < operations.Count; i++)
                {
                    if (operations[i]== "*" || operations[i]== "/")
                    {
                        if (operations[i] == "/")
                        {
                            nums[i] = nums[i] / nums[i+1];
                            nums.RemoveAt(i + 1);
                            operations.RemoveAt(i);
                            i--;
                        }
                        else if (operations[i] == "*")
                        {
                            nums[i] = nums[i] * nums[i + 1];
                            nums.RemoveAt(i + 1);
                            operations.RemoveAt(i);
                            i--;
                        }
                    }
                }
                for (int i = 0; i < operations.Count; i++)
                {
                    if (operations[i] == "+" || operations[i] == "-")
                    {
                        if (operations[i] == "+")
                        {
                            nums[i] = nums[i] + nums[i + 1];
                            nums.RemoveAt(i + 1);
                            operations.RemoveAt(i);
                            i--;
                        }
                        else if (operations[i] == "-")
                        {
                            nums[i] = nums[i] - nums[i + 1];
                            nums.RemoveAt(i + 1);
                            operations.RemoveAt(i);
                            i--;
                        }
                    }
                }
                Console.WriteLine("Результат выполнения операции равен " + nums[0]);
            }
            else { 
                Console.WriteLine("Для использования программы введите: число знак(+-/*) число");
            }
        }
    }
}
