using System;

namespace EqualSumsEvenOddPosition
{
    class Program
    {
        static void Main(string[] args)
        {
            int num1 = int.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());
            for (int i = num1; i <= num2; i++)
            {
                int currNum = i;
                int evenSum = 0;
                int oddSum = 0;
                int count = 0;
                while (currNum != 0)
                {
                    int digit = currNum % 10;
                    if (count % 2 == 0)
                    {
                        evenSum += digit;
                    }
                    else
                    {
                        oddSum += digit;
                    }
                    currNum /= 10;
                    count++;
                }
                if (oddSum == evenSum)
                {
                    Console.Write($"{i} ");
                }
            }
            //for (int i = num1; i <= num2; i++)
            //{
            //    string currrNum = i.ToString();
            //    int sumOddNum = 0;
            //    int sumEvenNum = 0;
            //    for (int j = 0; j < currrNum.Length; j++)
            //    {
            //        int currDigit = int.Parse(currrNum[j].ToString());
            //        if (j % 2 != 0)
            //        {
            //            sumOddNum += currDigit;
            //        }
            //        else
            //        {
            //            sumEvenNum += currDigit;
            //        }
            //    }
            //    if (sumOddNum == sumEvenNum)
            //    {
            //        Console.Write($"{i} ");
            //    }
            //}
        }
    }
}
