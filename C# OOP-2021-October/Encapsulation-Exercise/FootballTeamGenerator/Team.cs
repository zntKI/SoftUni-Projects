using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FootballTeamGenerator
{
    public class Team
    {
        private string name;
        private List<Player> team;

        public Team(string name)
        {
            Name = name;
            team = new List<Player>();
        }

        public string Name
        {
            get { return name; }
            set 
            {
                if (value == null || value == "" || value == " ")
                {
                    throw new ArgumentException("A name should not be empty.");
                }

                name = value; 
            }
        }

        public int Rating
            => team.Count == 0 ? 0 : (int)Math.Round(team.Average(x => x.SkillLevel));

        public void AddPlayer(Player player)
        {
            team.Add(player);
        }

        public void RemovePlayer(string playerName)
        {
            Player player = team.FirstOrDefault(x => x.Name == playerName);
            if (player == null)
            {
                throw new InvalidOperationException($"Player {playerName} is not in {Name} team.");
            }
            team.Remove(player);
        }
    }
}
