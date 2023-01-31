using System;
using System.Linq;

namespace _09.Miner
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[,] field = new char[n, n];
            string[] commands = Console.ReadLine().Split(" ");
            int Row = 0;
            int Col = 0;
            int countCoal = 0;
            for (int row = 0; row < field.GetLength(0); row++)
            {
                char[] arr = Console.ReadLine().Split(" ").Select(char.Parse).ToArray();
                for (int col = 0; col < field.GetLength(1); col++)
                {
                    if (arr[col] == 's')
                    {
                        Row = row;
                        Col = col;
                    }
                    else if (arr[col] == 'c')
                    {
                        countCoal++;
                    }
                    field[row, col] = arr[col];
                }
            }
            int collectedCoal = 0;
            for (int i = 0; i < commands.Length; i++)
            {
                string command = commands[i];
                if (command == "up")
                {
                    if (Row - 1 >= 0)
                    {
                        Row -= 1;
                    }
                    else
                    {
                        continue;
                    }
                }
                else if (command == "right")
                {
                    if (Col + 1 < field.GetLength(1))
                    {
                        Col += 1;
                    }
                    else
                    {
                        continue;
                    }
                }
                else if (command == "down")
                {
                    if (Row + 1 < field.GetLength(0))
                    {
                        Row += 1;
                    }
                    else
                    {
                        continue;
                    }
                }
                else if (command == "left")
                {
                    if (Col - 1 >= 0)
                    {
                        Col -= 1;
                    }
                    else
                    {
                        continue;
                    }
                }
                if (field[Row, Col] == 'c')
                {
                    collectedCoal++;
                    field[Row, Col] = '*';
                    if (countCoal - collectedCoal == 0)
                    {
                        Console.WriteLine($"You collected all coals! ({Row}, {Col})");
                        return;
                    }
                }
                else if (field[Row, Col] == 'e')
                {
                    Console.WriteLine($"Game over! ({Row}, {Col})");
                    return;
                }
            }
            Console.WriteLine($"{countCoal - collectedCoal} coals left. ({Row}, {Col})");
        }
    }
}
