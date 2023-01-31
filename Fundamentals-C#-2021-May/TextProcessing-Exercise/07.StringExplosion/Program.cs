using System;
using System.Text;

namespace _07.StringExplosion
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            StringBuilder sb = new StringBuilder(input);
            int count = 0;
            int reminder = 0;
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '>')
                {
                    int power = int.Parse(input[i + 1].ToString()) + reminder;
                    int leftPower = power;
                    bool shouldReset = true;
                    for (int j = i + 1; j < i + power + 1 && j < input.Length; j++)
                    {
                        if (input[j] == '>')
                        {
                            reminder = leftPower;
                            shouldReset = false;
                            break;
                        }
                        sb.Remove(j - count, 1);
                        leftPower--;
                        count++;
                    }
                    if (shouldReset)
                    {
                        reminder = 0;
                    }
                }
            }
            Console.WriteLine(sb);
        }
    }
}
