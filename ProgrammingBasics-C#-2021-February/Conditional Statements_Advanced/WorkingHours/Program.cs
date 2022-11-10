using System;

namespace WorkingHours
{
    class Program
    {
        static void Main(string[] args)
        {
            int hourOfDay = int.Parse(Console.ReadLine());
            string dayOfWeek = Console.ReadLine();
            if (hourOfDay >= 10 && hourOfDay <=18)
            {
                switch (dayOfWeek)
                {
                    case "Monday":
                    case "Tuesday":
                    case "Wednesday":
                    case "Thursday":
                    case "Friday":
                    case "Saturday":
                        Console.WriteLine("open");
                        break;
                    case "Sunday":
                        Console.WriteLine("closed");
                        break;
                }
            }
            else
            {
                Console.WriteLine("closed");
            }
        }
    }
}
