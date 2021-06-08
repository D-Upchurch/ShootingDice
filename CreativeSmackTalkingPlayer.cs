using System;
using System.Collections.Generic;
namespace ShootingDice
{
    // A SmackTalkingPlayer who randomly selects a taunt from a list to say to the other player
    public class CreativeSmackTalkingPlayer : Player
    {
        private List<string> Taunts = new List<string>();

        public CreativeSmackTalkingPlayer(string Name)
        {
            this.Name = Name;
            Taunts.Add("You can do better than that!");
            Taunts.Add("Weak! You'll never defeat me!");
            Taunts.Add("Is that all you've got?!");
            Taunts.Add("I just wanna say.....I'm gonna win.");
            Taunts.Add("This will not be good game, prepare to die!");


        }

        public override void Play(Player other)
        {

            Random rnd = new Random();

            List<int> indexes = new List<int>();

            while (indexes.Count < 1)
            {
                int candidate = rnd.Next(0, Taunts.Count);
                if (!indexes.Contains(candidate))
                {
                    indexes.Add(candidate);
                }
            }

            for (int i = 0; i < indexes.Count; i++)
            {
                int index = indexes[i];
                Console.WriteLine(Taunts[index]);
            }

            // Call roll for "this" object and for the "other" object
            int myRoll = Roll();
            int otherRoll = other.Roll();

            Console.WriteLine($"{Name} rolls a {myRoll}");
            Console.WriteLine($"{other.Name} rolls a {otherRoll}");
            if (myRoll > otherRoll)
            {
                Console.WriteLine($"{Name} Wins!");
            }
            else if (myRoll < otherRoll)
            {
                Console.WriteLine($"{other.Name} Wins!");
            }
            else
            {
                // if the rolls are equal it's a tie
                Console.WriteLine("It's a tie");
            }
        }

    }
}