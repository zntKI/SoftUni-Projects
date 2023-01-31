﻿using System;
using System.Collections.Generic;

namespace _05.RecordsUniqueNames
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            HashSet<string> set = new HashSet<string>();
            for (int i = 0; i < n; i++)
            {
                var name = Console.ReadLine();
                set.Add(name);
            }
            foreach (var name in set)
            {
                Console.WriteLine(name);
            }
        }
    }
}
