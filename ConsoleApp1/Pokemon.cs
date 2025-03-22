using System;

namespace ConsoleApp1
{
    public class Pokemon : Status
    {
        public Pokemon()
        {

        }
        public Pokemon(int _id, string _name, int _hp, Status _status)
        {
            ID = _id;
            PokemonName = _name;
            Hitpoints = _hp;
            Status = _status;
        }

        public int ID { get; set; }
        public string PokemonName { get; set; } = "";
        public int Hitpoints { get; set; } = 0;
        public Status Status { get; set; }
        public int CaptureRate { get; set; }

        public string DisplayDetails()
        {
            return $"{ID}. Name: {PokemonName}, HP: {Hitpoints}, Status: {Status.Name}";
        }

        public List<Pokemon> GeneratePokemon(int count)
        {
            var palList = new List<Pokemon>();
            for (int i = 0; i < count; i++)
            {
                Random rand = new Random(Seed);
                string name = Enum.GetName(typeof(PokemonList), rand.Next(1, 152)) ?? "Missingno";
                int hp = rand.Next(0, 200); //Maximum hitpoints is 714, lowering due to difficulty catching.
                Pokemon pal = new Pokemon(i + 1, name, hp, new Status());
                pal.CaptureRate = rand.Next(0, 256);
                palList.Add(pal);
            }
            return palList;
        }

        public Pokemon Generate(int replacementID)
        {
            Random rand = new Random(Seed);
            string name = Enum.GetName(typeof(PokemonList), rand.Next(1, 152)) ?? "Missingno";
            int hp = rand.Next(0, 200); //Maximum hitpoints is 714, lowering due to difficulty catching.
            Pokemon pal = new Pokemon(replacementID, name, hp, new Status());
            return pal;
        }
    }
}