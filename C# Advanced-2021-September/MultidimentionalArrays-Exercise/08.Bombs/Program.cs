using System;
using System.Linq;

namespace _08.Bombs
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[,] matrix = new int[n, n];
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] arr = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = arr[col];
                }
            }
            string[] coordinates = Console.ReadLine().Split(" ");
            for (int i = 0; i < coordinates.Length; i++)
            {
                string[] coordinate = coordinates[i].Split(",");
                int bombRow = int.Parse(coordinate[0]);
                int bombCol = int.Parse(coordinate[1]);
                int bomb = matrix[bombRow, bombCol];
                if (bomb <= 0)
                {
                    continue;
                }
                matrix[bombRow, bombCol] = 0;
                if (bombRow - 1 >= 0)
                {
                    if (matrix[bombRow - 1, bombCol] > 0)
                    {
                        matrix[bombRow - 1, bombCol] -= bomb;
                    }
                }
                if (bombRow - 1 >= 0 && bombCol + 1 < matrix.GetLength(1))
                {
                    if (matrix[bombRow - 1, bombCol + 1] > 0)
                    {
                        matrix[bombRow - 1, bombCol + 1] -= bomb;
                    }
                }
                if (bombCol + 1 < matrix.GetLength(1))
                {
                    if (matrix[bombRow, bombCol + 1] > 0)
                    {
                        matrix[bombRow, bombCol + 1] -= bomb;
                    }
                }
                if (bombRow + 1 < matrix.GetLength(0) && bombCol + 1 < matrix.GetLength(1))
                {
                    if (matrix[bombRow + 1, bombCol + 1] > 0)
                    {
                        matrix[bombRow + 1, bombCol + 1] -= bomb;
                    }
                }
                if (bombRow + 1 < matrix.GetLength(0))
                {
                    if (matrix[bombRow + 1, bombCol] > 0)
                    {
                        matrix[bombRow + 1, bombCol] -= bomb;
                    }
                }
                if (bombRow + 1 < matrix.GetLength(0) && bombCol - 1 >= 0)
                {
                    if (matrix[bombRow + 1, bombCol - 1] > 0)
                    {
                        matrix[bombRow + 1, bombCol - 1] -= bomb;
                    }
                }
                if (bombCol - 1 >= 0)
                {
                    if (matrix[bombRow, bombCol - 1] > 0)
                    {
                        matrix[bombRow, bombCol - 1] -= bomb;
                    }
                }
                if (bombRow - 1 >= 0 && bombCol - 1 >= 0)
                {
                    if (matrix[bombRow - 1, bombCol - 1] > 0)
                    {
                        matrix[bombRow - 1, bombCol - 1] -= bomb;
                    }
                }
            }
            int count = 0;
            int sum = 0;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] > 0)
                    {
                        count++;
                        sum += matrix[row, col];
                    }
                }
            }
            Console.WriteLine($"Alive cells: {count}");
            Console.WriteLine($"Sum: {sum}");
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write($"{matrix[row, col]} ");
                }
                Console.WriteLine();
            }
        }
    }
}
