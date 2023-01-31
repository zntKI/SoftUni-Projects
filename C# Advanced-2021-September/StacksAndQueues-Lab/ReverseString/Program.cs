using System;
using System.Collections.Generic;

namespace ReverseString
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Stack<char> chars = new Stack<char>();
            for (int i = 0; i < input.Length; i++)
            {
                chars.Push(input[i]);
            }
            foreach (var item in chars)
            {
                Console.Write(item);
            }
        }
    }
}
