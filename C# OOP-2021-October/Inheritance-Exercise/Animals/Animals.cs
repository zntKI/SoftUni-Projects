using System;
using System.Collections.Generic;
using System.Text;

namespace Animals
{
    public class Animal
    {
        private string name;
        private int age;
        private string gender;
        public Animal(string name, int age, string gender)
        {
            Name = name;
            Age = age;
            Gender = gender;
        }

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                if (value == "")
                {
                    throw new ArgumentException("Invalit Input!");
                }

                name = value;
            }
        }
        public int Age //{ get; set; }
        {
            get
            {
                return age;
            }
            set
            {
                if (value <= 0 || value.ToString() == "")
                {
                    throw new Exception("Invalid input!");
                }
                else
                {
                    age = value;
                }
            }
        }
        public string Gender //{ get; set; }
        {
            get
            {
                return gender;
            }
            set
            {
                if ((value != "Male" && value != "Female") || value == "")
                {
                    throw new Exception("Invalid input!");
                }
                else
                {
                    gender = value;
                }
            }
        }

        public virtual string ProduceSound()
        {
            return "";
        }
    }
}
