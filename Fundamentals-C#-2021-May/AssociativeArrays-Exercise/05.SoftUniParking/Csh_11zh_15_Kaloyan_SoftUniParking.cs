using System;
using System.Collections.Generic;

namespace _05.SoftUniParking
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> parks = new Dictionary<string, string>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] command = Console.ReadLine().Split();
                if (command[0] == "register")
                {
                    if (!parks.ContainsKey(command[1]))
                    {
                        parks.Add(command[1], command[2]);
                        Console.WriteLine($"{command[1]} registered {command[2]} successfully");
                    }
                    else
                    {
                        Console.WriteLine($"ERROR: already registered with plate number {command[2]}");
                    }
                }
                else if (command[0] == "unregister")
                {
                    if (!parks.ContainsKey(command[1]))
                    {
                        Console.WriteLine($"ERROR: user {command[1]} not found");
                    }
                    else
                    {
                        Console.WriteLine($"{command[1]} unregistered successfully");
                        parks.Remove(command[1]);
                    }
                }
            }
            foreach (var item in parks)
            {
                Console.WriteLine($"{item.Key} => {item.Value}");
            }
        }
    }
}
