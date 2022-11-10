using System;

namespace NumberPyramid
{
    class Program
    {
        static void Main(string[] args)
        {
            int targetNum = int.Parse(Console.ReadLine());
            int currNum = 1;
            int row = 1;
            while (true)
            {
                for (int i = 1; i <= row; i++)
                {
                    Console.Write($"{currNum} ");
                    currNum++;
                    if (currNum > targetNum)
                    {
                        return;
                    }
                }
                Console.WriteLine();
                row++;
            }
            //for (int row = 0; row <= targetNum; row++)
            //{
            //    for (int col = 0; col <= row; col++)
            //    {
            //        Console.Write($"{currNum} ");
            //        currNum++;
            //        if (currNum > targetNum)
            //        {
            //            return;
            //        }
            //    }
            //    Console.WriteLine();
            //}
        }
    }
}
