﻿using System;

namespace MinNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            int minNum = int.MaxValue;
            while (input != "Stop")
            {
                int num = int.Parse(input);
                if (num < minNum)
                {
                    minNum = num;
                }
                input = Console.ReadLine();
            }
            Console.WriteLine(minNum);
        }
    }
}
