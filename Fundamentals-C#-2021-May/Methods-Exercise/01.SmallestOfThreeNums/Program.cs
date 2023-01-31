using System;

namespace _01.SmallestOfThreeNums
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            int c = int.Parse(Console.ReadLine());
            int result = GetMaxOfThree(a, b, c);
            Console.WriteLine(result);
        }

        private static int GetMaxOfThree(int a, int b, int c)
        {
            int minNum = b;
            if (a < b)
            {
                minNum = a;
            }
            if (c < minNum)
            {
                minNum = c;
            }
            return minNum;
        }
    }
}
