using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.PokemonTrainer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Dictionary<string, Trainer> trainers = new Dictionary<string, Trainer>();
            string line = Console.ReadLine();
            while (line != "Tournament")
            {
                string[] command = line.Split(' ');
                string trainerName = command[0];
                string pokemonName = command[1];
                string pokemonElement = command[2];
                int pokemonHealth = int.Parse(command[3]);
                if (!trainers.ContainsKey(trainerName))
                {
                    Trainer trainer = new Trainer(trainerName);
                    trainers.Add(trainerName, trainer);
                }
                Pokemon pokemon = new Pokemon(pokemonName, pokemonElement, pokemonHealth);
                trainers[trainerName].Pokemons.Add(pokemon);
                line = Console.ReadLine();
            }
            line = Console.ReadLine();
            while (line != "End")
            {
                foreach (var trainer in trainers)
                {
                    if (trainer.Value.Pokemons.Any(x => x.Element == line))
                    {
                        trainer.Value.Badges += 1;
                    }
                    else
                    {
                        foreach (var pokemon in trainer.Value.Pokemons)
                        {
                            pokemon.Health -= 10;
                        }
                        trainer.Value.Pokemons.RemoveAll(x => x.Health <= 0);
                    }
                }
                line = Console.ReadLine();
            }
            foreach (var trainer in trainers.OrderByDescending(x => x.Value.Badges))
            {
                Console.WriteLine($"{trainer.Key} {trainer.Value.Badges} {trainer.Value.Pokemons.Count}");
            }
        }
    }
}
