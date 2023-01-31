using System;
using System.Collections.Generic;

namespace _08.TrafficJam
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string input = Console.ReadLine();
            Queue<string> cars = new Queue<string>();
            Queue<string> allCars = new Queue<string>();
            while (input != "end")
            {
                if (input != "green")
                {
                    string car = input;
                    cars.Enqueue(car);
                }
                else
                {
                    if (n > cars.Count)
                    {
                        int count = cars.Count;
                        for (int i = 0; i < count; i++)
                        {
                            string car = cars.Dequeue();
                            Console.WriteLine($"{car} passed!");
                            allCars.Enqueue(car);
                        }
                    }
                    else
                    {
                        for (int i = 0; i < n; i++)
                        {
                            string car = cars.Dequeue();
                            Console.WriteLine($"{car} passed!");
                            allCars.Enqueue(car);
                        }
                    }
                }
                input = Console.ReadLine();
            }
            Console.WriteLine($"{allCars.Count} cars passed the crossroads.");
        }
    }
}
