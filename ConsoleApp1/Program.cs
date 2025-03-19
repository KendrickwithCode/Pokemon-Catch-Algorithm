using System;
using Microsoft.VisualBasic;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Player player = new Player("Jason");
            Pokemon Pokemon = new Pokemon();
            List<Pokemon> currentPokemon = Pokemon.GeneratePokemon(5);
            while(true)
            {
                foreach (var pokemon in currentPokemon)
                {
                    Console.WriteLine(pokemon.DisplayDetails());
                }
                Console.WriteLine("Catch a Pokemon.");
                var result = Convert.ToInt32(Console.ReadLine());
                foreach (var pal in currentPokemon)
                {
                    if (pal.ID == result)
                    {   
                        player.Catch(pal);
                    }
                }
            }
        }
    }
}