using System;

namespace EasterGuests
{
    class Program
    {
        static void Main(string[] args)
        {
            double guests = double.Parse(Console.ReadLine());
            int budget = int.Parse(Console.ReadLine());
            double numKozunaci = guests / 3;
            double numEggs = guests * 2;
            double priceKozunaci = Math.Ceiling(numKozunaci) * 4;
            double priceEggs = numEggs * 0.45;
            double sumAll = priceKozunaci + priceEggs;
            if (sumAll <= budget)
            {
                Console.WriteLine($"Lyubo bought {Math.Ceiling(numKozunaci)} Easter bread and {numEggs} eggs.");
                Console.WriteLine($"He has {(budget - sumAll):f2} lv. left.");
            }
            else
            {
                Console.WriteLine("Lyubo doesn't have enough money.");
                Console.WriteLine($"He needs {(sumAll - budget):f2} lv. more.");
            }
        }
    }
}
