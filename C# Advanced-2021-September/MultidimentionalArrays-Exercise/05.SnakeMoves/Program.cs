using System;
using System.Linq;

namespace _05.SnakeMoves
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
            int rows = dimensions[0];
            int cols = dimensions[1];
            char[,] matrix = new char[rows, cols];
            string snake = Console.ReadLine();
            bool leftToRight = true;
            int counter = 0;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                if (leftToRight)
                {
                    for (int col = 0; col < matrix.GetLength(1); col++)
                    {
                        matrix[row, col] = snake[counter];
                        if (counter == snake.Length - 1)
                        {
                            counter = 0;
                            continue;
                        }
                        counter++;
                    }
                    leftToRight = false;
                }
                else
                {
                    for (int col = matrix.GetLength(1) - 1; col >= 0; col--)
                    {
                        matrix[row, col] = snake[counter];
                        if (counter == snake.Length - 1)
                        {
                            counter = 0;
                            continue;
                        }
                        counter++;
                    }
                    leftToRight = true;
                }
            }
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    Console.Write($"{matrix[row, col]}");
                }
                Console.WriteLine();
            }
        }
    }
}
