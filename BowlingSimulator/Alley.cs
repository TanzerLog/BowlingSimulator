using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingSimulator
{
    public class Alley
    {

        //Constructor
        public Alley(string name)
        {
            Name= name;

        }

        //Properties
        public string Name { get; set; }
        public List<Lane> Lanes { get; set; } = new List<Lane>();
        public List<Member> Members { get; set; } = new List<Member>();

        //Methods
        public Lane AddLane(string name)
        {
            Lane lane = new Lane(name, this);
            Lanes.Add(lane);
            return lane;
        }

        public Member RegisterMember(string name)
        {
            Member member = new Member(name, this);
            this.Members.Add(member);
            return member;
        }
    }
}
