using System;
using Microsoft.VisualBasic;

namespace ConsoleApp1
{
    public class Player
    {
        public string Name { get; set; }

        public int Seed
        {
            get
            {
                return (int)DateTime.Now.Ticks;
            }
        }

        public Random RandomNumber {get; set;}

        public Player(string _name)
        {
            Name = _name;
        }

        public void Catch()
        {
            Random rand = new Random(Seed);
            Console.WriteLine("Pokeball thrown");
            System.Threading.Thread.Sleep(1000);
            //If Pokeball, 0 to 255. Great = 200, Ultra = 150 inclusive.
            if (rand.Next(0, 2) > 0) //rand.Next maxValue is exclusive, so 0,1 won't work.
            {
                Console.WriteLine("Caught!");
            }
            else
            {
                Console.WriteLine("Broke Free.");
            }
        }
    }
}