﻿using System;
using System.Collections.Generic;
using System.Text;

namespace _03.Raiding
{
    public abstract class BaseHero
    { 

        public string Name { get; set; }
        public virtual int Power { get; set; }

        public abstract string CastAbility();
    }
}
