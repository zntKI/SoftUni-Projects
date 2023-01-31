using System;
using System.Collections.Generic;

namespace FootballTeamGenerator
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Dictionary<string, Team> teams = new Dictionary<string, Team>();
            string line = Console.ReadLine();
            while (line != "END")
            {
                string[] command = line.Split(';');
                try
                {
                    if (command[0] == "Team" && !teams.ContainsKey(command[1]))
                    {
                        Team team = new Team(command[1]);
                        teams.Add(command[1], team);
                    }
                    else if (command[0] == "Add")
                    {
                        if (!teams.ContainsKey(command[1]))
                        {
                            Console.WriteLine($"Team {command[1]} does not exist.");
                            line = Console.ReadLine();
                            continue;
                        }
                        string playerName = command[2];
                        int endurance = int.Parse(command[3]);
                        int sprint = int.Parse(command[4]);
                        int dribble = int.Parse(command[5]);
                        int passing = int.Parse(command[6]);
                        int shooting = int.Parse(command[7]);
                        Player player = new Player(playerName, endurance, sprint, dribble, passing, shooting);
                        teams[command[1]].AddPlayer(player);
                    }
                    else if (command[0] == "Remove" && teams.ContainsKey(command[1]))
                    {
                        string playerName = command[2];
                        teams[command[1]].RemovePlayer(playerName);
                    }
                    else if (command[0] == "Rating")
                    {
                        if (!teams.ContainsKey(command[1]))
                        {
                            Console.WriteLine($"Team {command[1]} does not exist.");
                            line = Console.ReadLine();
                            continue;
                        }
                        Console.WriteLine($"{command[1]} - {teams[command[1]].Rating}");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                line = Console.ReadLine();
            }
        }
    }
}
