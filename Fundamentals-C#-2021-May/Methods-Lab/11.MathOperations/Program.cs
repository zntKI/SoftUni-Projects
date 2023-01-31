using System;

namespace _11.MathOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            int num1 = int.Parse(Console.ReadLine());
            string oper = Console.ReadLine();
            int num2 = int.Parse(Console.ReadLine());
            Console.WriteLine(DoTheOperation(num1, num2, oper));
        }

        private static double DoTheOperation(int num1, int num2, string oper)
        {
            double result = 0;
            switch (oper)
            {
                case "+":
                    result = num1 + num2;
                    break;
                case "-":
                    result = num1 - num2;
                    break;
                case "*":
                    result = num1 * num2;
                    break;
                case "/":
                    result = num1 / num2;
                    break;
            }
            return result;
        }
    }
}
