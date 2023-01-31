using System;
using System.Linq;

namespace _01.DiagonalDiff
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[,] matrix = new int[n, n];
            for (int rows = 0; rows < n; rows++)
            {
                int[] arr = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
                for (int cols = 0; cols < n; cols++)
                {
                    matrix[rows, cols] = arr[cols];
                }
            }
            int sumP = 0;
            int sumS = 0;
            for (int rows = 0; rows < n; rows++)
            {
                sumP += matrix[rows, rows];
            }
            int rowss = 0;
            for (int cols = n - 1; cols >= 0; cols--)
            {
                sumS += matrix[rowss, cols];
                rowss++;
            }
            Console.WriteLine(Math.Abs(sumP - sumS));
        }
    }
}
