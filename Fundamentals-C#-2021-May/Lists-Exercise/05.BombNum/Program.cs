using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.BombNum
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> list = Console.ReadLine().Split().Select(int.Parse).ToList();
            int[] arrNums = Console.ReadLine().Split().Select(int.Parse).ToArray();
            for (int i = 0; i < list.Count; i++)
            {
                // 1 2 2 (4) 2 2 2 9
                int bombNum = arrNums[0];
                int powerOfNum = arrNums[1];
                if (list[i] == bombNum)
                {
                    for (int j = i - powerOfNum; j <= i + powerOfNum; j++)
                    {
                        if (j < 0 || j >= list.Count)
                        {
                            continue;
                        }
                        list[j] = 0;
                    }
                }
            }
            Console.WriteLine(list.Sum());
        }
    }
}
