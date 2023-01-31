using System;
using System.Collections.Generic;
using System.Text;

namespace NeedForSpeed
{
    public class Vehicle
    {
        private const double DefaultFuelConsuption = 1.25;
        public Vehicle(int horsePower, double fuel)
        {
            HorsePower = horsePower;
            Fuel = fuel;
            FuelConsumption = DefaultFuelConsuption;
        }

        public double Fuel { get; set; }
        public int HorsePower { get; set; }
        public virtual double FuelConsumption { get; set; }
        public virtual void Drive(double kilo)
        {
            Fuel -= kilo * FuelConsumption;
        }
    }
}
