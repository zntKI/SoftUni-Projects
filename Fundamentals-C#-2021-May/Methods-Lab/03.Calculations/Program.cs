using System;

namespace _03.Calculations
{
    class Program
    {
        static void Main(string[] args)
        {
            string calculation = Console.ReadLine();
            int first = int.Parse(Console.ReadLine());
            int second = int.Parse(Console.ReadLine());
            if (calculation == "add")
            {
                Add(first, second);
            }
            else if (calculation == "subtract")
            {
                Subtract(first, second);
            }
            else if (calculation == "multiply")
            {
                Multiply(first, second);
            }
            else if (calculation == "divide")
            {
                Divide(first, second);
            }
        }

        private static void Add(int first, int second)
        {
            Console.WriteLine(first+second);
        }

        private static void Subtract(int first, int second)
        {
            Console.WriteLine(first-second);
        }

        private static void Multiply(int first, int second)
        {
            Console.WriteLine(first*second);
        }

        private static void Divide(int first, int second)
        {
            Console.WriteLine(first/second);
        }
    }
}
