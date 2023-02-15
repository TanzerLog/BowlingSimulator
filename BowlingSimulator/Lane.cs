using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingSimulator
{
    public class Lane
    {

        //Constructor
        public Lane(string name, Alley alley)
        {
            Name = name;
            Alley = alley;
        }


        //Properties
        public string Name { get; set; }
        public Alley Alley { get; set; }
        public List<Game> Games { get; set; } = new List<Game>();

        //Methods
        public Game BookGame(Member member1, Member member2)
        {
            Game game = new Game(this, member1, member2);
            this.Games.Add(game);
            return game;
        }
    }
}
