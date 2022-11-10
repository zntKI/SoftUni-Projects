using System;

namespace EasterBake
{
    class Program
    {
        static void Main(string[] args)
        {
            int numKozunaci = int.Parse(Console.ReadLine());
            double allAmountSugar = 0;
            double allAmountBrashno = 0;
            int maxUsedBrashno = int.MinValue;
            int maxUsedSugar = int.MinValue;
            int amountSugar = int.Parse(Console.ReadLine());
            int amountBrashno = int.Parse(Console.ReadLine());
            maxUsedSugar = amountSugar;
            maxUsedBrashno = amountBrashno;
            allAmountSugar += amountSugar;
            allAmountBrashno += amountBrashno;
            for (int i = 1; i < numKozunaci; i++)
            {
                amountSugar = int.Parse(Console.ReadLine());
                amountBrashno = int.Parse(Console.ReadLine());
                allAmountSugar += amountSugar;
                allAmountBrashno += amountBrashno;
                if (amountSugar > maxUsedSugar)
                {
                    maxUsedSugar = amountSugar;
                }
                if (amountBrashno > maxUsedBrashno)
                {
                    maxUsedBrashno = amountBrashno;
                }
            }
            Console.WriteLine($"Sugar: {Math.Ceiling(allAmountSugar / 950)}");
            Console.WriteLine($"Flour: {Math.Ceiling(allAmountBrashno / 750)}");
            Console.WriteLine($"Max used flour is {maxUsedBrashno} grams, max used sugar is {maxUsedSugar} grams.");
        }
    }
}
