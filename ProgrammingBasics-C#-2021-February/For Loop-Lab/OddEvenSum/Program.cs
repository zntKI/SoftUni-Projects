using System;

namespace OddEvenSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int oddSum = 0;
            int evenSum = 0;
            for (int i = 0; i < n; i++)
            {
                int elements = int.Parse(Console.ReadLine());
                if (i % 2 == 0)
                {
                    evenSum += elements;
                }
                else
                {
                    oddSum += elements;
                }
            }
            if (evenSum == oddSum)
            {
                Console.WriteLine("Yes");
                Console.WriteLine($"Sum = {evenSum}");
            }
            else
            {
                Console.WriteLine("No");
                int diff = Math.Abs(evenSum - oddSum);
                Console.WriteLine($"Diff = {diff}");
            }
        }
    }
}
