using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.RawDate
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Car> cars = new List<Car>();
            for (int i = 0; i < n; i++)
            {
                string[] command = Console.ReadLine().Split(' ');
                string model = command[0];
                int engineSpeed = int.Parse(command[1]);
                int enginePower = int.Parse(command[2]);
                int cargoWeight = int.Parse(command[3]);
                string cargoType = command[4];
                List<Tire> tires = new List<Tire>();
                for (int tireIndex = 5; tireIndex <= 12; tireIndex+=2)
                {
                    double tirePressure = double.Parse(command[tireIndex]);
                    int tireAge = int.Parse(command[tireIndex + 1]);
                    Tire tire = new Tire(tireAge, tirePressure);
                    tires.Add(tire);
                }
                Engine engine = new Engine(engineSpeed, enginePower);
                Cargo cargo = new Cargo(cargoType, cargoWeight);
                Car car = new Car(model, engine, cargo, tires);
                cars.Add(car);
            }
            string typeOfCargo = Console.ReadLine();
            if (typeOfCargo == "fragile")
            {
                var sorted = cars.Where(x => x.Cargo.Type == "fragile" && x.Tires.Any(t => t.Pressure < 1)).ToList();
                foreach (var car in sorted)
                {
                    Console.WriteLine(car.Model);
                }
            }
            else
            {
                var sorted = cars.Where(x => x.Cargo.Type == "flammable" && x.Engine.Power > 250).ToList();
                foreach (var car in sorted)
                {
                    Console.WriteLine(car.Model);
                }
            }
        }
    }
}
