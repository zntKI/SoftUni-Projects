using System;

namespace MovieStars
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            double sumHonorar = 0;
            double actorHonorar = 0;
            while (sumHonorar <= budget)
            {
                string input = Console.ReadLine();
                if (input != "ACTION")
                {
                    if (input.Length > 15)
                    {
                        actorHonorar = (budget - sumHonorar) * 0.2;
                        sumHonorar += actorHonorar;
                    }
                    else
                    {
                        actorHonorar = double.Parse(Console.ReadLine());
                        sumHonorar += actorHonorar;
                    }
                }
                else if (input == "ACTION")
                {
                    break;
                }
            }
            if (sumHonorar <= budget)
            {
                Console.WriteLine($"We are left with {(budget - sumHonorar):f2} leva.");
            }
            else
            {
                Console.WriteLine($"We need {(sumHonorar - budget):f2} leva for our actors.");
            }
        }
    }
}
