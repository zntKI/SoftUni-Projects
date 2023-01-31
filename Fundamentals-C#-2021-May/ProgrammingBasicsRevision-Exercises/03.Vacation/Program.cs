using System;

namespace _03.Vacation
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            string typeOfGroup = Console.ReadLine();
            string typeOfDay = Console.ReadLine();
            double priceForOne = 0;
            if (typeOfGroup == "Students")
            {
                if (typeOfDay == "Friday")
                {
                    priceForOne += 8.45;
                }
                else if (typeOfDay == "Saturday")
                {
                    priceForOne += 9.80;
                }
                else if (typeOfDay == "Sunday")
                {
                    priceForOne += 10.46;
                }
            }
            else if (typeOfGroup == "Business")
            {
                if (typeOfDay == "Friday")
                {
                    priceForOne += 10.90;
                }
                else if (typeOfDay == "Saturday")
                {
                    priceForOne += 15.60;
                }
                else if (typeOfDay == "Sunday")
                {
                    priceForOne += 16;
                }
            }
            else if (typeOfGroup == "Regular")
            {
                if (typeOfDay == "Friday")
                {
                    priceForOne += 15;
                }
                else if (typeOfDay == "Saturday")
                {
                    priceForOne += 20;
                }
                else if (typeOfDay == "Sunday")
                {
                    priceForOne += 22.50;
                }
            }
            double priceForAll = priceForOne * num;
            if (typeOfGroup == "Students" && num >= 30)
            {
                priceForAll = priceForAll - (priceForAll * 0.15);
            }
            if (typeOfGroup == "Business" && num >= 100)
            {
                priceForAll = priceForOne * (num - 10);
            }
            if (typeOfGroup == "Regular" && num >= 10 && num <= 20)
            {
                priceForAll = priceForAll - (priceForAll * 0.05);
            }
            Console.WriteLine($"Total price: {priceForAll:f2}");
        }
    }
}
