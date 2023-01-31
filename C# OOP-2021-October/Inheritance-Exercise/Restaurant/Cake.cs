using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant
{
    public class Cake : Dessert
    {
        private const double DGrams = 250;
        private const double DCalories = 1000;
        private const decimal CakePrice = 5;
        public Cake(string name) : base(name, CakePrice, DGrams, DCalories)
        {
        }
    }
}
