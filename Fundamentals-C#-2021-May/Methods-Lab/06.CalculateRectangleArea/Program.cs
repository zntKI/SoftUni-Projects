using System;

namespace _06.CalculateRectangleArea
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            int result = Area(a, b);
            Console.WriteLine(result);
        }
        static int Area(int a, int b)
        {
            return a * b;
        }
    }
}
