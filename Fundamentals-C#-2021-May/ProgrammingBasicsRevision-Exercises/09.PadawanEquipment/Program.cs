 using System;

namespace _09.PadawanEquipment
{
    class Program
    {
        static void Main(string[] args)
        {
            double moneyAvailable = double.Parse(Console.ReadLine());
            int students = int.Parse(Console.ReadLine());
            double priceForSaber = double.Parse(Console.ReadLine());
            double priceForRobe = double.Parse(Console.ReadLine());
            double priceForBelt = double.Parse(Console.ReadLine());
            double allSabers = priceForSaber * (Math.Ceiling(students + (students * 0.10)));
            double allRobes = priceForRobe * students;
            double allBelts = 0;
            if (students / 6 >= 1)
            {
                allBelts = priceForBelt * (students - (students / 6));
            }
            else
            {
                allBelts = priceForBelt * students;
            }
            double priceOfAll = allRobes + allBelts + allSabers;
            if (priceOfAll > moneyAvailable)
            {
                Console.WriteLine($"John will need {(priceOfAll - moneyAvailable):f2}lv more.");
            }
            else
            {
                Console.WriteLine($"The money is enough - it would cost {priceOfAll:f2}lv.");
            }
        }
    }
}
