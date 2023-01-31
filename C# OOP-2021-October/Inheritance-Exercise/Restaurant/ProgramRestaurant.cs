using System;

namespace Restaurant
{
    public class ProgramRestaurant
    {
        public static void Main(string[] args)
        {
            string line = Console.ReadLine();
            double milliliteres = 0;
            double grams = 0;
            double calories = 0;
            decimal amount = 0;
            while (line != "End")
            {
                string[] command = line.Split(' ');
                string name = command[1];
                if (command[0] == "Coffee")
                {
                    double caffeine = double.Parse(command[2]);
                    Coffee coffee = new Coffee(name, caffeine);
                    milliliteres += coffee.Milliliters;
                    amount += coffee.Price;
                }
                else if (command[0] == "Tea")
                {
                    decimal price = decimal.Parse(command[2]);
                    double milliliters = double.Parse(command[3]);
                    Tea tea = new Tea(name, price, milliliters);
                    milliliteres += tea.Milliliters;
                    amount += tea.Price;
                }
                else if (command[0] == "Fish")
                {
                    decimal price = decimal.Parse(command[2]);
                    Fish fish = new Fish(name, price);
                    amount += fish.Price;
                    grams += fish.Grams;
                }
                else if (command[0] == "Soup")
                {
                    decimal price = decimal.Parse(command[2]);
                    double gramss = double.Parse(command[3]);
                    Soup soup = new Soup(name, price, gramss);
                    amount += soup.Price;
                    grams += soup.Grams;
                }
                else if (command[0] == "Cake")
                {
                    Cake cake = new Cake(name);
                    grams += cake.Grams;
                    calories += cake.Calories;
                    amount += cake.Price;
                }
                line = Console.ReadLine();
            }
            Console.WriteLine("Your order contains:");
            Console.WriteLine($"  Quantity of liquids: {milliliteres}");
            Console.WriteLine($"  Grams of food {grams}");
            if (calories > 0)
            {
                Console.WriteLine($"  Calories {calories}");
            }
            Console.WriteLine($"  Final amount {amount}");
        }
    }
}
