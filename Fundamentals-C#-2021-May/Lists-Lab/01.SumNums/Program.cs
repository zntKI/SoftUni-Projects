﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.SumNums
{
    class Program
    {
        static void Main(string[] args)
        {
            List<double> numbers = Console.ReadLine().Split(' ').Select(double.Parse).ToList();
            for (int i = 0; i < numbers.Count; i++)
            {
                if (i + 1 == numbers.Count)
                {
                    break;
                }
                if (numbers[i] == numbers[i + 1])
                {
                    numbers[i] += numbers[i + 1];
                    numbers.RemoveAt(i + 1);
                    i = -1;
                }
            }
            Console.Write(string.Join(" ", numbers));
        }
    }
}
