using System;

namespace _10.PokeMon
{
    class Program
    {
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());
            int M = int.Parse(Console.ReadLine());
            int Y = int.Parse(Console.ReadLine());
            int NOrigin = N;
            int countPokes = 0;
            while (N >= M)
            {
                N -= M;
                countPokes++;
                if (N == NOrigin / 2 && Y > 0)
                {
                    N /= Y;
                }
            }
            Console.WriteLine(N);
            Console.WriteLine(countPokes);
        }
    }
}
