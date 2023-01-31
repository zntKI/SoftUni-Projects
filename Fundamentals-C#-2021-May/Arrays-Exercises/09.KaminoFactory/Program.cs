using System;
using System.Linq;

namespace _09.KaminoFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string input = Console.ReadLine();
            int count = 1;
            int maxCount = 1;
            //int currMaxCount = 0;
            while (input != "Clone them!")
            {
                int[] arr = input.Split("!").Select(int.Parse).ToArray();
                for (int i = 0; i < arr.Length - 1; i++)
                {
                    if (arr[i] == arr[i + 1])
                    {
                        count++;
                    }
                    else
                    {
                        count = 1;
                    }
                    if (count > maxCount)
                    {
                        maxCount = count;
                    }
                }
                input = Console.ReadLine();
            }
            Console.WriteLine(maxCount);
        }
    }
}
