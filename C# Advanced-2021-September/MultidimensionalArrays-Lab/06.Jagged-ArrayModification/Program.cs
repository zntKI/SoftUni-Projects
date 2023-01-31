using System;
using System.Linq;

namespace _06.Jagged_ArrayModification
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[,] matrix = new int[n, n];
            for (int row = 0; row < n; row++)
            {
                int[] arr = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = arr[col];
                }
            }
            string input = Console.ReadLine();
            while (input != "END")
            {
                string[] command = input.Split(" ");
                string name = command[0];
                int roww = int.Parse(command[1]);
                int coll = int.Parse(command[2]);
                int value = int.Parse(command[3]);
                if ((roww < 0 || roww >= matrix.GetLength(0)) || (coll < 0 || coll >= matrix.GetLength(1)))
                {
                    Console.WriteLine("Invalid coordinates");
                    input = Console.ReadLine();
                    continue;
                }
                if (name == "Add")
                {
                    for (int row = 0; row < matrix.GetLength(0); row++)
                    {
                        for (int col = 0; col < matrix.GetLength(1); col++)
                        {
                            if (row == roww && col == coll)
                            {
                                matrix[row, col] += value;
                            }
                        }
                    }
                }
                else if (name == "Subtract")
                {
                    for (int row = 0; row < matrix.GetLength(0); row++)
                    {
                        for (int col = 0; col < matrix.GetLength(1); col++)
                        {
                            if (row == roww && col == coll)
                            {
                                matrix[row, col] -= value;
                            }
                        }
                    }
                }
                input = Console.ReadLine();
            }
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
