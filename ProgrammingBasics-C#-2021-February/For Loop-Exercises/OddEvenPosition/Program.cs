using System;

namespace OddEvenPosition
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            double evenSum = 0;
            double oddSum = 0;
            double oddMin = double.MaxValue;
            double evenMin = double.MaxValue;
            double oddMax = double.MinValue;
            double evenMax = double.MinValue;
            string output = "No";
            for (int i = 1; i <= n; i++)
            {
                double num = double.Parse(Console.ReadLine());
                if (i % 2 != 0)
                {
                    oddSum += num;
                    if (num < oddMin)
                    {
                        oddMin = num;
                    }
                    else
                    {
                        oddMin = double.Parse(output);
                    }
                    if (num > oddMax)
                    {
                        oddMax = num;
                    }
                    else
                    {
                        oddMax = double.Parse(output);
                    }
                }
                else
                {
                    evenSum += num;
                    if (num < evenMin)
                    {
                        evenMin = num;
                    }
                    else
                    {
                        evenMin = double.Parse(output);
                    }
                    if (num > evenMax)
                    {
                        evenMax = num;
                    }
                    else
                    {
                        evenMax = double.Parse(output);
                    }
                }
            }
            Console.WriteLine($"OddSum={oddSum:f2}");
            Console.WriteLine($"OddMin={oddMin:f2}");
            Console.WriteLine($"OddMax={oddMax:f2}");
            Console.WriteLine($"EvenSum={evenSum:f2}");
            Console.WriteLine($"EvenMin={evenMin:f2}");
            Console.WriteLine($"EvenMax={evenMax:f2}");
        }
    }
}
