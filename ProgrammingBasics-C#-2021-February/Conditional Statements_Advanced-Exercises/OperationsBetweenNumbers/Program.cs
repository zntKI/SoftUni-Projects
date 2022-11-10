using System;

namespace OperationsBetweenNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            double number1 = int.Parse(Console.ReadLine());
            double number2 = int.Parse(Console.ReadLine());
            char operation = char.Parse(Console.ReadLine());
            switch (operation)
            {
                case '+':
                    if ((number1 + number2) % 2 == 0)
                    {
                        Console.WriteLine($"{number1} + {number2} = {number1 + number2} - even");
                    }
                    else
                    {
                        Console.WriteLine($"{number1} + {number2} = {number1 + number2} - odd");
                    }
                    break;
                case '-':
                    if ((number1 - number2) % 2 == 0)
                    {
                        Console.WriteLine($"{number1} - {number2} = {number1 - number2} - even");
                    }
                    else
                    {
                        Console.WriteLine($"{number1} - {number2} = {number1 - number2} - odd");
                    }
                    break;
                case '*':
                    if ((number1 * number2) % 2 == 0)
                    {
                        Console.WriteLine($"{number1} * {number2} = {number1 * number2} - even");
                    }
                    else
                    {
                        Console.WriteLine($"{number1} * {number2} = {number1 * number2} - odd");
                    }
                    break;
                case '/':
                    if (number2 == 0)
                    {
                        Console.WriteLine($"Cannot divide {number1} by zero");
                    }
                    else
                    {
                        Console.WriteLine($"{number1} / {number2} = {(number1 / number2):f2}");
                    }
                    break;
                case '%':
                    if (number2 == 0)
                    {
                        Console.WriteLine($"Cannot divide {number1} by zero");
                    }
                    else
                    {
                        Console.WriteLine($"{number1} % {number2} = {number1 % number2}");
                    }
                    break;
                default:
                    break;
            }
        }
    }
}
