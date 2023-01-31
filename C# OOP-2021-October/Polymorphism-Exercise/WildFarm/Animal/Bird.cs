﻿using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm.Animal
{
    public abstract class Bird : Animal
    {
        protected Bird(string name, double weight, double wingSize) : base(name, weight)
        {
            WingSize = wingSize;
        }
        
        public double WingSize { get; set; }
    }
}
