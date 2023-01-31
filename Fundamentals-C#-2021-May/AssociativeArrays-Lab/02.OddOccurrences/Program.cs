using System;
using System.Collections.Generic;

namespace _02.OddOccurrences
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] words = Console.ReadLine().Split();
            Dictionary<string, int> oddOcc = new Dictionary<string, int>();
            for (int i = 0; i < words.Length; i++)
            {
                string occ = words[i].ToLower();
                if (!oddOcc.ContainsKey(occ))
                {
                    oddOcc.Add(occ, 0);
                }
                oddOcc[occ]++;
            }
            foreach (var item in oddOcc)
            {
                if (item.Value % 2 != 0)
                {
                    Console.Write($"{item.Key} ");
                }
            }
        }
    }
}
