using System;

namespace _08.MathPower
{
    class Program
    {
        static void Main(string[] args)
        {
            double num = double.Parse(Console.ReadLine());
            double power = double.Parse(Console.ReadLine());
            Console.WriteLine(Result(num, power));
        }
        static double Result(double num, double power)
        {
            return Math.Pow(num, power);
        }
    }
}
