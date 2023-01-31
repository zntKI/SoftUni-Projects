using System;
using System.Collections.Generic;
using System.Text;

namespace _04.BorderControl
{
    public class Pet : IBirthdayable
    {
        public Pet(string birthday)
        {
            Birthday = birthday;
        }

        public string Name { get; set; }
        public string Birthday { get; set; }
    }
}
