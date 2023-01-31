using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _04.PizzaCalories
{
    public class Pizza
    {
        private string name;
        private Dough dough;
        private List<Topping> toppings;

        public Pizza(string name, Dough dough)
        {
            Name = name;
            Dough = dough;
            toppings = new List<Topping>();
        }

        public string Name
        {
            get 
            { 
                return name; 
            }
            private set 
            {
                if (value == "" || value.Length > 15)
                {
                    throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");
                }
                name = value; 
            }
        }

        public Dough Dough
        {
            get { return dough; }
            private set { dough = value; }
        }

        public int CountOfToppings
        {
            get
            {
                return toppings.Count;
            }
        }

        public void AddTopping(Topping topping)
        {
            if (toppings.Count == 10)
            {
                throw new InvalidOperationException("Number of toppings should be in range [0..10].");
            }
            toppings.Add(topping);
        }

        public double CalculateTotalCalories()
        {
            return Dough.Calories + toppings.Sum(x => x.Calories);
        }
    }
}
