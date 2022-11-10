using System;

namespace GoldMine
{
    class Program
    {
        static void Main(string[] args)
        {
            int numDays = int.Parse(Console.ReadLine());
            double sumDobiv = 0;
            for (int i = 1; i <= numDays; i++)
            {
                double dobiv = double.Parse(Console.ReadLine());
                int daysKopane = int.Parse(Console.ReadLine());
                for (int j = 1; j <= daysKopane; j++)
                {
                    double dobivGoldForDay = double.Parse(Console.ReadLine());
                    sumDobiv += dobivGoldForDay;
                }
                if ((sumDobiv / daysKopane) >= dobiv)
                {
                    Console.WriteLine($"Good job! Average gold per day: {(sumDobiv / daysKopane):f2}.");
                }
                else
                {
                    Console.WriteLine($"You need {(dobiv - (sumDobiv / daysKopane)):f2} gold.");
                }
                sumDobiv = 0;
            }
        }
    }
}
