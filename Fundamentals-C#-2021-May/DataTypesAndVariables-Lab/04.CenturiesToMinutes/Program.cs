using System;

namespace _04.CenturiesToMinutes
{
    class Program
    {
        static void Main(string[] args)
        {
            int cen = int.Parse(Console.ReadLine());
            int years = cen * 100;
            int days = (int)(years * 365.2422);
            uint hours = (uint)(days * 24);
            long min = hours * 60;
            Console.WriteLine($"{cen} centuries = {years} years = {days} days = {hours} hours = {min} minutes");
        }
    }
}
