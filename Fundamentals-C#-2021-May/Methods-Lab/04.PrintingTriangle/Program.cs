using System;

namespace _04.PrintingTriangle
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Pyramid(n);
        }

        private static void Pyramid(int n)
        {
            for (int i = 1; i <= n; i++)
            {
                Collums(i);
            }
            for (int i = n-1; i >= 1; i--)
            {
                Collums(i);
            }
        }

        private static void Collums(int i)
        {
            for (int j = 1; j <= i; j++)
            {
                Console.Write(j + " ");
            }
            Console.WriteLine();
        }
    }
}
