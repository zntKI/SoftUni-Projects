﻿using System;

namespace _01.ReverseStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            string word = Console.ReadLine();
            while (word != "end")
            {
                string newWord = "";
                for (int i = word.Length - 1; i >= 0; i--)
                {
                    newWord += word[i];
                }
                Console.WriteLine($"{word} = {newWord}");
                word = Console.ReadLine();
            }
        }
    }
}
