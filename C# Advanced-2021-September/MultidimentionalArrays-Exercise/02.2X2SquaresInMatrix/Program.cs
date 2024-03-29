﻿using System;
using System.Linq;

namespace _02._2X2SquaresInMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
            int rows = dimensions[0];
            int cols = dimensions[1];
            char[,] matrix = new char[rows, cols];
            for (int row = 0; row < rows; row++)
            {
                char[] arr = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();
                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = arr[col];
                }
            }
            int count = 0;
            for (int row = 0; row < rows - 1; row++)
            {
                for (int col = 0; col < cols - 1; col++)
                {
                    char letter = matrix[row, col];
                    if (matrix[row, col + 1] == letter && matrix[row + 1, col] == letter && matrix[row + 1, col + 1] == letter)
                    {
                        count++;
                    }
                }
            }
            Console.WriteLine(count);
        }
    }
}
