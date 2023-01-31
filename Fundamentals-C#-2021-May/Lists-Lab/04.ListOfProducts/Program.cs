using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.ListOfProducts
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            List<string> list = new List<string>();
            for (int i = 0; i < num; i++)
            {
                string input = Console.ReadLine();
                list.Add(input);
            }
            list.Sort();
            for (int i = 1; i <= num; i++)
            {
                Console.WriteLine($"{i}.{list[i - 1]}");
            }
        }
    }
}
