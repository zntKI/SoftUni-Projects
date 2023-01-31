using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Food;

namespace WildFarm.Animal
{
    public abstract class Animal : IAnimal
    {
        protected Animal(string name, double weight)
        {
            Name = name;
            Weight = weight;
            FoodEaten = 0;
        }

        public string Name { get; set; }
        public double Weight { get; set; }
        public int FoodEaten { get; set; }

        public abstract void Eat(IFood food);

        public abstract string ProduceSound();
    }
}
