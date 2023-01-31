using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.HouseParty
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<string> guests = new List<string>();
            for (int i = 1; i <= n; i++)
            {
                string input = Console.ReadLine();
                string[] elements = input.Split();
                if (elements[1] + " " + elements[2] == "is going!" && !guests.Contains(elements[0]))
                {
                    guests.Add(elements[0]);
                }
                else if (elements[1] + " " + elements[2] == "is going!" && guests.Contains(elements[0]))
                {
                    Console.WriteLine($"{elements[0]} is already in the list!");
                }
                else if (elements[1] + " " + elements[2] + " " + elements[3] == "is not going!" && guests.Contains(elements[0]))
                {
                    guests.Remove(elements[0]);
                }
                else if (elements[1] + " " + elements[2] + " " + elements[3] == "is not going!" && !guests.Contains(elements[0]))
                {
                    Console.WriteLine($"{elements[0]} is not in the list!");
                }
            }
            for (int i = 0; i < guests.Count; i++)
            {
                Console.WriteLine(guests[i]);
            }
        }
    }
}
