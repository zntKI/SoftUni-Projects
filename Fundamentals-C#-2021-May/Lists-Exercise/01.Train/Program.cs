using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Train
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> wagons = Console.ReadLine().Split().Select(int.Parse).ToList();
            int maxPassengers = int.Parse(Console.ReadLine());
            string input = Console.ReadLine();
            while (input != "end")
            {
                string[] elementsOfInput = input.Split();
                if (elementsOfInput[0] == "Add")
                {
                    int addPassengers = int.Parse(elementsOfInput[1]);
                    wagons.Add(addPassengers);
                }
                else
                {
                    int addPassengers = int.Parse(elementsOfInput[0]);
                    for (int i = 0; i < wagons.Count; i++)
                    {
                        if (wagons[i] + addPassengers <= maxPassengers)
                        {
                            wagons[i] += addPassengers;
                            break;
                        }
                    }
                }
                input = Console.ReadLine();
            }
            Console.WriteLine(string.Join(' ', wagons));
        }
    }
}
