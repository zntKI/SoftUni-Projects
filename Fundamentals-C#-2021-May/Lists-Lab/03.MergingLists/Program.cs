using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.MergingLists
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> nums1 = Console.ReadLine().Split().Select(int.Parse).ToList();
            List<int> nums2 = Console.ReadLine().Split().Select(int.Parse).ToList();
            List<int> result = new List<int>();
            int maxCount = Math.Max(nums1.Count, nums2.Count);
            for (int i = 0; i < maxCount; i++)
            {
                if (i < nums1.Count)
                {
                    result.Add(nums1[i]);
                }
                if (i < nums2.Count)
                {
                    result.Add(nums2[i]);
                }
            }
            Console.Write(string.Join(' ', result));
        }
    }
}
