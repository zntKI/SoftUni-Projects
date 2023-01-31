using System;
using System.Collections.Generic;

namespace _07.HotPotato
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] kids = Console.ReadLine().Split(" ");
            Queue<string> children = new Queue<string>(kids);
            int tosses = int.Parse(Console.ReadLine());
            int countTosses = 0;
            while (children.Count > 1)
            {
                countTosses++;
                if (countTosses == tosses)
                {
                    countTosses = 0;
                    Console.WriteLine($"Removed {children.Dequeue()}");
                }
                else
                {
                    children.Enqueue(children.Dequeue());
                }
            }
            Console.WriteLine($"Last is {children.Dequeue()}");
        }
    }
}
