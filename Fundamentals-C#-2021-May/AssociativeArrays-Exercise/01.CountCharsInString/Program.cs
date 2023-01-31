using System;
using System.Collections.Generic;

namespace _01.CountCharsInString
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<char, int> occ = new Dictionary<char, int>();
            string word = Console.ReadLine();
            for (int i = 0; i < word.Length; i++)
            {
                if (word[i] == ' ')
                {
                    continue;
                }
                if (!occ.ContainsKey(word[i]))
                {
                    occ.Add(word[i], 0);
                }
                occ[word[i]]++;
            }
            foreach (var item in occ)
            {
                Console.WriteLine($"{item.Key} -> {item.Value}");
            }
        }
    }
}
