using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Food;

namespace WildFarm.Animal
{
    public class Dog : Mammal
    {
        public Dog(string name, double weight, string livingRegion) : base(name, weight, livingRegion)
        {
        }

        public override void Eat(IFood food)
        {
            if (!(food is Meat))
            {
                throw new InvalidOperationException($"{this.GetType().Name} does not eat {food.GetType().Name}!");
            }

            FoodEaten += food.Quantity;
            Weight += food.Quantity * 0.40;
        }

        public override string ProduceSound()
            => "Woof!";
    }
}
