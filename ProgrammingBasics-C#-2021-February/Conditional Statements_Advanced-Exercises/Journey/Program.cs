using System;

namespace Journey
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            string season = Console.ReadLine();
            double price = 0.0;
            string holidayPlace = "";
            string placeOfHoliday = "";
            if (budget <= 100)
            {
                placeOfHoliday = "Bulgaria";
                if (season == "summer")
                {
                    price = 0.30 * budget;
                    holidayPlace = "Camp";
                }
                else if (season == "winter")
                {
                    price = 0.70 * budget;
                    holidayPlace = "Hotel";
                }
            }
            else if (budget <= 1000)
            {
                placeOfHoliday = "Balkans";
                if (season == "summer")
                {
                    price = 0.40 * budget;
                    holidayPlace = "Camp";
                }
                else if (season == "winter")
                {
                    price = 0.80 * budget;
                    holidayPlace = "Hotel";
                }
            }
            else if (budget > 1000)
            {
                placeOfHoliday = "Europe";
                price = 0.90 * budget;
                holidayPlace = "Hotel";
            }
            Console.WriteLine($"Somewhere in {placeOfHoliday}");
            Console.WriteLine($"{holidayPlace} - {price:f2}");
        }
    }
}
