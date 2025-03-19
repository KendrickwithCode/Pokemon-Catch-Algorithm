using System;
using Microsoft.VisualBasic;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Player player = new Player("Jason");
            Pals pals = new Pals();
            List<Pals> currentPals = pals.GeneratePals(5);
            while(true)
            {
                foreach (var pokemon in currentPals)
                {
                    Console.WriteLine(pokemon.DisplayDetails());
                }
                Console.WriteLine("Catch a Pokemon.");
                var result = Convert.ToInt32(Console.ReadLine());
                foreach (var pal in currentPals)
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