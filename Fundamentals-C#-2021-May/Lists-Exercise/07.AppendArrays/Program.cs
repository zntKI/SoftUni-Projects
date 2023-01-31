using System;
using System.Linq;
using System.Collections.Generic;

namespace _07.AppendArrays
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] nums = Console.ReadLine().Split("|", StringSplitOptions.RemoveEmptyEntries);
            string all = "";
            string allSecond = "";
            for (int i = nums.Length - 1; i >= 0; i--)
            {
                all = nums[i];
                for (int j = 0; j < all.Length; j++)
                {
                    if (all[j] == ' ')
                    {
                        all = all.Remove(j, 1);
                        j--;
                    }
                }
                allSecond += all;
            }
            for (int i = 0; i < allSecond.Length; i+=2)
            {
                if (i == allSecond.Length - 1)
                {
                    break;
                }
                allSecond = allSecond.Insert(i + 1, " ");
            }
            Console.WriteLine(allSecond);
        }
    }
}
