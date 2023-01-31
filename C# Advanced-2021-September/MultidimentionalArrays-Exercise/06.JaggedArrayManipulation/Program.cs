using System;
using System.Linq;

namespace _06.JaggedArrayManipulation
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            double[][] matrix = new double[n][];
            for (int row = 0; row < n; row++)
            {
                int[] arr = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
                matrix[row] = new double[arr.Length];
                for (int col = 0; col < arr.Length; col++)
                {
                    matrix[row][col] = arr[col];
                }
            }
            for (int row = 0; row < matrix.GetLength(0) - 1; row++)
            {
                if (matrix[row].Length == matrix[row + 1].Length)
                {
                    for (int col = 0; col < matrix[row].Length; col++)
                    {
                        matrix[row][col] *= 2;
                        matrix[row + 1][col] *= 2;
                    }
                }
                else
                {
                    for (int col = 0; col < matrix[row].Length; col++)
                    {
                        matrix[row][col] /= 2;
                    }
                    for (int col = 0; col < matrix[row + 1].Length; col++)
                    {
                        matrix[row + 1][col] /= 2;
                    }
                }
            }
            string input = Console.ReadLine();
            while (input != "End")
            {
                string[] command = input.Split(" ");
                int row = int.Parse(command[1]);
                int col = int.Parse(command[2]);
                int value = int.Parse(command[3]);
                if (row >= 0 && row < matrix.GetLength(0) && col >= 0 && col < matrix[row].Length)
                {
                    if (command[0] == "Add")
                    {
                        matrix[row][col] += value;
                    }
                    else if (command[0] == "Subtract")
                    {
                        matrix[row][col] -= value;
                    }
                }
                input = Console.ReadLine();
            }
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                Console.WriteLine(string.Join(" ", matrix[row]));
            }
        }
    }
}
