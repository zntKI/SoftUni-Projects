using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.GaussTrick
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> nums = Console.ReadLine().Split().Select(int.Parse).ToList();
            List<int> result = new List<int>();
            // 1 2 3 4 5
            for (int i = 0; i < nums.Count / 2; i++)
            {
                int left = nums[i];
                int right = nums[nums.Count - 1 - i];
                result.Add(left + right);
            }
            if (nums.Count % 2 != 0)
            {
                result.Add(nums[nums.Count / 2]);
            }
            Console.Write(string.Join(" ", result));
        }
    }
}
