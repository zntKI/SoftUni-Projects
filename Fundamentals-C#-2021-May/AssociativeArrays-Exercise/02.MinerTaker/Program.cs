using System;
using System.Collections.Generic;

namespace _02.MinerTaker
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> gained = new Dictionary<string, int>();
            string input = Console.ReadLine();
            while (input != "stop")
            {
                int quantity = int.Parse(Console.ReadLine());
                if (!gained.ContainsKey(input))
                {
                    gained.Add(input, quantity);
                }
                else
                {
                    gained[input] += quantity;
                }
                input = Console.ReadLine();
            }
            foreach (var item in gained)
            {
                Console.WriteLine($"{item.Key} -> {item.Value}");
            }
        }
    }
}
