﻿using System;
using System.Collections.Generic;
using System.Text;

namespace _03.Raiding
{
    public class Warrior : BaseHero
    {
        public Warrior(string name)
        {
            Name = name;
        }

        public override int Power
            => 100;

        public override string CastAbility()
        {
            return $"{GetType().Name} - {Name} hit for {Power} damage";
        }
    }
}
