using System;

namespace _07.VendingMachine
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            double sum = 0;
            while (input != "Start")
            {
                double coin = double.Parse(input);
                if (coin == 0.1 || coin == 0.2 || coin == 0.5 || coin == 1 || coin == 2)
                {
                    sum += coin;
                }
                else
                {
                    Console.WriteLine($"Cannot accept {coin}");
                }
                input = Console.ReadLine();
            }
            input = Console.ReadLine();
            double expenses = 0;
            while (input != "End")
            {
                if (input == "Nuts" || input == "Water" || input == "Crisps" || input == "Soda" || input == "Coke")
                {
                    if (input == "Nuts")
                    {
                        expenses += 2;
                        if (expenses > sum)
                        {
                            expenses -= 2;
                            Console.WriteLine("Sorry, not enough money");
                        }
                        else
                        {
                            Console.WriteLine($"Purchased nuts");
                        }
                    }
                    else if (input == "Water")
                    {
                        expenses += 0.7;
                        if (expenses > sum)
                        {
                            expenses -= 0.7;
                            Console.WriteLine("Sorry, not enough money");
                        }
                        else
                        {
                            Console.WriteLine($"Purchased water");
                        }
                    }
                    else if (input == "Crisps")
                    {
                        expenses += 1.5;
                        if (expenses > sum)
                        {
                            expenses -= 1.5;
                            Console.WriteLine("Sorry, not enough money");
                        }
                        else
                        {
                            Console.WriteLine($"Purchased crisps");
                        }
                    }
                    else if (input == "Soda")
                    {
                        expenses += 0.8;
                        if (expenses > sum)
                        {
                            expenses -= 0.8;
                            Console.WriteLine("Sorry, not enough money");
                        }
                        else
                        {
                            Console.WriteLine($"Purchased soda");
                        }
                    }
                    else if (input == "Coke")
                    {
                        expenses += 1;
                        if (expenses > sum)
                        {
                            expenses -= 1;
                            Console.WriteLine("Sorry, not enough money");
                        }
                        else
                        {
                            Console.WriteLine($"Purchased coke");
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Invalid product");
                }
                input = Console.ReadLine();
            }
            Console.WriteLine($"Change: {(sum - expenses):f2}");
        }
    }
}
