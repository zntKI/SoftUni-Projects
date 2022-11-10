using System;

namespace EasterShop
{
    class Program
    {
        static void Main(string[] args)
        {
            int numEggs = int.Parse(Console.ReadLine());
            string action = Console.ReadLine();
            int eggsSold = 0;
            while (action != "Close")
            {
                int numEggsNow = int.Parse(Console.ReadLine());
                if (action == "Buy")
                {
                    numEggs -= numEggsNow;
                    eggsSold += numEggsNow;
                }
                else if (action == "Fill")
                {
                    numEggs += numEggsNow;
                }
                if (numEggs < 0)
                {
                    Console.WriteLine("Not enough eggs in store!");
                    Console.WriteLine($"You can buy only {numEggsNow + numEggs}.");
                    return;
                }
                action = Console.ReadLine();
            }
            Console.WriteLine("Store is closed!");
            Console.WriteLine($"{eggsSold} eggs sold.");
        }
    }
}
