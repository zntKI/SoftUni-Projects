﻿using System;
using System.Collections.Generic;
using System.Text;

namespace _04.BorderControl
{
    public class Robot : IId
    {
        public Robot(string id)
        {
            Id = id;
        }

        public string Model { get; set; }
        public string Id { get; set; }
    }
}
