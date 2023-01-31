using System;
using System.Collections.Generic;

namespace _06.SuperMarket
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<string> clients = new Queue<string>();
            string input = Console.ReadLine();
            while (input != "End")
            {
                if (input == "Paid")
                {
                    foreach (var item in clients)
                    {
                        Console.WriteLine(item);
                    }
                    clients.Clear();
                }
                else
                {
                    clients.Enqueue(input);
                }
                input = Console.ReadLine();
            }
            Console.WriteLine($"{clients.Count} people remaining.");
        }
    }
}
