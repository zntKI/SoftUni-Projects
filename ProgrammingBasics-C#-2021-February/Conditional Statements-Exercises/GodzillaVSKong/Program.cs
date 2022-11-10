using System;

namespace GodzillaVSKong
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            int numberOfStatists = int.Parse(Console.ReadLine());
            double edCenaObleklo = double.Parse(Console.ReadLine());
            double dekor = budget * 0.10;
            double obshtaCenaObleklo = numberOfStatists * edCenaObleklo;
            if (numberOfStatists > 150)
            {
                double kraynaObshtaCenaObleklo = obshtaCenaObleklo - obshtaCenaObleklo * 0.10;
                double obshtaCena = kraynaObshtaCenaObleklo + dekor;
                if (obshtaCena > budget)
                {
                    Console.WriteLine("Not enough money!");
                    Console.WriteLine($"Wingard needs {(obshtaCena - budget):f2} leva more.");
                }
                else
                {
                    Console.WriteLine("Action!");
                    Console.WriteLine($"Wingard starts filming with {(budget - obshtaCena):f2} leva left.");
                }
            }
            else
            {
                double kraynaObshtaCenaObleklo = obshtaCenaObleklo;
                double obshtaCena = kraynaObshtaCenaObleklo + dekor;
                if (obshtaCena > budget)
                {
                    Console.WriteLine("Not enough money!");
                    Console.WriteLine($"Wingard needs {(obshtaCena - budget):f2} leva more.");
                }
                else
                {
                    Console.WriteLine("Action!");
                    Console.WriteLine($"Wingard starts filming with {(budget - obshtaCena):f2} leva left.");
                }
            }
        }
    }
}
