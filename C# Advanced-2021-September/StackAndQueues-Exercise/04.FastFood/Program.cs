using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.FastFood
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] orders = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
            Queue<int> ordersYes = new Queue<int>();
            foreach (var order in orders)
            {
                ordersYes.Enqueue(order);
            }
            int max = int.MinValue;
            while (ordersYes.Count > 0 && n > 0)
            {
                int currentOrder = ordersYes.Peek();
                if (currentOrder > max)
                {
                    max = currentOrder;
                }
                if (n - currentOrder < 0)
                {
                    break;
                }
                n -= currentOrder;
                ordersYes.Dequeue();
            }
            Console.WriteLine(max);
            if (ordersYes.Count == 0)
            {
                Console.WriteLine("Orders complete");
            }
            else
            {
                Console.WriteLine($"Orders left: {string.Join(" ", ordersYes)}");
            }
        }
    }
}
