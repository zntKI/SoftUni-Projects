using System;

namespace _04.TextFilter
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] banList = Console.ReadLine().Split(", ");
            string text = Console.ReadLine();
            string neww = "";
            for (int i = 0; i < banList.Length; i++)
            {
                for (int j = 0; j < banList[i].Length; j++)
                {
                    neww += "*";
                }
                text = text.Replace(banList[i], neww);
                neww = "";
            }
            Console.WriteLine(text);
        }
    }
}
