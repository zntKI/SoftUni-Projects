using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    public class Family
    {
        private List<Person> people;
        public Family()
        {
            People = new List<Person>();
        }
        public List<Person> People
        {
            get
            {
                return people;
            }
            set
            {
                people = value;
            }
        }
        public void AddMember(Person person)
        {
            People.Add(person);
        }
        public List<Person> Sort()
        {
            List<Person> sorted = People.Where(x => x.Age > 30).OrderBy(x => x.Name).ToList();
            return sorted;
        }
    }
}
