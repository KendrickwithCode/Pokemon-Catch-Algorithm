using System;
using System.Security.Cryptography;
using Microsoft.VisualBasic;

namespace ConsoleApp1
{
    public class Player
    {
        public string Name { get; set; }

        public Pokeball Ball {get; set;} = new Pokeball();

        public int Seed
        {
            get
            {
                return (int)DateTime.Now.Ticks;
            }
        }
        public Player(string _name)
        {
            Name = _name;
        }

        public bool Catch(Pokemon pal, Pokeball ball)
        {
            Console.Clear();
            Ball = ball;
            Random rand = new Random(Seed);
            Console.WriteLine("Pokeball thrown");
            System.Threading.Thread.Sleep(1000);
            int R1 = rand.Next(256);
            int Rstar = R1 - pal.Status.Number;
            if (Rstar < 0)
            {
                Wobbles(3);
                Console.WriteLine("Caught!");
                return true;
            }
            else
            {
                int F = pal.Hitpoints * 255; //HP Factor
                if (Ball.Name.Equals("Greatball"))
                {
                    F /= 8;
                }
                else
                {
                    F /= 12;
                }
                int hpbyfour = pal.Hitpoints / 4;
                if (hpbyfour == 0)
                {
                    hpbyfour = 1;
                }
                F /= hpbyfour;
                if (F > 255)
                {
                    F = 255;
                }
                int baseCaptureRate = pal.CaptureRate;
                if (baseCaptureRate < Rstar)
                {
                    Console.WriteLine("Broke free.");
                    return false;
                }
                int R2 = rand.Next(256);
                if (R2 <= F)
                {
                    Wobbles(3);
                    Console.WriteLine("Caught!");
                    return true;
                }
                //If we get here, the capture fails. Determine the appropriate amount of Wobbles.
                int W = baseCaptureRate * 100;
                switch (Ball.Name)
                {
                    case "Greatball": W /= 200; break;
                    case "Ultraball": W /= 150; break;
                    default: W /= 255; break;
                }
                W *= F;
                W /= 255;
                if (pal.Status.Number == 25)
                {
                    W += 10;
                }
                else if (pal.Status.Number == 12)
                {
                    W += 5;
                }

                if (W < 10)
                {
                    Console.WriteLine("The Ball missed!");
                    return false;
                }
                Console.WriteLine("1");
                System.Threading.Thread.Sleep(1000);
                if (W >= 10 && W <= 29)
                {
                    Console.WriteLine("Broke Free!");
                    return false;
                }
                Console.WriteLine("2");
                System.Threading.Thread.Sleep(1000);
                if (W >= 30 && W <= 69)
                {
                    Console.WriteLine("Broke Free!!");
                    return false;
                }
                Console.WriteLine("3");
                System.Threading.Thread.Sleep(1000);
                if (W >= 70)
                {
                    Console.WriteLine("Broke Free!!!");
                    return false;
                }
            }
            return false;
        }

        public void Wobbles(int count)
        {
            for(int i = 1; i < count; i++)
            {
                    Console.WriteLine(i);   
                    System.Threading.Thread.Sleep(1000);
            }
        }
    }
}