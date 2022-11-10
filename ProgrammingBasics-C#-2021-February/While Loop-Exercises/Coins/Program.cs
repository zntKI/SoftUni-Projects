using System;

namespace Coins
{
    class Program
    {
        static void Main(string[] args)
        {
            double money = double.Parse(Console.ReadLine());
            int centCounter = 0;
            while (money >= 2.00)
            {
                money = Math.Round((money - 2), 2);
                centCounter++;
            }
            while (money >= 1.00)
            {
                money = Math.Round((money - 1), 2);
                centCounter++;
            }
            while (money >= 0.50)
            {
                money = Math.Round((money - 0.5), 2);
                centCounter++;
            }
            while (money >= 0.20)
            {
                money = Math.Round((money - 0.2), 2);
                centCounter++;
            }
            while (money >= 0.10)
            {
                money = Math.Round((money - 0.1), 2);
                centCounter++;
            }
            while (money >= 0.05)
            {
                money = Math.Round((money - 0.05), 2);
                centCounter++;
            }
            while (money >= 0.02)
            {
                money = Math.Round((money - 0.02), 2);
                centCounter++;
            }
            while (money >= 0.01)
            {
                money = Math.Round((money - 0.01), 2);
                centCounter++;
            }
            Console.WriteLine(centCounter);
        }
    }
}
