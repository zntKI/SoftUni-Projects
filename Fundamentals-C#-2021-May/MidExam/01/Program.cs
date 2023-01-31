using System;

namespace _01
{
    class Program
    {
        static void Main(string[] args)
        {
            double neededExp = int.Parse(Console.ReadLine());
            int countBattles = int.Parse(Console.ReadLine());
            double sumExp = 0.0;
            int count = 0;
            for (int i = 1; i <= countBattles; i++)
            {
                double earnedExp = double.Parse(Console.ReadLine());
                count++;
                sumExp += earnedExp;
                if (i % 3 == 0 && i % 5 == 0)
                {
                    sumExp += earnedExp * 0.05;
                }
                else if (i % 5 == 0)
                {
                    sumExp -= earnedExp * 0.10;
                }
                else if (i % 3 == 0)
                {
                    sumExp += earnedExp * 0.15;
                }
                if (sumExp >= neededExp)
                {
                    Console.WriteLine($"Player successfully collected his needed experience for {count} battles.");
                    return;
                }
            }
            Console.WriteLine($"Player was not able to collect the needed experience, {(neededExp - sumExp):f2} more needed.");
        }
    }
}
