using System;

namespace CatFood
{
    class Program
    {
        static void Main(string[] args)
        {
            int numCats = int.Parse(Console.ReadLine());
            int countLittleCats = 0;
            int countBigCats = 0;
            int countLargeCats = 0;
            double sumAmount = 0;
            for (int i = 1; i <= numCats; i++)
            {
                int amountEaten = int.Parse(Console.ReadLine());
                if (amountEaten >= 100 && amountEaten < 200)
                {
                    countLittleCats++;
                    sumAmount += amountEaten;
                }
                else if (amountEaten >= 200 && amountEaten < 300)
                {
                    countBigCats++;
                    sumAmount += amountEaten;
                }
                else if (amountEaten >= 300 && amountEaten < 400)
                {
                    countLargeCats++;
                    sumAmount += amountEaten;
                }
            }
            Console.WriteLine($"Group 1: {countLittleCats} cats.");
            Console.WriteLine($"Group 2: {countBigCats} cats.");
            Console.WriteLine($"Group 3: {countLargeCats} cats.");
            Console.WriteLine($"Price for food per day: {((sumAmount / 1000) * 12.45):f2} lv.");
        }
    }
}
