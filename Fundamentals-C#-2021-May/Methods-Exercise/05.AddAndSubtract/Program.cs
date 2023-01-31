using System;

namespace _05.AddAndSubtract
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            int c = int.Parse(Console.ReadLine());
            int result = Sum(a, b);
            Subtract(result, c);
        }

        private static void Subtract(int result, int c)
        {
            Console.WriteLine(result - c);
        }

        private static int Sum(int a, int b)
        {
            return a + b;
        }
    }
}
