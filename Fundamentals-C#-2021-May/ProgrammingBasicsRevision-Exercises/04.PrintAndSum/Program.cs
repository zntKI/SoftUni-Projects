﻿using System;

namespace _04.PrintAndSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int num1 = int.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());
            int sum = 0;
            for (int i = num1; i <= num2; i++)
            {
                if (i == num2)
                {
                    Console.WriteLine(i);
                    sum += i;
                    break;
                }
                Console.Write(i + " ");
                sum += i;
            }
            Console.WriteLine($"Sum: {sum}");
        }
    }
}
