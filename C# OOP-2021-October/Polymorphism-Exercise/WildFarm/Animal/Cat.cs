using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Food;

namespace WildFarm.Animal
{
    public class Cat : Feline
    {
        public Cat(string name, double weight, string livingRegion, string breed) : base(name, weight, livingRegion, breed)
        {
        }

        public override void Eat(IFood food)
        {
            if (!(food is Vegetable || food is Meat))
            {
                throw new InvalidOperationException($"{this.GetType().Name} does not eat {food.GetType().Name}!");
            }

            FoodEaten += food.Quantity;
            Weight += food.Quantity * 0.30;
        }

        public override string ProduceSound()
            => "Meow";
    }
}
