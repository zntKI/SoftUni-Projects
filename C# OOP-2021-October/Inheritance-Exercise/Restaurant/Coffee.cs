using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant
{
    public class Coffee : HotBeverage
    {
        private const double DCoffeeMilliliters = 50;
        private const decimal DCoffeePrice = 3.50m;
        public Coffee(string name, double caffeine) : base(name, DCoffeePrice, DCoffeeMilliliters)
        {
            Caffeine = caffeine;
        }
        public double Caffeine { get; set; }
    }
}
