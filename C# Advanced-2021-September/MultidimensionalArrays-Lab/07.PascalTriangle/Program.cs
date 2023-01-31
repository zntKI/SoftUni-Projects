using System;

namespace _07.PascalTriangle
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            long[][] triangle = new long[n][];
            for (int i = 0; i < n; i++)
            {
                long[] arr = new long[i + 1];
                triangle[i] = arr;
                triangle[i][0] = 1;
                triangle[i][triangle[i].Length - 1] = 1;
                for (int j = 1; j < triangle[i].Length - 1; j++)
                {
                    triangle[i][j] = triangle[i - 1][j - 1] + triangle[i - 1][j];
                }
            }
            for (int i = 0; i < triangle.GetLength(0); i++)
            {
                Console.WriteLine(string.Join(" ", triangle[i]));
            }
        }
    }
}
