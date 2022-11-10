using System;

namespace Series
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            int numS = int.Parse(Console.ReadLine());
            string name = Console.ReadLine();
            double price = double.Parse(Console.ReadLine());
            double priceAll = 0;
            int countS = 0;
            while (countS < numS)
            {
                if (name == "Thrones")
                {
                    price = price * 0.5;
                    priceAll += price;
                }
                else if (name == "Lucifer")
                {
                    price = price * 0.6;
                    priceAll += price;
                }
                else if (name == "Protector")
                {
                    price = price * 0.7;
                    priceAll += price;
                }
                else if (name == "TotalDrama")
                {
                    price = price * 0.8;
                    priceAll += price;
                }
                else if (name == "Area")
                {
                    price = price * 0.9;
                    priceAll += price;
                }
                else
                {
                    price = price;
                    priceAll += price;
                }
                if (priceAll > budget)
                {
                    Console.WriteLine($"You need {(priceAll - budget):f2} lv. more to buy the series!");
                    return;
                }
                countS++;
                if (countS == numS)
                {
                    break;
                }
                name = Console.ReadLine();
                price = double.Parse(Console.ReadLine());
            }
            if (priceAll > budget)
            {
                Console.WriteLine($"You need {(priceAll - budget):f2} lv. more to buy the series!");
            }
            else
            {
                Console.WriteLine($"You bought all the series and left with {(budget - priceAll):f2} lv.");
            }
        }
    }
}
