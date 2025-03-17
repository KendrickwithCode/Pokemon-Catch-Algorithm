using System;

namespace ConsoleApp1
{
    public class Pals
    {
        public Pals()
        {

        }
        public Pals(string _name, int _hp, int _status)
        {
            Name = _name;
            Hitpoints = _hp;
            Status = _status;
        }

        public string Name { get; set; } = "";
        int Hitpoints { get; set; } = 0;
        int Status { get; set; } = 0;
        public int Seed
        {
            get
            {
                return (int)DateTime.Now.Ticks;
            }
        }

        public string DisplayDetails()
        {
            return $"Name: {Name}, HP: {Hitpoints}, Status: {Status}";
        }

        public List<Pals> GeneratePals(int count)
        {
            var palList = new List<Pals>();
            for (int i = 0; i < count; i++)
            {
                Random rand = new Random(Seed);

                //Name generator
                int namelength = rand.Next(0, 26);
                char letter;
                int value;
                string name = "";
                for (int j = 0; j < namelength; j++)
                {
                    value = rand.Next(0, 26);
                    letter = Convert.ToChar(value + 65);
                    name = name + letter;
                }

                int hp = rand.Next(0, 715); //Maximum hitpoints is 714.
                var statusNumbers = new[] { 25, 12 }; //25 for Frozen/Asleep, 12 for Burned/Paralyzed.
                int status = statusNumbers[rand.Next(statusNumbers.Length)];
                Pals pal = new Pals(name, hp, status);
                Console.WriteLine(pal.DisplayDetails());
                palList.Append(pal);
            }
            return palList;
        }
    }
}