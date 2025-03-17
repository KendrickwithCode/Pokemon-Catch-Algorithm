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
            while(true)
            {
                pals.GeneratePals(5);
                Console.WriteLine("Catch a Pokemon. Press 1");
                var result = Console.ReadLine();
                if (result == "1")
                {
                    player.Catch();
                }
            }
        }
    }
}