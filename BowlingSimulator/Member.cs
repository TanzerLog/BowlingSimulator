using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingSimulator
{
    public class Member
    {
        //Constructor
        public Member(string name, Alley alley)
        {
            Name = name;
            Alley = alley;
        }

        //Properties
        public string Name { get; set; }
        public Alley Alley { get; set; }
    }
}
