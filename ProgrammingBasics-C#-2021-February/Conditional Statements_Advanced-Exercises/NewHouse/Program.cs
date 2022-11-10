using System;

namespace NewHouse
{
    class Program
    {
        static void Main(string[] args)
        {
            string flowers = Console.ReadLine();
            int amount = int.Parse(Console.ReadLine());
            int budget = int.Parse(Console.ReadLine());
            double price = 0.0;
            if (flowers == "Roses")
            {
                if (amount > 80)
                {
                    price = (amount * 5) - (amount * 5) * 0.10;
                    if (budget >= price)
                    {
                        Console.WriteLine($"Hey, you have a great garden with {amount} {flowers} and {(budget - price):f2} leva left.");
                    }
                    else
                    {
                        Console.WriteLine($"Not enough money, you need {(price - budget):f2} leva more.");
                    }
                }
                else
                {
                    price = amount * 5;
                    if (budget >= price)
                    {
                        Console.WriteLine($"Hey, you have a great garden with {amount} {flowers} and {(budget - price):f2} leva left.");
                    }
                    else
                    {
                        Console.WriteLine($"Not enough money, you need {(price - budget):f2} leva more.");
                    }
                }
            }
            else if (flowers == "Dahlias")
            {
                if (amount > 90)
                {
                    price = (amount * 3.80) - (amount * 3.80) * 0.15;
                    if (budget >= price)
                    {
                        Console.WriteLine($"Hey, you have a great garden with {amount} {flowers} and {(budget - price):f2} leva left.");
                    }
                    else
                    {
                        Console.WriteLine($"Not enough money, you need {(price - budget):f2} leva more.");
                    }
                }
                else
                {
                    price = amount * 3.80;
                    if (budget >= price)
                    {
                        Console.WriteLine($"Hey, you have a great garden with {amount} {flowers} and {(budget - price):f2} leva left.");
                    }
                    else
                    {
                        Console.WriteLine($"Not enough money, you need {(price - budget):f2} leva more.");
                    }
                }
            }
            else if (flowers == "Tulips")
            {
                if (amount > 80)
                {
                    price = (amount * 2.80) - (amount * 2.80) * 0.15;
                    if (budget >= price)
                    {
                        Console.WriteLine($"Hey, you have a great garden with {amount} {flowers} and {(budget - price):f2} leva left.");
                    }
                    else
                    {
                        Console.WriteLine($"Not enough money, you need {(price - budget):f2} leva more.");
                    }
                }
                else
                {
                    price = amount * 2.80;
                    if (budget >= price)
                    {
                        Console.WriteLine($"Hey, you have a great garden with {amount} {flowers} and {(budget - price):f2} leva left.");
                    }
                    else
                    {
                        Console.WriteLine($"Not enough money, you need {(price - budget):f2} leva more.");
                    }
                }
            }
            else if (flowers == "Narcissus")
            {
                if (amount < 120)
                {
                    price = (amount * 3.00) + (amount * 3.00) * 0.15;
                    if (budget >= price)
                    {
                        Console.WriteLine($"Hey, you have a great garden with {amount} {flowers} and {(budget - price):f2} leva left.");
                    }
                    else
                    {
                        Console.WriteLine($"Not enough money, you need {(price - budget):f2} leva more.");
                    }
                }
                else
                {
                    price = amount * 3.00;
                    if (budget >= price)
                    {
                        Console.WriteLine($"Hey, you have a great garden with {amount} {flowers} and {(budget - price):f2} leva left.");
                    }
                    else
                    {
                        Console.WriteLine($"Not enough money, you need {(price - budget):f2} leva more.");
                    }
                }
            }
            else if (flowers == "Gladiolus")
            {
                if (amount < 80)
                {
                    price = (amount * 2.50) + (amount * 2.50) * 0.20;
                    if (budget >= price)
                    {
                        Console.WriteLine($"Hey, you have a great garden with {amount} {flowers} and {(budget - price):f2} leva left.");
                    }
                    else
                    {
                        Console.WriteLine($"Not enough money, you need {(price - budget):f2} leva more.");
                    }
                }
                else
                {
                    price = amount * 2.50;
                    if (budget >= price)
                    {
                        Console.WriteLine($"Hey, you have a great garden with {amount} {flowers} and {(budget - price):f2} leva left.");
                    }
                    else
                    {
                        Console.WriteLine($"Not enough money, you need {(price - budget):f2} leva more.");
                    }
                }
            }
        }
    }
}
