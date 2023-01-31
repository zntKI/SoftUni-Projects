using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.PrintEvenNums
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
            Queue<int> evenNums = new Queue<int>();
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] % 2 == 0)
                {
                    evenNums.Enqueue(nums[i]);
                }
            }
            Console.WriteLine(string.Join(", ", evenNums));
        }
    }
}
