using System;

namespace EasterLunch
{
    class Program
    {
        static void Main(string[] args)
        {
            int kozunaci = int.Parse(Console.ReadLine());
            int koriEggs = int.Parse(Console.ReadLine());
            int kgCookies = int.Parse(Console.ReadLine());
            double priceKozunaci = kozunaci * 3.20;
            double priceKoriEggs = koriEggs * 4.35;
            double priceKgCookies = kgCookies * 5.40;
            double pricePaintEggs = 12 * koriEggs * 0.15;
            double sumAll = priceKozunaci + priceKoriEggs + priceKgCookies + pricePaintEggs;
            Console.WriteLine($"{sumAll:f2}");
        }
    }
}
