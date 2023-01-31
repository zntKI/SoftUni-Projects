using System;

namespace _08.FactorDivision
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            Factorial(a, b);
        }

        private static void Factorial(int a, int b)
        {
            long factorialA = 1;
            long factorialB = 1;
            for (int i = a; i >= 1; i--)
            {
                factorialA *= i;
            }
            for (int i = b; i >= 1; i--)
            {
                factorialB *= i;
            }
            Console.WriteLine($"{(double)factorialA / factorialB:f2}");
        }
    }
}
