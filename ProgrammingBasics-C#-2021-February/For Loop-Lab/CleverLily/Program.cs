using System;

namespace CleverLily
{
    class Program
    {
        static void Main(string[] args)
        {
            int age = int.Parse(Console.ReadLine());
            double priceWasher = double.Parse(Console.ReadLine());
            double priceToys = double.Parse(Console.ReadLine());

            int toysNum = 0;
            double money = 0;
            int stolenMoney = 0;
            double moneyPresent = 10;
            for (int i = 1; i <= age; i++)
            {
                if (i % 2 == 0)
                {
                    stolenMoney++;
                    money += moneyPresent;
                    moneyPresent += 10;
                }
                else
                {
                    toysNum++;
                }
            }
            double priceAllToys = priceToys * toysNum;
            double allMoney = (priceAllToys + money) - stolenMoney;
            if (allMoney >= priceWasher)
            {
                Console.WriteLine($"Yes! {(allMoney - priceWasher):f2}");
            }
            else
            {
                Console.WriteLine($"No! {(priceWasher - allMoney):f2}");
            }
        }
    }
}
