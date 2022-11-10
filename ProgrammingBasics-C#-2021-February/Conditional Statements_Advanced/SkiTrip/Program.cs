using System;

namespace SkiTrip
{
    class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            string roomType = Console.ReadLine();
            string feedback = Console.ReadLine();
            int nights = days - 1;
            if (roomType == "room for one person")
            {
                double price = nights * 18.00;
                if (feedback == "positive")
                {
                    double finalPrice = price + price * 0.25;
                    Console.WriteLine($"{finalPrice:f2}");
                }
                else if (feedback == "negative")
                {
                    double finalPrice = price - price * 0.10;
                    Console.WriteLine($"{finalPrice:f2}");
                }
            }
            else if (roomType == "apartment")
            {
                if (days < 10)
                {
                    double price = (nights * 25.00) - (nights * 25.00) * 0.30;
                    if (feedback == "positive")
                    {
                        double finalPrice = price + price * 0.25;
                        Console.WriteLine($"{finalPrice:f2}");
                    }
                    else if (feedback == "negative")
                    {
                        double finalPrice = price - price * 0.10;
                        Console.WriteLine($"{finalPrice:f2}");
                    }
                }
                else if (days >= 10 && days <=15)
                {
                    double price = (nights * 25.00) - (nights * 25.00) * 0.35;
                    if (feedback == "positive")
                    {
                        double finalPrice = price + price * 0.25;
                        Console.WriteLine($"{finalPrice:f2}");
                    }
                    else if (feedback == "negative")
                    {
                        double finalPrice = price - price * 0.10;
                        Console.WriteLine($"{finalPrice:f2}");
                    }
                }
                else if (days > 15)
                {
                    double price = (nights * 25.00) - (nights * 25.00) * 0.50;
                    if (feedback == "positive")
                    {
                        double finalPrice = price + price * 0.25;
                        Console.WriteLine($"{finalPrice:f2}");
                    }
                    else if (feedback == "negative")
                    {
                        double finalPrice = price - price * 0.10;
                        Console.WriteLine($"{finalPrice:f2}");
                    }
                }
            }
            else if (roomType == "president apartment")
            {
                if (days < 10)
                {
                    double price = (nights * 35.00) - (nights * 35.00) * 0.10;
                    if (feedback == "positive")
                    {
                        double finalPrice = price + price * 0.25;
                        Console.WriteLine($"{finalPrice:f2}");
                    }
                    else if (feedback == "negative")
                    {
                        double finalPrice = price - price * 0.10;
                        Console.WriteLine($"{finalPrice:f2}");
                    }
                }
                else if (days >= 10 && days <= 15)
                {
                    double price = (nights * 35.00) - (nights * 35.00) * 0.15;
                    if (feedback == "positive")
                    {
                        double finalPrice = price + price * 0.25;
                        Console.WriteLine($"{finalPrice:f2}");
                    }
                    else if (feedback == "negative")
                    {
                        double finalPrice = price - price * 0.10;
                        Console.WriteLine($"{finalPrice:f2}");
                    }
                }
                else if (days > 15)
                {
                    double price = (nights * 35.00) - (nights * 35.00) * 0.20;
                    if (feedback == "positive")
                    {
                        double finalPrice = price + price * 0.25;
                        Console.WriteLine($"{finalPrice:f2}");
                    }
                    else if (feedback == "negative")
                    {
                        double finalPrice = price - price * 0.10;
                        Console.WriteLine($"{finalPrice:f2}");
                    }
                }
            }
        }
    }
}
