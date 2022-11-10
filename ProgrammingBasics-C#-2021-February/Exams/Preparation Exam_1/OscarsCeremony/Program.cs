using System;

namespace OscarsCeremony
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            string typeOfHall = Console.ReadLine();
            int numTickets = int.Parse(Console.ReadLine());
            double income = 0;
            if (name == "A Star Is Born")
            {
                if (typeOfHall == "normal")
                {
                    income = numTickets * 7.50;
                }
                else if (typeOfHall == "luxury")
                {
                    income = numTickets * 10.50;
                }
                else if (typeOfHall == "ultra luxury")
                {
                    income = numTickets * 13.50;
                }
            }
            else if (name == "Bohemian Rhapsody")
            {
                if (typeOfHall == "normal")
                {
                    income = numTickets * 7.35;
                }
                else if (typeOfHall == "luxury")
                {
                    income = numTickets * 9.45;
                }
                else if (typeOfHall == "ultra luxury")
                {
                    income = numTickets * 12.75;
                }
            }
            else if (name == "Green Book")
            {
                if (typeOfHall == "normal")
                {
                    income = numTickets * 8.15;
                }
                else if (typeOfHall == "luxury")
                {
                    income = numTickets * 10.25;
                }
                else if (typeOfHall == "ultra luxury")
                {
                    income = numTickets * 13.25;
                }
            }
            else if (name == "The Favourite")
            {
                if (typeOfHall == "normal")
                {
                    income = numTickets * 8.75;
                }
                else if (typeOfHall == "luxury")
                {
                    income = numTickets * 11.55;
                }
                else if (typeOfHall == "ultra luxury")
                {
                    income = numTickets * 13.95;
                }
            }
            Console.WriteLine($"{name} -> {income:f2} lv.");
        }
    }
}
