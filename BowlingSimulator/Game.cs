using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingSimulator
{
    public class Game
    {
        //Constructor
        public Game(Lane lane, Member member1, Member member2)
        {
            Lane = lane;
            AddCompetitor(member1);
            AddCompetitor(member2);
        }

        //Properties
        public Lane Lane { get; set; }
        public List<Competitor> Competitors { get; set; } = new List<Competitor>();

        //Methods
        public Competitor AddCompetitor(Member member)
        {
            Competitor competitor = new Competitor(member, this);
            Competitors.Add(competitor);
            return competitor;
        }
    }
}
