using System;

namespace _02.VowelsCount
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            int result = GetNumVowels(input);
            Console.WriteLine(result);
        }

        private static int GetNumVowels(string input)
        {
            input = input.ToLower();
            int count = 0;
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == 'a' || input[i] == 'e' || input[i] == 'i' || input[i] == 'o' || input[i] == 'u')
                {
                    count++;
                }
            }
            return count;
        }
    }
}
