using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.RemoveNegativesAndReverse
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> list = Console.ReadLine().Split().Select(int.Parse).ToList();
            List<int> result1 = new List<int>();
            List<int> result2 = new List<int>();
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i] > 0)
                {
                    result1.Add(list[i]);
                }
            }
            if (result1.Count > 0)
            {
                for (int i = result1.Count - 1; i >= 0; i--)
                {
                    result2.Add(result1[i]);
                }
                Console.Write(string.Join(' ', result2));
            }
            else
            {
                Console.WriteLine("empty");
            }
        }
    }
}
