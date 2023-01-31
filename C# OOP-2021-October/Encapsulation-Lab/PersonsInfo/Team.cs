using System;
using System.Collections.Generic;
using System.Text;

namespace PersonsInfo
{
    public class Team
    {
        private string name;
        private List<Person> firstTeam;
        private List<Person> reverseTeam;
        public Team(string name)
        {
            this.name = name;
            firstTeam = new List<Person>();
            reverseTeam = new List<Person>();
        }

        public string Name { get => this.name; }
        public IReadOnlyCollection<Person> FirstTeam { get => this.firstTeam.AsReadOnly(); }
        public IReadOnlyCollection<Person> ReverseTeam { get => this.reverseTeam.AsReadOnly(); }

        public void AddPlayer(Person person)
        {
            if (person.Age < 40)
            {
                firstTeam.Add(person);
            }
            else
            {
                reverseTeam.Add(person);
            }
        }
    }
}
