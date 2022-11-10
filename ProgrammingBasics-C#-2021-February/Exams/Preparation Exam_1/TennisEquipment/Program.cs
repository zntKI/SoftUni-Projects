using System;

namespace TennisEquipment
{
    class Program
    {
        static void Main(string[] args)
        {
            double priceTennisRacket = double.Parse(Console.ReadLine());
            int numTennisRackets = int.Parse(Console.ReadLine());
            int numShoes = int.Parse(Console.ReadLine());
            double priceAllRackets = numTennisRackets * priceTennisRacket;
            double priceShoe = priceTennisRacket / 6;
            double priceAllShoes = priceShoe * numShoes;
            double priceOther = (priceAllShoes + priceAllRackets) * 0.2;
            double priceAll = priceAllRackets + priceAllShoes + priceOther;
            Console.WriteLine($"Price to be paid by Djokovic {Math.Floor(priceAll/8)}");
            Console.WriteLine($"Price to be paid by sponsors {Math.Ceiling((priceAll*7)/8)}");
        }
    }
}
