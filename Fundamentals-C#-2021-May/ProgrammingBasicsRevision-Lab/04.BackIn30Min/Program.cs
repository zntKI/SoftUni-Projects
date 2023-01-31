using System;

namespace _04.BackIn30Min
{
    class Program
    {
        static void Main(string[] args)
        {
            int hour = int.Parse(Console.ReadLine());
            int minutes = int.Parse(Console.ReadLine());
            if (hour < 23 && minutes < 30)
            {
                minutes += 30;
            }
            else if (hour < 23 && minutes >= 30)
            {
                hour += 1;
                minutes -= 30;
            }
            else if(hour == 23 && minutes >= 30)
            {
                hour = 0;
                minutes -= 30;
            }
            if (minutes < 10)
            {
                Console.WriteLine($"{hour}:{minutes:d2}");
            }
            else
            {
                Console.WriteLine($"{hour}:{minutes}");
            }
        }
    }
}
