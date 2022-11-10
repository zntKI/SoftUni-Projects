using System;

namespace BeerAndChips
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            double budget = double.Parse(Console.ReadLine());
            int numBeer = int.Parse(Console.ReadLine());
            int numChips = int.Parse(Console.ReadLine());
            double priceBeers = numBeer * 1.20;
            double priceOneChip = priceBeers * 0.45;
            double priceAllChips = Math.Ceiling(priceOneChip * numChips);
            double sumOfAll = priceBeers + priceAllChips;
            if (sumOfAll <= budget)
            {
                Console.WriteLine($"{name} bought a snack and has {(budget - sumOfAll):f2} leva left.");
            }
            else
            {
                Console.WriteLine($"{name} needs {(sumOfAll - budget):f2} more leva!");
            }
        }
    }
}
