using System;

namespace _01.Vehicles
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] carInfo = Console.ReadLine().Split(' ');
            IVehicle car = new Car(double.Parse(carInfo[1]), double.Parse(carInfo[2]), double.Parse(carInfo[3]));
            string[] truckInfo = Console.ReadLine().Split(' ');
            IVehicle truck = new Truck(double.Parse(truckInfo[1]), double.Parse(truckInfo[2]), double.Parse(truckInfo[3]));
            string[] busInfo = Console.ReadLine().Split(' ');
            IVehicle bus = new Bus(double.Parse(busInfo[1]), double.Parse(busInfo[2]), double.Parse(busInfo[3]));
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                try
                {
                    string[] command = Console.ReadLine().Split(' ');
                    double value = double.Parse(command[2]);
                    if (command[0] == "Drive" && command[1] == "Car")
                    {
                        if (car.CandDrive(value))
                        {
                            car.Drive(value);
                            Console.WriteLine($"Car travelled {value} km");
                        }
                        else
                        {
                            Console.WriteLine("Car needs refueling");
                        }
                    }
                    else if (command[0] == "Drive" && command[1] == "Truck")
                    {
                        if (truck.CandDrive(value))
                        {
                            truck.Drive(value);
                            Console.WriteLine($"Truck travelled {value} km");
                        }
                        else
                        {
                            Console.WriteLine("Truck needs refueling");
                        }
                    }
                    else if (command[0].Contains("Drive") && command[1] == "Bus")
                    {
                        if (command[0] == "Drive")
                        {
                            bus.IsEmpty = false;
                            if (bus.CandDrive(value))
                            {
                                bus.Drive(value);
                                Console.WriteLine($"Bus travelled {value} km");
                            }
                            else
                            {
                                Console.WriteLine("Bus needs refueling");
                            }
                        }
                        else
                        {
                            bus.IsEmpty = true;
                            if (bus.CandDrive(value))
                            {
                                bus.Drive(value);
                                Console.WriteLine($"Bus travelled {value} km");
                            }
                            else
                            {
                                Console.WriteLine("Bus needs refueling");
                            }
                        }
                    }
                    else if (command[0] == "Refuel" && command[1] == "Car")
                    {
                        car.Refuel(value);
                    }
                    else if (command[0] == "Refuel" && command[1] == "Truck")
                    {
                        truck.Refuel(value);
                    }
                    else if (command[0] == "Refuel" && command[1] == "Bus")
                    {
                        bus.Refuel(value);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            Console.WriteLine($"Car: {(decimal)car.FuelQuantity:f2}");
            Console.WriteLine($"Truck: {(decimal)truck.FuelQuantity:f2}");
            Console.WriteLine($"Bus: {(decimal)bus.FuelQuantity:f2}");
        }
    }
}
