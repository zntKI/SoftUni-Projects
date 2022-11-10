using System;

namespace TimePlus15Min
{
    class Program
    {
        static void Main(string[] args)
        {
            int hour = int.Parse(Console.ReadLine());
            int minutes = int.Parse(Console.ReadLine());
            if (minutes < 45)
            {
                minutes += 15;
            }
            else if (minutes >= 45)
            {
                minutes = (minutes + 15) - 60;
                hour += 1;
            }
            if (hour == 24)
            {
                hour = 0;
            }
            Console.WriteLine($"{hour}:{minutes:d2}");
        }
    }
}
