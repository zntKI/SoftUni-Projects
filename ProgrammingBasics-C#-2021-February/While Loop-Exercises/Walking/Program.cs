using System;

namespace Walking
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            int sumSteps = 0;
            while (input != "Going home")
            {
                int steps = int.Parse(input);
                sumSteps += steps;
                if (sumSteps >= 10000)
                {
                    Console.WriteLine("Goal reached! Good job!");
                    Console.WriteLine($"{sumSteps - 10000} steps over the goal!");
                    return;
                }
                else
                {
                    input = Console.ReadLine();
                }
            }
            int stepsAfterGoingHome = int.Parse(Console.ReadLine());
            sumSteps += stepsAfterGoingHome;
            if (sumSteps >= 10000)
            {
                Console.WriteLine("Goal reached! Good job!");
                Console.WriteLine($"{sumSteps - 10000} steps over the goal!");
            }
            else
            {
                Console.WriteLine($"{10000 - sumSteps} more steps to reach goal.");
            }
        }
    }
}
