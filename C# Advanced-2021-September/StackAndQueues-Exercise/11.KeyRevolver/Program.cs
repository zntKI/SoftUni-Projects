using System;
using System.Collections.Generic;
using System.Linq;

namespace _11.KeyRevolver
{
    class Program
    {
        static void Main(string[] args)
        {
            int priceBullet = int.Parse(Console.ReadLine());
            int gunSize = int.Parse(Console.ReadLine());
            int[] bulletsV = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
            int[] locksV = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
            int priceValue = int.Parse(Console.ReadLine());
            Stack<int> bullets = new Stack<int>(bulletsV);
            Queue<int> locks = new Queue<int>(locksV);
            int countBul = 0;
            int sumOfBul = 0;
            while (bullets.Count > 0 && locks.Count > 0)
            {
                int bullet = bullets.Pop();
                sumOfBul += priceBullet;
                countBul++;
                int lockk = locks.Peek();
                if (bullet <= lockk)
                {
                    Console.WriteLine("Bang!");
                    locks.Dequeue();
                }
                else
                {
                    Console.WriteLine("Ping!");
                }
                if (countBul == gunSize)
                {
                    if (bullets.Count == 0)
                    {
                        continue;
                    }
                    Console.WriteLine("Reloading!");
                    countBul = 0;
                }
            }
            if (locks.Count == 0)
            {
                Console.WriteLine($"{bullets.Count} bullets left. Earned ${priceValue - sumOfBul}");
            }
            else
            {
                Console.WriteLine($"Couldn't get through. Locks left: {locks.Count}");
            }
        }
    }
}
