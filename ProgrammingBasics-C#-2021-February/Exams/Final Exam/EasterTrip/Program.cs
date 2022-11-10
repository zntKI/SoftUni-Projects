using System;

namespace EasterTrip
{
    class Program
    {
        static void Main(string[] args)
        {
            string destination = Console.ReadLine();
            string dates = Console.ReadLine();
            int numNights = int.Parse(Console.ReadLine());
            int priceForOneNight = 0;
            if (destination == "France")
            {
                if (dates == "21-23")
                {
                    priceForOneNight += 30;
                }
                else if (dates == "24-27")
                {
                    priceForOneNight += 35;
                }
                else if (dates == "28-31")
                {
                    priceForOneNight += 40;
                }
            }
            else if (destination == "Italy")
            {
                if (dates == "21-23")
                {
                    priceForOneNight += 28;
                }
                else if (dates == "24-27")
                {
                    priceForOneNight += 32;
                }
                else if (dates == "28-31")
                {
                    priceForOneNight += 39;
                }
            }
            else if (destination == "Germany")
            {
                if (dates == "21-23")
                {
                    priceForOneNight += 32;
                }
                else if (dates == "24-27")
                {
                    priceForOneNight += 37;
                }
                else if (dates == "28-31")
                {
                    priceForOneNight += 43;
                }
            }
            int expences = priceForOneNight * numNights;
            Console.WriteLine($"Easter trip to {destination} : {expences:f2} leva.");
        }
    }
}
