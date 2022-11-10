using System;

namespace Vacation
{
    class Program
    {
        static void Main(string[] args)
        {
            double moneyHoliday = double.Parse(Console.ReadLine());
            double moneyAvailable = double.Parse(Console.ReadLine());
            string action = Console.ReadLine();
            double money = double.Parse(Console.ReadLine());
            double sum = moneyAvailable;
            int actionCounter = 0;
            while (sum < moneyHoliday)
            {
                if (action == "spend")
                {
                    if (money > moneyAvailable)
                    {
                        sum = 0;
                    }
                    else
                    {
                        sum = sum - money;
                    }
                }
                else if (action == "save")
                {
                    sum += money;
                }
                actionCounter++;
                if (sum >= moneyHoliday)
                {
                    break;
                }
                if (actionCounter >= 5)
                {
                    Console.WriteLine("You can't save the money.");
                    Console.WriteLine(actionCounter);
                    return;
                }
                else
                {
                    action = Console.ReadLine();
                    money = double.Parse(Console.ReadLine());
                }
            }
            Console.WriteLine($"You saved the money for {actionCounter} days.");
        }
    }
}
