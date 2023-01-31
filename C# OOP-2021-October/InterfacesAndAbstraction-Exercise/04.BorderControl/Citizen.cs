using System;
using System.Collections.Generic;
using System.Text;

namespace _04.BorderControl
{
    public class Citizen : IId, IBirthdayable
    {
        public Citizen(string birthday)
        {
            Birthday = birthday;
        }

        public string Name { get; set; }
        public int Age { get; set; }
        public string Id { get; set; }
        public string Birthday { get; set; }
    }
}
