using System;

namespace NeedForSpeed
{
    public class ProgramSpeed
    {
        public static void Main(string[] args)
        {
            string line = Console.ReadLine();
            int horsePower = int.Parse(Console.ReadLine());
            double fuel = double.Parse(Console.ReadLine());
            double kilometers = double.Parse(Console.ReadLine());
            if (line == "Vehicle")
            {
                Vehicle vehicle = new Vehicle(horsePower, fuel);
                vehicle.Drive(kilometers);
                Console.WriteLine($"Left fuel {vehicle.Fuel}");
            }
            else if (line == "Motorcycle")
            {
                Motorcycle motorcycle = new Motorcycle(horsePower, fuel);
                motorcycle.Drive(kilometers);
                Console.WriteLine($"Left fuel {motorcycle.Fuel:f2}");
            }
            else if (line == "Car")
            {
                Car car = new Car(horsePower, fuel);
                car.Drive(kilometers);
                Console.WriteLine($"Left fuel {car.Fuel:f2}");
            }
            else if (line == "RaceMotorcycle")
            {
                RaceMotorcycle raceMotorcycle = new RaceMotorcycle(horsePower, fuel);
                raceMotorcycle.Drive(kilometers);
                Console.WriteLine($"Left fuel {raceMotorcycle.Fuel:f2}");
            }
            else if (line == "CrossMotorcycle")
            {
                CrossMotorcycle crossMotorcycle = new CrossMotorcycle(horsePower, fuel);
                crossMotorcycle.Drive(kilometers);
                Console.WriteLine($"Left fuel {crossMotorcycle.Fuel:f2}");
            }
            else if (line == "FamilyCar")
            {
                FamilyCar familyCar = new FamilyCar(horsePower, fuel);
                familyCar.Drive(kilometers);
                Console.WriteLine($"Left fuel {familyCar.Fuel:f2}");
            }
            else if (line == "SportCar")
            {
                SportCar sportCar = new SportCar(horsePower, fuel);
                sportCar.Drive(kilometers);
                Console.WriteLine($"Left fuel {sportCar.Fuel:f2}");
            }
        }
    }
}
