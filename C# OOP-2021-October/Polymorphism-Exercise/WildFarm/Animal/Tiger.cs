using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Food;

namespace WildFarm.Animal
{
    public class Tiger : Feline
    {
        public Tiger(string name, double weight, string livingRegion, string breed) : base(name, weight, livingRegion, breed)
        {
        }

        public override void Eat(IFood food)
        {
            if (!(food is Meat))
            {
                throw new InvalidOperationException($"{this.GetType().Name} does not eat {food.GetType().Name}!");
            }

            FoodEaten += food.Quantity;
            Weight += food.Quantity;
        }

        public override string ProduceSound()
         => "ROAR!!!";
    }
}
