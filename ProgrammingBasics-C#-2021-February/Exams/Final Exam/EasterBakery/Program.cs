using System;

namespace EasterBakery
{
    class Program
    {
        static void Main(string[] args)
        {
            double priceBrashno = double.Parse(Console.ReadLine());
            double kgBrashno = double.Parse(Console.ReadLine());
            double kgSugar = double.Parse(Console.ReadLine());
            int koriEggs = int.Parse(Console.ReadLine());
            int packetsMaq = int.Parse(Console.ReadLine());
            double priceKgSugar = priceBrashno * 0.75;
            double priceKora = priceBrashno + (priceBrashno * 0.10);
            double priceMaq = priceKgSugar * 0.20;
            double allBrashno = priceBrashno * kgBrashno;
            double allSugar = priceKgSugar * kgSugar;
            double allKori = koriEggs * priceKora;
            double allMaq = packetsMaq * priceMaq;
            double allSum = allBrashno + allKori + allMaq + allSugar;
            Console.WriteLine($"{allSum:f2}");
        }
    }
}
