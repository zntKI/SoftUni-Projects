using System;

namespace _07.RepeatString
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            int count = int.Parse(Console.ReadLine());
            Console.WriteLine(Repeat(text, count));
        }
        static string Repeat(string text, int count)
        {
            string text1 = "";
            for (int i = 1; i <= count; i++)
            {
                text1 += text;
            }
            return text1;
        }
    }
}
