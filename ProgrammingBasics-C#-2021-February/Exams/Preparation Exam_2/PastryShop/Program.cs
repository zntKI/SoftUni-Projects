using System;

namespace PastryShop
{
    class Program
    {
        static void Main(string[] args)
        {
            string typeOfSweet = Console.ReadLine();
            int numSweets = int.Parse(Console.ReadLine());
            int dayFromDecember = int.Parse(Console.ReadLine());
            double price = 0;
            if (dayFromDecember <= 15)
            {
                if (typeOfSweet == "Cake")
                {
                    price = numSweets * 24;
                }
                else if (typeOfSweet == "Souffle")
                {
                    price = numSweets * 6.66;
                }
                else if (typeOfSweet == "Baklava")
                {
                    price = numSweets * 12.60;
                }
            }
            else if (dayFromDecember > 15)
            {
                if (typeOfSweet == "Cake")
                {
                    price = numSweets * 28.70;
                }
                else if (typeOfSweet == "Souffle")
                {
                    price = numSweets * 9.80;
                }
                else if (typeOfSweet == "Baklava")
                {
                    price = numSweets * 16.98;
                }
            }
            if (dayFromDecember <= 22)
            {
                if (price >= 100 && price <= 200)
                {
                    price = price * 0.85;
                }
                else if (price > 200)
                {
                    price = price * 0.75;
                }
                if (dayFromDecember <= 15)
                {
                    price = price * 0.90;
                }
            }
            Console.WriteLine($"{price:f2}");
        }
    }
}
