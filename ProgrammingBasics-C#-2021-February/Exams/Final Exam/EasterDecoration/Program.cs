using System;

namespace EasterDecoration
{
    class Program
    {
        static void Main(string[] args)
        {
            double numClients = double.Parse(Console.ReadLine());
            double sumClient = 0;
            int countProducts = 0;
            double sumOfAllClients = 0;
            double sumClientAfter = 0;
            for (int i  = 1; i <= numClients; i ++)
            {
                string product = Console.ReadLine();
                while (product != "Finish")
                {
                    if (product == "basket")
                    {
                        sumClient += 1.50;
                    }
                    else if (product == "wreath")
                    {
                        sumClient += 3.80;
                    }
                    else if (product == "chocolate bunny")
                    {
                        sumClient += 7;
                    }
                    countProducts++;
                    product = Console.ReadLine();
                }
                if (countProducts % 2 == 0)
                {
                    sumClientAfter = sumClient * 0.8;
                    Console.WriteLine($"You purchased {countProducts} items for {(sumClientAfter):f2} leva.");
                }
                else
                {
                    sumClientAfter = sumClient;
                    Console.WriteLine($"You purchased {countProducts} items for {sumClientAfter:f2} leva.");
                }
                sumOfAllClients += sumClientAfter;
                sumClient = 0;
                countProducts = 0;
            }
            Console.WriteLine($"Average bill per client is: {(sumOfAllClients / numClients):f2} leva.");
        }
    }
}
