using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.BasicQueueOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
            int[] numss = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
            Queue<int> numbers = new Queue<int>();
            for (int i = 0; i < nums[0]; i++)
            {
                numbers.Enqueue(numss[i]);
            }
            for (int i = 0; i < nums[1]; i++)
            {
                numbers.Dequeue();
            }
            if (numbers.Contains(nums[2]))
            {
                Console.WriteLine("true");
            }
            else if (numbers.Count <= 0)
            {
                Console.WriteLine("0");
            }
            else if (!numbers.Contains(nums[2]))
            {
                Console.WriteLine(numbers.Min());
            }
        }
    }
}
