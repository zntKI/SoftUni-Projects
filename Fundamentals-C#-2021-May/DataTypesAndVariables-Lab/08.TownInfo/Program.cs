using System;

namespace _08.TownInfo
{
    class Program
    {
        static void Main(string[] args)
        {
            string city = Console.ReadLine();
            uint population = uint.Parse(Console.ReadLine());
            int squareKm = int.Parse(Console.ReadLine());
            Console.WriteLine($"Town {city} has population of {population} and area {squareKm} square km.");
        }
    }
}
