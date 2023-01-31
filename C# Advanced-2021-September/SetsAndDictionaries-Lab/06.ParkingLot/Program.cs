using System;
using System.Collections.Generic;

namespace _06.ParkingLot
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            HashSet<string> cars = new HashSet<string>();
            while (input != "END")
            {
                string[] command = input.Split(", ");
                string direction = command[0];
                string carNum = command[1];
                if (direction == "IN")
                {
                    cars.Add(carNum);
                }
                else
                {
                    cars.Remove(carNum);
                }
                input = Console.ReadLine();
            }
            if (cars.Count > 0)
            {
                foreach (var car in cars)
                {
                    Console.WriteLine(car);
                }
            }
            else
            {
                Console.WriteLine("Parking Lot is Empty");
            }
        }
    }
}
