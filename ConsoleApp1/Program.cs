using System;
using System.IO.IsolatedStorage;
using Microsoft.VisualBasic;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PokeStorage storage = new PokeStorage("pokestorage.db");
            storage.CreateStorage();
            Player player = new Player("Jason");
            Pokemon Pokemon = new Pokemon();
            Pokeball Ball = new Pokeball();
            List<Pokemon> currentPokemon = Pokemon.GeneratePokemon(5);
            List<Pokeball> currentBalls = Ball.GenerateAll();

            while(true)
            {
                //Pokemon Selection
                foreach (var pokemon in currentPokemon)
                {
                    Console.WriteLine(pokemon.DisplayDetails());
                }
                Console.WriteLine("Catch a Pokemon.");
                var PokemonResult = Convert.ToInt32(Console.ReadLine());

                //Ball Selection
                foreach (var ball in currentBalls)
                {
                    Console.WriteLine(ball.DisplayDetails());
                }
                Console.WriteLine("Choose a ball.");
                var BallResult = Convert.ToInt32(Console.ReadLine());
                Ball.Number = BallResult;

                //Catching
                var listCopy = currentPokemon.ToList();
                foreach (var pal in listCopy)
                {
                    if (pal.ID == PokemonResult)
                    {   
                        var caught = player.Catch(pal, Ball);
                        if (caught)
                        {
                            //Save in DB and Remove from the list.
                            storage.SavePokemon(pal);
                            currentPokemon.Remove(pal);

                            //Generate a replacement Pokemon.
                            currentPokemon.Add(Pokemon.Generate(pal.ID));
                        }
                    }
                }
            }
        }
    }
}