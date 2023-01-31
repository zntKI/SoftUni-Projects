using System;

namespace _09.CharsToString
{
    class Program
    {
        public static object CharTool { get; private set; }

        static void Main(string[] args)
        {
            char first = char.Parse(Console.ReadLine());
            char second = char.Parse(Console.ReadLine());
            char third = char.Parse(Console.ReadLine());
            char[] chars = { first, second, third };
            string sum = new string(chars);
            Console.WriteLine(sum);
            //string first = console.readline();
            //string second = console.readline(); ;
            //string third = console.readline();
            //console.writeline(first + second + third);
        }
    }
}
