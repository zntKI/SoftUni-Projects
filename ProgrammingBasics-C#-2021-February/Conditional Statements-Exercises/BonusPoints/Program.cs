using System;

namespace BonusPoints
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstPoints = int.Parse(Console.ReadLine());
            if (firstPoints <= 100)
            {
                int bonusPoints = firstPoints + 5;
                if (firstPoints % 2 == 0)
                {
                    int finalPoints = bonusPoints + 1;
                    int finalBonusPoints = finalPoints - firstPoints;
                    Console.WriteLine(finalBonusPoints);
                    Console.WriteLine(finalPoints);
                }
                else if (firstPoints % 10 == 5)
                {
                    int finalPoints = bonusPoints + 2;
                    int finalBonusPoints = finalPoints - firstPoints;
                    Console.WriteLine(finalBonusPoints);
                    Console.WriteLine(finalPoints);
                }
            }
            else if (firstPoints > 100)
            {
                double bonusPoints = firstPoints + firstPoints * 0.20;
                if (firstPoints % 2 == 0)
                {
                    double finalPoints = bonusPoints + 1;
                    double finalBonusPoints = finalPoints - firstPoints;
                    Console.WriteLine(finalBonusPoints);
                    Console.WriteLine(finalPoints);
                }
                else if (firstPoints % 10 == 5)
                {
                    double finalPoints = bonusPoints + 2;
                    double finalBonusPoints = finalPoints - firstPoints;
                    Console.WriteLine(finalBonusPoints);
                    Console.WriteLine(finalPoints);
                }
            }
            else if (firstPoints > 1000)
            {
                double bonusPoints = firstPoints + firstPoints * 0.10;
                if (firstPoints % 2 == 0)
                {
                    double finalPoints = bonusPoints + 1;
                    double finalBonusPoints = finalPoints - firstPoints;
                    Console.WriteLine(finalBonusPoints);
                    Console.WriteLine(finalPoints);
                }
                else if (firstPoints % 10 == 5)
                {
                    double finalPoints = bonusPoints + 2;
                    double finalBonusPoints = finalPoints - firstPoints;
                    Console.WriteLine(finalBonusPoints);
                    Console.WriteLine(finalPoints);
                }
                else if(firstPoints % 10 != 5 && firstPoints % 2 != 0)
                {
                    double finalPoints = bonusPoints - firstPoints;
                    Console.WriteLine(finalPoints);
                    Console.WriteLine(bonusPoints);
                }
            }
        }
    }
}
