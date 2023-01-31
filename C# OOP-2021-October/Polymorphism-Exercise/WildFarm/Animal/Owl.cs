using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Food;

namespace WildFarm.Animal
{
    public class Owl : Bird
    {
        public Owl(string name, double weight, double wingSize) : base(name, weight, wingSize)
        {
        }

        public override void Eat(IFood food)
        {
            if (!(food is Meat))
            {
                throw new InvalidOperationException($"{this.GetType().Name} does not eat {food.GetType().Name}!");
            }

            FoodEaten += food.Quantity;
            Weight += food.Quantity * 0.25;
        }

        public override string ProduceSound()
            => "Hoot Hoot";
    }
}
