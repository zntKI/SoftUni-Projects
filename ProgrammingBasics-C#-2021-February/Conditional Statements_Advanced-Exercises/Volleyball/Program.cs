using System;

namespace Volleyball
{
    class Program
    {
        static void Main(string[] args)
        {
            string year = Console.ReadLine();
            double holidays = double.Parse(Console.ReadLine());
            double travels = double.Parse(Console.ReadLine());
            double weeksWithNoTravel = 48 - travels;
            double saturdayGames = weeksWithNoTravel - weeksWithNoTravel * 0.25;
            double holidayGames = (holidays * 2) / 3;
            double sum = travels + saturdayGames + holidayGames;
            if (year == "leap")
            {
                sum = sum + sum * 0.15;
            }
            else
            {
                sum = sum;
            }
            Console.WriteLine(Math.Floor(sum));
        }
    }
}
