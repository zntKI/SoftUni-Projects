using System;
using System.Collections.Generic;

namespace _10.Crossroads
{
    class Program
    {
        static void Main(string[] args)
        {
            int greenSec = int.Parse(Console.ReadLine());
            int green = greenSec;
            int freeWSec = int.Parse(Console.ReadLine());
            Queue<string> cars = new Queue<string>();
            string input = Console.ReadLine();
            int count = 0;
            while (input != "END")
            {
                if (input != "green")
                {
                    cars.Enqueue(input);
                }
                else
                {
                    while (cars.Count > 0 && greenSec > 0)
                    {
                        string car = cars.Dequeue();
                        if (greenSec - car.Length >= 0)
                        {
                            count++;
                            greenSec -= car.Length;
                            continue;
                        }
                        if (greenSec - car.Length + freeWSec >= 0)
                        {
                            count++;
                            greenSec = 0;
                            continue;
                        }
                        else
                        {
                            Console.WriteLine("A crash happened!");
                            Console.WriteLine($"{car} was hit at {car[greenSec + freeWSec]}.");
                            return;
                        }
                    }
                    greenSec = green;
                }
                input = Console.ReadLine();
            }
            Console.WriteLine("Everyone is safe.");
            Console.WriteLine($"{count} total cars passed the crossroads.");
        }
    }
}
