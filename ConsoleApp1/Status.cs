using System;
using System.Diagnostics.Contracts;
using System.Globalization;
using System.Security.Cryptography.X509Certificates;

namespace ConsoleApp1
{
    public class Status : IStatus
    {
        string[] largeStatuses = {"Frozen", "Asleep"};
        string[] smallStatuses = {"Burned", "Paralyzed"};
        int[] statusNumbers = { 0, 25, 12 }; //25 for Frozen/Asleep, 12 for Burned/Paralyzed.

        public Status()
        {
            Random rand = new Random(Seed);
            Number = statusNumbers[rand.Next(statusNumbers.Length)];
            switch (Number)
            {
                case 25: Name = largeStatuses[rand.Next(largeStatuses.Length)]; break;
                case 12: Name = smallStatuses[rand.Next(smallStatuses.Length)]; break;
                default: Name = "None"; break;
            }
        }

        public int Number {get; set;}
        public string Name {get; set;}
        public int Seed
        {
            get
            {
                return (int)DateTime.Now.Ticks;
            }
        }
    }
}