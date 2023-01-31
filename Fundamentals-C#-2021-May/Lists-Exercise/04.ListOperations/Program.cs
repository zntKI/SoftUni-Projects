using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.ListOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> list = Console.ReadLine().Split().Select(int.Parse).ToList();
            string input = Console.ReadLine();
            while (input != "End")
            {
                string[] arr = input.Split();
                if (arr[0] == "Add")
                {
                    int n = int.Parse(arr[1]);
                    list.Add(n);
                }
                else if (arr[0] == "Insert")
                {
                    int n = int.Parse(arr[1]);
                    int i = int.Parse(arr[2]);
                    if (i < 0 || i >= list.Count)
                    {
                        Console.WriteLine("Invalid index");
                        input = Console.ReadLine();
                        continue;
                    }
                    list.Insert(i, n);
                }
                else if (arr[0] == "Remove")
                {
                    int i = int.Parse(arr[1]);
                    if (i < 0 || i >= list.Count)
                    {
                        Console.WriteLine("Invalid index");
                        input = Console.ReadLine();
                        continue;
                    }
                    list.RemoveAt(i);
                }
                else if (arr[1] == "left")
                {
                    int n = int.Parse(arr[2]);
                    for (int i = 1; i <= n; i++)
                    {
                        int firstElement = list[0];
                        for (int j = 0; j < list.Count - 1; j++)
                        {
                            list[j] = list[j + 1];
                        }
                        list[list.Count - 1] = firstElement;
                    }
                }
                else if (arr[1] == "right")
                {
                    int n = int.Parse(arr[2]);
                    for (int i = 1; i <= n; i++)
                    {
                        // 5 12 42 95 32 1
                        int lastElement = list[list.Count - 1];
                        for (int j = list.Count - 2; j >= 0; j--)
                        {
                            list[j + 1] = list[j];
                        }
                        list[0] = lastElement;
                    }
                }
                input = Console.ReadLine();
            }
            Console.WriteLine(string.Join(' ', list));
        }
    }
}
