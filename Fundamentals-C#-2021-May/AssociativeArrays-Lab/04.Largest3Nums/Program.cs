﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.Largest3Nums
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> list = Console.ReadLine().Split().Select(int.Parse).ToList();
            int[] sorted = list.OrderByDescending(n => n).ToArray();
            for (int i = 0; i < sorted.Length; i++)
            {
                if (i < 3)
                {
                    Console.Write(sorted[i] + " ");
                }
            }
        }
    }
}
