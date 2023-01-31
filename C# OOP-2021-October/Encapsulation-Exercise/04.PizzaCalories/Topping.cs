using System;
using System.Collections.Generic;
using System.Text;

namespace _04.PizzaCalories
{
    public class Topping
    {
        Dictionary<string, double> toppingTypes = new Dictionary<string, double>
        {
            { "meat", 1.2 },
            { "veggies", 0.8 },
            { "cheese", 1.1 },
            { "sauce", 0.9 }
        };

        private string toppingType;
        private double weight;

        public Topping(string type, double weight)
        {
            ToppingType = type;
            Weight = weight;
        }

        public string ToppingType
        {
            get 
            { 
                return toppingType; 
            }
            set 
            {
                if (!toppingTypes.ContainsKey(value.ToLower()))
                {
                    throw new ArgumentException($"Cannot place {value} on top of your pizza.");
                }
                toppingType = value; 
            }
        }

        public double Weight
        {
            get 
            { 
                return weight; 
            }
            set 
            {
                if (value < 1 || value > 50)
                {
                    throw new ArgumentException($"{ToppingType} weight should be in the range [1..50].");
                }
                weight = value; 
            }
        }

        public double Calories
            => 2 * Weight * toppingTypes[ToppingType.ToLower()];
    }
}
