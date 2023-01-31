using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.FashionBoutique
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
            int cap = int.Parse(Console.ReadLine());
            Stack<int> clothes = new Stack<int>();
            for (int i = 0; i < arr.Length; i++)
            {
                clothes.Push(arr[i]);
            }
            int sum = 0;
            int racks = 1;
            //foreach (var cloth in clothes)
            //{
            //    sum += cloth;
            //    clothes.Pop();
            //    if (sum == cap)
            //    {
            //        if (clothes.Count > 0)
            //        {
            //            racks++;
            //            sum = 0;
            //        }
            //        else
            //        {
            //            break;
            //        }
            //    }
            //    else if (sum > cap)
            //    {
            //        racks++;
            //        sum = 0;
            //    }
            //}
            while (clothes.Count > 0)
            {
                int cloth = clothes.Peek();
                sum += cloth;
                clothes.Pop();
                if (sum == cap)
                {
                    if (clothes.Count > 0)
                    {
                        racks++;
                        sum = 0;
                    }
                    else
                    {
                        break;
                    }
                }
                else if (sum > cap)
                {
                    racks++;
                    sum = cloth;
                }
            }
            Console.WriteLine(racks);
        }
    }
}
