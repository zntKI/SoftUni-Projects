using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Food;

namespace WildFarm.Animal
{
    public class Mouse : Mammal
    {
        public Mouse(string name, double weight, string livingRegion) : base(name, weight, livingRegion)
        {
        }

        public override void Eat(IFood food)
        {
            if (!(food is Vegetable || food is Fruit))
            {
                throw new InvalidOperationException($"{this.GetType().Name} does not eat {food.GetType().Name}!");
            }

            FoodEaten += food.Quantity;
            Weight += food.Quantity * 0.10;
        }

        public override string ProduceSound()
            => "Squeak";
    }
}
