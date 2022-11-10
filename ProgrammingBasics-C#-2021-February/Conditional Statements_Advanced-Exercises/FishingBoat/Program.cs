using System;

namespace FishingBoat
{
    class Program
    {
        static void Main(string[] args)
        {
            int budget = int.Parse(Console.ReadLine());
            string season = Console.ReadLine();
            int fisherMen = int.Parse(Console.ReadLine());
            double price = 0.0;
            if (season == "Spring")
            {
                price = 3000;
            }
            else if (season == "Summer" && season == "Autumn")
            {
                price = 4200;
            }
            //else if (season == "Autumn")
            //{
            //    price = 4200;
            //}
            else if (season == "Winter")
            {
                price = 2600;
            }
            if (fisherMen <= 6)
            {
                price *= 0.90;
            }
            else if (fisherMen >= 7 && fisherMen <= 11)
            {
                price *= 0.85;
            }
            else if (fisherMen >= 12)
            {
                price *= 0.75;
            }
            if (season != "Autumn")
            {
                if (fisherMen % 2 == 0)
                {
                    price *= 0.95;
                }
                else
                {
                    price = price;
                }
            }
            else
            {
                price = price;
            }
            if (budget >= price)
            {
                Console.WriteLine($"Yes! You have {(budget - price):f2} leva left.");
            }
            else
            {
                Console.WriteLine($"Not enough money! You need {(price - budget):f2} leva.");
            }
        }
    }
}
