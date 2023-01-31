using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace SoftUniParking
{
    public class Parking
    {
        private Dictionary<string, Car> cars;
        private int capacity;
        public Parking(int capacity)
        {
            this.capacity = capacity;
            cars = new Dictionary<string, Car>();
        }
        public int Count => cars.Count;
        public string AddCar(Car car)
        {
            if (cars.ContainsKey(car.RegistrationNumber))
            {
                return "Car with that registration number, already exists!";
            }
            if (cars.Count == capacity)
            {
                return "Parking is full!";
            }
            cars.Add(car.RegistrationNumber, car);
            return $"Successfully added new car {car.Make} {car.RegistrationNumber}";
        }
        public string RemoveCar(string registrationNum)
        {
            if (!cars.ContainsKey(registrationNum))
            {
                return "Car with that registration number, doesn't exist!";
            }
            cars.Remove(registrationNum);
            return $"Successfully removed {registrationNum}";
        }
        public Car GetCar(string registrationNum) => cars.FirstOrDefault(x => x.Key == registrationNum).Value;
        public void RemoveSetOfRegistrationNumber(List<string> registrationNumbers)
        {
            foreach (var item in registrationNumbers)
            {
                cars.Remove(item);
            }
        }
    }
}
