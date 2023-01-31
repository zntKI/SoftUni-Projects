using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.ListManipulationAdvanced
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> list = Console.ReadLine().Split().Select(int.Parse).ToList();
            string input = Console.ReadLine();
            int count = 0;
            while (input != "end")
            {
                string[] commandArgs = input.Split();
                string action = commandArgs[0];
                if (action == "Add")
                {
                    int n = Convert.ToInt32(commandArgs[1]);
                    list.Add(n);
                    count++;
                }
                else if (action == "Remove")
                {
                    int n = Convert.ToInt32(commandArgs[1]);
                    list.Remove(n);
                    count++;
                }
                else if (action == "RemoveAt")
                {
                    int n = Convert.ToInt32(commandArgs[1]);
                    list.RemoveAt(n);
                    count++;
                }
                else if (action == "Insert")
                {
                    int n = Convert.ToInt32(commandArgs[1]);
                    int i = Convert.ToInt32(commandArgs[2]);
                    list.Insert(i, n);
                    count++;
                }
                else if (action == "Contains")
                {
                    int n = Convert.ToInt32(commandArgs[1]);
                    if (list.Contains(n))
                    {
                        Console.WriteLine("Yes");
                    }
                    else
                    {
                        Console.WriteLine("No such number");
                    }
                }
                else if (action == "PrintEven")
                {
                    for (int i = 0; i < list.Count; i++)
                    {
                        if (list[i] % 2 == 0)
                        {
                            Console.Write(list[i] + " ");
                        }
                    }
                    Console.WriteLine();
                }
                else if (action == "PrintOdd")
                {
                    for (int i = 0; i < list.Count; i++)
                    {
                        if (list[i] % 2 != 0)
                        {
                            Console.Write(list[i] + " ");
                        }
                    }
                    Console.WriteLine();
                }
                else if (action == "GetSum")
                {
                    Console.WriteLine(list.Sum());
                }
                else if (action == "Filter")
                {
                    int n = Convert.ToInt32(commandArgs[2]);
                    for (int i = 0; i < list.Count; i++)
                    {
                        if (commandArgs[1] == "<" && list[i] < n)
                        {
                            Console.Write(list[i] + " ");
                        }
                        else if (commandArgs[1] == ">" && list[i] > n)
                        {
                            Console.Write(list[i] + " ");
                        }
                        else if (commandArgs[1] == ">=" && list[i] >= n)
                        {
                            Console.Write(list[i] + " ");
                        }
                        else if (commandArgs[1] == "<=" && list[i] <= n)
                        {
                            Console.Write(list[i] + " ");
                        }
                    }
                    Console.WriteLine();
                }
                input = Console.ReadLine();
            }
            if (count > 0)
            {
                Console.Write(string.Join(' ', list));
            }
        }
    }
}
