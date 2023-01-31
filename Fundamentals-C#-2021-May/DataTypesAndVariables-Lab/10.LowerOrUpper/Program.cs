using System;

namespace _10.LowerOrUpper
{
    class Program
    {
        static void Main(string[] args)
        {
            char n = char.Parse(Console.ReadLine());
            char a = char.ToUpper(n);
            char b = char.ToLower(n);
            if (n == a)
            {
                Console.WriteLine("upper-case");
            }
            else if (n == b)
            {
                Console.WriteLine("lower-case");
            }
        }
    }
}
