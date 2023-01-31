using System;
using System.Collections.Generic;
using System.Text;

namespace _01.Vehicles
{
    public abstract class Vehicle : IVehicle
    {
        private double fuelQuantity;

        protected Vehicle(double fuelQuantity, double fuelConsumption, double tankCapacity)
        {
            TankCapacity = tankCapacity;
            FuelQuantity = fuelQuantity;
            FuelConsumption = fuelConsumption;
        }

        public double FuelQuantity 
        {
            get => fuelQuantity;
            set
            {
                if (value > TankCapacity)
                {
                    value = 0;
                }
                fuelQuantity = value;
            }
        }
        public virtual double FuelConsumption { get; set; }
        public double TankCapacity { get; set; }

        public bool IsEmpty { get; set; }

        public void Drive(double distance)
        {
            FuelQuantity -= FuelConsumption * distance;
        }

        public virtual void Refuel(double liters)
        {
            ValidateF(liters);
            ValidateQ(liters);
            FuelQuantity += liters;
        }

        protected void ValidateQ(double liters)
        {
            if (FuelQuantity + liters > TankCapacity)
            {
                throw new ArgumentException($"Cannot fit {liters} fuel in the tank");
            }
        }

        protected void ValidateF(double liters)
        {
            if (liters <= 0)
            {
                throw new ArgumentException("Fuel must be a positive number");
            }
        }
    }
}
