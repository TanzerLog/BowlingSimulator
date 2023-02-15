using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingSimulator
{
    public class Competitor
    {
        //Constructor
        public Competitor(Member member, Game game)
        {
            Member = member;
            Game = game;
            Frames = new Frame[10];
            //Initialises each frame with correct number of attempts
            for (int i = 0; i < 10; i++)
            {
                Frames[i] = new Frame();
                if (i < 9)
                {
                    Frames[i].Attempts = new int[2];
                } else
                {
                    Frames[i].Attempts = new int[3];
                }
                
            }
        }

        //Properties
        public int Score { get; set; }
        public Member Member { get; set; }
        public Game Game { get; set; }
        public Frame[] Frames { get; set; }

        //Methods
        public int CalculateScore(int frame) 
        {
            //Adds scores from both attempts
            Score += Frames[frame].Attempts[0];
            Score += Frames[frame].Attempts[1];
            //Logic for adding score based on previous strike/spare
            if (frame > 0)
            {
                //Add score of first attempt again for a previous spare
                if (Frames[frame - 1].Result == Frame.StrikeOrSpare.Spare)
                {
                    Score += Frames[frame].Attempts[0];
                }
                //Add scores from both attempts for a previous strike
                else if (Frames[frame - 1].Result == Frame.StrikeOrSpare.Strike)
                {
                    Score += Frames[frame].Attempts[0];
                    Score += Frames[frame].Attempts[1];
                }
            } 
            //Special scoring logic for the final frame which can have 3 attempts if the result of the first two is a strike or a spare, and all three attempts can be strikes
            if (frame == 9)
            {
                if (Frames[frame].Attempts[0] == 10 || (Frames[frame].Attempts[0] + Frames[frame].Attempts[1]) == 10)
                {
                    Score += Frames[frame].Attempts[2];
                }
            }
            return Score;
        }
    }
}
