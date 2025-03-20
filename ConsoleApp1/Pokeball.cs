using System;

namespace ConsoleApp1
{
    public class Pokeball
    {
        private string name = "";
        private int number = 1;

        public Pokeball(string _name = "Pokeball", int _number = 1)
        {
            name = _name;
            number = _number;
        }
        public string Name
        {
            get { return name; }
            set
            {
                if (Name == value) return;
                switch (value)
                {
                    case "Pokeball": Number = 1; break;
                    case "Greatball": Number = 2; break;
                    case "Ultraball": Number = 3; break;
                }
            }
        }
        public int Number
        {
            get { return number; }
            set
            {
                if (Number == value) return;
                number = value;
                switch (value)
                {
                    case 1: Name = "Pokeball"; break;
                    case 2: Name = "Greatball"; break;
                    case 3: Name = "Ultraball"; break;
                    default: Name = "None"; break;
                }
            }
        }

        public List<Pokeball> GenerateAll()
        {
            List<Pokeball> balls = new List<Pokeball>();
            Pokeball pokeball = new Pokeball("Pokeball", 1);
            Pokeball greatball = new Pokeball("Greatball", 2);
            Pokeball ultraball = new Pokeball("Ultraball", 3);
            balls.Add(pokeball);
            balls.Add(greatball);
            balls.Add(ultraball);
            return balls;
        }

        public string DisplayDetails()
        {

            return $"{Number}. {Name}";
        }
    }
}