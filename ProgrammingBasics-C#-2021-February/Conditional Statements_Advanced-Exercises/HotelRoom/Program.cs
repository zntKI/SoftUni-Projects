using System;

namespace HotelRoom
{
    class Program
    {
        static void Main(string[] args)
        {
            string month = Console.ReadLine();
            int nights = int.Parse(Console.ReadLine());
            double studioPrice = 0.0;
            double apartmentPrice = 0.0;
            if (month == "May" || month == "October")
            {
                studioPrice += 50;
                apartmentPrice += 65;
                if (nights > 7 && nights <= 14)
                {
                    studioPrice = studioPrice - studioPrice * 0.05;
                }
                else if (nights > 14)
                {
                    studioPrice = studioPrice - studioPrice * 0.30;
                    apartmentPrice = apartmentPrice - apartmentPrice * 0.10;
                }
                else
                {
                    studioPrice = studioPrice;
                    apartmentPrice = apartmentPrice;
                }
            }
            else if (month == "June" || month == "September")
            {
                studioPrice += 75.20;
                apartmentPrice += 68.70;
                if (nights > 14)
                {
                    studioPrice = studioPrice - studioPrice * 0.20;
                    apartmentPrice = apartmentPrice - apartmentPrice * 0.10;
                }
                else
                {
                    studioPrice = studioPrice;
                    apartmentPrice = apartmentPrice;
                }
            }
            else if (month == "July" || month == "August")
            {
                studioPrice += 76;
                apartmentPrice += 77;
                if (nights > 14)
                {
                    apartmentPrice = apartmentPrice - apartmentPrice * 0.10;
                }
                else
                {
                    studioPrice = studioPrice;
                    apartmentPrice = apartmentPrice;
                }
            }
            Console.WriteLine($"Apartment: {(apartmentPrice * nights):f2} lv.");
            Console.WriteLine($"Studio: {(studioPrice * nights):f2} lv.");
        }
    }
}
