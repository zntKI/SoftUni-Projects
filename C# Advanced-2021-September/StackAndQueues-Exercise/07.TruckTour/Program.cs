using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.TruckTour
{
    class Program
    {
        static void Main(string[] args)
        {
            int nStations = int.Parse(Console.ReadLine());
            Queue<int[]> pumps = new Queue<int[]>();
            for (int i = 0; i < nStations; i++)
            {
                int[] infoPumps = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
                pumps.Enqueue(infoPumps);
            }
            int startIndex = 0;
            while (true)
            {
                int currentPetrol = 0;
                foreach (var info in pumps)
                {
                    int truckPetrol = info[0];
                    int truckDistance = info[1];
                    currentPetrol += truckPetrol;
                    currentPetrol -= truckDistance;
                    if (currentPetrol < 0)
                    {
                        int[] element = pumps.Dequeue();
                        pumps.Enqueue(element);
                        startIndex++;
                        break;
                    }
                }
                if (currentPetrol >= 0)
                {
                    Console.WriteLine(startIndex);
                    break;
                }
            }
        }
    }
}
