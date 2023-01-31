using System;

namespace _03.Substring
{
    class Program
    {
        static void Main(string[] args)
        {
            string word = Console.ReadLine();
            string text = Console.ReadLine();
            int indexStart = text.IndexOf(word);
            while (indexStart >= 0)
            {
                text = text.Remove(text.IndexOf(word), word.Length);
                indexStart = text.IndexOf(word);
            }
            Console.WriteLine(text);
        }
    }
}
