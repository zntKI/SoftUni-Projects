using System;
using System.Collections.Generic;
using System.Linq;

namespace _12.CupsAndBottles
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] cupsCap = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
            int[] bottlesCap = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
            Stack<int> bottles = new Stack<int>();
            Queue<int> cups = new Queue<int>();
            foreach (var cup in cupsCap)
            {
                cups.Enqueue(cup);
            }
            foreach (var bottle in bottlesCap)
            {
                bottles.Push(bottle);
            }
            int wasted = 0;
            while (cups.Count > 0 && bottles.Count > 0)
            {
                int bottleCap = bottles.Peek();
                int cupCap = cups.Peek();
                if (bottleCap >= cupCap)
                {
                    wasted += bottleCap - cupCap;
                    cups.Dequeue();
                    bottles.Pop();
                }
                else
                {
                    cupCap -= bottleCap;
                    bottles.Pop();
                    while (cupCap > 0)
                    {
                        int bottle = bottles.Peek();
                        if (bottle - cupCap > 0)
                        {
                            wasted += bottle - cupCap;
                            bottles.Pop();
                            break;
                        }
                        cupCap -= bottle;
                        bottles.Pop();
                    }
                    cups.Dequeue();
                }
            }
            if (cups.Count == 0)
            {
                Console.WriteLine($"Bottles: {string.Join(" ", bottles)}");
            }
            else
            {
                Console.WriteLine($"Cups: {string.Join(" ", cups)}");
            }
            Console.WriteLine($"Wasted litters of water: {wasted}");
        }
    }
}
