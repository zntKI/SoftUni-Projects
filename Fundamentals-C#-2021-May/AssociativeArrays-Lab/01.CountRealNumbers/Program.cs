using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.CountRealNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<int, int> nums = new SortedDictionary<int, int>();
            var numsArray = Console.ReadLine().Split().Select(int.Parse).ToArray();
            for (int i = 0; i < numsArray.Length; i++)
            {
                if (!nums.ContainsKey(numsArray[i]))
                {
                    nums.Add(numsArray[i], 0);
                }
                nums[numsArray[i]]++;
            }
            foreach (var item in nums)
            {
                Console.WriteLine($"{item.Key} -> {item.Value}");
            }
        }
    }
}
