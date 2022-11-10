using System;

namespace EasterParty
{
    class Program
    {
        static void Main(string[] args)
        {
            int guests = int.Parse(Console.ReadLine());
            double priceKuvertForOne = double.Parse(Console.ReadLine());
            double budget = double.Parse(Console.ReadLine());
            if (guests >= 10 && guests <= 15)
            {
                priceKuvertForOne *= 0.85;
            }
            else if (guests > 15 && guests <= 20)
            {
                priceKuvertForOne *= 0.80;
            }
            else if (guests > 20)
            {
                priceKuvertForOne *= 0.75;
            }
            double moneyForAllPeople = priceKuvertForOne * guests;
            double priceCake = budget * 0.10;
            double sumAll = moneyForAllPeople + priceCake;
            if (sumAll <= budget)
            {
                Console.WriteLine($"It is party time! {(budget - sumAll):f2} leva left.");
            }
            else
            {
                Console.WriteLine($"No party! {(sumAll - budget):f2} leva needed.");
            }
        }
    }
}
