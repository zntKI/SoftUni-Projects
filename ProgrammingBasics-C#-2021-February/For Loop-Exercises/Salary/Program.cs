using System;

namespace Salary
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            double salary = double.Parse(Console.ReadLine());
            double fine = 0;
            for (int i = 1; i <= n; i++)
            {
                string site = Console.ReadLine();
                if (site == "Facebook")
                {
                    fine += 150;
                }
                else if (site == "Instagram")
                {
                    fine += 100;
                }
                else if (site == "Reddit")
                {
                    fine += 50;
                }
                else
                {
                    fine += 0;
                }
            }
            if ((salary - fine) <= 0)
            {
                Console.WriteLine("You have lost your salary.");
            }
            else
            {
                Console.WriteLine(salary - fine);
            }
        }
    }
}
