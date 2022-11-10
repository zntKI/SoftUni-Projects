using System;

namespace MiningRig
{
    class Program
    {
        static void Main(string[] args)
        {
            int priceCard = int.Parse(Console.ReadLine());
            int pricePrehodnik = int.Parse(Console.ReadLine());
            double powerKonsumaciq = double.Parse(Console.ReadLine());
            double profitFromOneCard1Day = double.Parse(Console.ReadLine());
            int priceAllCards = priceCard * 13;
            int priceAllPrehodnici = pricePrehodnik * 13;
            int allWastedMoney = priceAllCards + priceAllPrehodnici + 1000;
            double profitFromCard = profitFromOneCard1Day - powerKonsumaciq;
            double allProfitForDay = profitFromCard * 13;
            Console.WriteLine(allWastedMoney);
            Console.WriteLine(Math.Ceiling(allWastedMoney / allProfitForDay));
        }
    }
}
