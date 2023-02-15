using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingSimulator
{
    public class Frame
    {
        public enum StrikeOrSpare
        {
            None,
            Strike,
            Spare
        }

        //Constructor


        //Properties
        public int[] Attempts { get; set; }
        public StrikeOrSpare Result { get; set; }

        //Methods
        public void BowlFrame(int firstBall, int secondBall)
        {
            Attempts[0] = firstBall;
            Attempts[1] = secondBall;
            if (Attempts[0] == 10)
            {
                Result = StrikeOrSpare.Strike;
            } else if ((Attempts[0] + Attempts[1]) == 10)
            {
                Result = StrikeOrSpare.Spare;
            }
        }

        //Overload method for final frame
        public void BowlFrame(int firstBall, int secondBall, int thirdBall)
        {
            Attempts[0] = firstBall;
            Attempts[1] = secondBall;
            Attempts[2] = thirdBall;
        }
    }
}
