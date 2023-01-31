using System;

namespace _01ConvertMetersToKilometers
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal meters = decimal.Parse(Console.ReadLine());
            Console.WriteLine($"{(meters / 1000):f2}");
        }
    }
}
