using System;

namespace FruitShop
{
    class Program
    {
        static void Main(string[] args)
        {
            string fruit = Console.ReadLine();
            string dayOfWeek = Console.ReadLine();
            double amount = double.Parse(Console.ReadLine());
            switch (dayOfWeek)
            {
                case "Monday":
                case "Tuesday":
                case "Wednesday":
                case "Thursday":
                case "Friday":
                    if (fruit == "banana")
                    {
                        Console.WriteLine($"{(amount * 2.50):f2}");
                    }
                    else if (fruit == "apple")
                    {
                        Console.WriteLine($"{(amount * 1.20):f2}");
                    }
                    else if (fruit == "orange")
                    {
                        Console.WriteLine($"{(amount * 0.85):f2}");
                    }
                    else if (fruit == "grapefruit")
                    {
                        Console.WriteLine($"{(amount * 1.45):f2}");
                    }
                    else if (fruit == "kiwi")
                    {
                        Console.WriteLine($"{(amount * 2.70):f2}");
                    }
                    else if (fruit == "pineapple")
                    {
                        Console.WriteLine($"{(amount * 5.50):f2}");
                    }
                    else if (fruit == "grapes")
                    {
                        Console.WriteLine($"{(amount * 3.85):f2}");
                    }
                    else
                    {
                        Console.WriteLine("error");
                    }
                    break;
                case "Saturday":
                case "Sunday":
                    if (fruit == "banana")
                    {
                        Console.WriteLine($"{(amount * 2.70):f2}");
                    }
                    else if (fruit == "apple")
                    {
                        Console.WriteLine($"{(amount * 1.25):f2}");
                    }
                    else if (fruit == "orange")
                    {
                        Console.WriteLine($"{(amount * 0.90):f2}");
                    }
                    else if (fruit == "grapefruit")
                    {
                        Console.WriteLine($"{(amount * 1.60):f2}");
                    }
                    else if (fruit == "kiwi")
                    {
                        Console.WriteLine($"{(amount * 3.00):f2}");
                    }
                    else if (fruit == "pineapple")
                    {
                        Console.WriteLine($"{(amount * 5.60):f2}");
                    }
                    else if (fruit == "grapes")
                    {
                        Console.WriteLine($"{(amount * 4.20):f2}");
                    }
                    else
                    {
                        Console.WriteLine("error");
                    }
                    break;
                default:
                    Console.WriteLine("error");
                    break;
            }
        }
    }
}
