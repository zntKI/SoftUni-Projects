using System;

namespace ChristmasGifts
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            int countKids = 0;
            int countAdults = 0;
            int moneyForToys = 0;
            int moneyForSweaters = 0;
            while (input != "Christmas")
            {
                if (int.Parse(input) <= 16)
                {
                    countKids++;
                    moneyForToys += 5;
                }
                else if (int.Parse(input) > 16)
                {
                    countAdults++;
                    moneyForSweaters += 15;
                }
                input = Console.ReadLine();
                if (input == "Christmas")
                {
                    break;
                }
            }
            Console.WriteLine($"Number of adults: {countAdults}");
            Console.WriteLine($"Number of kids: {countKids}");
            Console.WriteLine($"Money for toys: {moneyForToys}");
            Console.WriteLine($"Money for sweaters: {moneyForSweaters}");
        }
    }
}
