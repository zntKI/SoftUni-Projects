using System;
using System.Collections.Generic;
using System.Linq;

namespace _09.PokemonDon_tGo
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> pokemons = Console.ReadLine().Split().Select(int.Parse).ToList();
            int sum = 0;
            while (pokemons.Count > 0)
            {
                int index = int.Parse(Console.ReadLine());
                int pokemonIndex = 0;
                if (index < 0)
                {
                    pokemonIndex = pokemons[0];
                    pokemons.RemoveAt(0);
                    pokemons.Insert(0, pokemons[pokemons.Count - 1]);
                }
                else if (index > pokemons.Count - 1)
                {
                    pokemonIndex = pokemons[pokemons.Count - 1];
                    pokemons.RemoveAt(pokemons.Count - 1);
                    pokemons.Insert(pokemons.Count, pokemons[0]);
                }
                else
                {
                    pokemonIndex = pokemons[index];
                }
                for (int i = 0; i < pokemons.Count; i++)
                {
                    if (pokemons[i] <= pokemonIndex)
                    {
                        pokemons[i] += pokemonIndex;
                    }
                    else
                    {
                        pokemons[i] -= pokemonIndex;
                    }
                }
                sum += pokemonIndex;
                if (index >= 0 && index <= pokemons.Count - 1)
                {
                    pokemons.RemoveAt(index);
                }
            }
            Console.WriteLine(sum);
        }
    }
}
