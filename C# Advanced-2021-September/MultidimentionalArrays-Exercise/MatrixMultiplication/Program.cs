using System;
using System.Linq;

namespace MatrixMultiplication
{
    class Program
    {
        static void Main(string[] args)
        {
            Start: Console.Write("Coordinates of the first matrix are: ");
            int[] firstMatrixSize = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
            Console.Write("Coordinates of the second matrix are: ");
            int[] secondMatrixSize = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
            int firstRow = firstMatrixSize[0];
            int firstrCol = firstMatrixSize[1];
            int secondRow = secondMatrixSize[0];
            int secondCol = secondMatrixSize[1];
            if (firstrCol != secondRow /* && firstRow != secondCol */)
            {
                Console.WriteLine("Cannot multiply these matrices!");
                Console.WriteLine("Try again.");
                goto Start;
            }
            //else
            //{  
            //}
            int[][] firstMatrix = new int[firstRow][];
            int[][] secondMatrix = new int[secondRow][];
            Console.WriteLine("First matrix elements:");
            for (int row = 0; row < firstRow; row++)
            {
                int[] arr = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
                firstMatrix[row] = new int[arr.Length];
                for (int col = 0; col < firstrCol; col++)
                {
                    firstMatrix[row][col] = arr[col];
                }
            }
            Console.WriteLine("Second matrix elements:");
            for (int row = 0; row < secondRow; row++)
            {
                int[] arr = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
                secondMatrix[row] = new int[arr.Length];
                for (int col = 0; col < secondCol; col++)
                {
                    secondMatrix[row][col] = arr[col];
                }
            }
            //if (firstrCol == secondRow)
            //{
            //}
            int[][] resultMatrix = new int[firstRow][];
            for (int row = 0; row < firstRow; row++)
            {
                resultMatrix[row] = new int[secondCol];
            }
            for (int row = 0; row < firstMatrix.GetLength(0); row++)
            {
                int[] numbers = firstMatrix[row];
                for (int col = 0; col < secondCol; col++)
                {
                    int sum = 0;
                    for (int rows = 0; rows < secondMatrix.GetLength(0); rows++)
                    {
                        sum += numbers[rows] * secondMatrix[rows][col];
                    }
                    resultMatrix[row][col] = sum;
                }
            }
            Console.WriteLine("Result:");
            Console.WriteLine($"Matrix with {firstRow} rows and {secondCol} cols.");
            for (int row = 0; row < resultMatrix.GetLength(0); row++)
            {
                Console.WriteLine(string.Join(" ", resultMatrix[row]));
            }
        }
    }
}
