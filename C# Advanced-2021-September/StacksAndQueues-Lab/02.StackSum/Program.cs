using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.StackSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
            Stack<int> numbers = new Stack<int>();
            for (int i = 0; i < nums.Length; i++)
            {
                numbers.Push(nums[i]);
            }
            string input = Console.ReadLine();
            while (input.ToLower() != "end")
            {
                string[] command = input.Split(" ");
                if (command[0].ToLower() == "add")
                {
                    numbers.Push(int.Parse(command[1]));
                    numbers.Push(int.Parse(command[2]));
                }
                else if (command[0].ToLower() == "remove")
                {
                    int count = int.Parse(command[1]);
                    if (count > numbers.Count || count <= 0)
                    {
                        input = Console.ReadLine();
                        continue;
                    }
                    for (int i = 0; i < count; i++)
                    {
                        numbers.Pop();
                    }
                }
                input = Console.ReadLine();
            }
            int sum = 0;
            foreach (var item in numbers)
            {
                sum += item;
            }
            Console.WriteLine($"Sum: {sum}");
        }
    }
}
