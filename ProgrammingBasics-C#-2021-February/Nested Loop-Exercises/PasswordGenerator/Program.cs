using System;

namespace PasswordGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int l = int.Parse(Console.ReadLine());
            for (int i = 1; i <= n; i++)
            {
                for (int a = 1; a <= n; a++)
                {
                    for (int b = 97; b < 97 + l; b++)
                    {
                        for (int c = 97; c < 97 + l; c++)
                        {
                            for (int d = 1; d <= n; d++)
                            {
                                if (d > i && d > a)
                                {
                                    Console.Write($"{i}{a}{(char)b}{(char)c}{d} ");
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
