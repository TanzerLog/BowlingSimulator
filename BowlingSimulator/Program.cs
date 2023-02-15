using BowlingSimulator;

class Program
{
    static void Main(string[] args)
    {
        //Establish Random object for use in randomising the pins knocked down with each bowl
        Random random = new Random();

        //Establish necessary objects for bowling simulation to function
        Alley alley = new Alley("Captain Balls");
        alley.AddLane("Lane 1");
        alley.AddLane("Lane 2");
        Member member1 = alley.RegisterMember("Goblin Joe");
        Member member2 = alley.RegisterMember("Jerry the Gnome");
        Member member3 = alley.RegisterMember("Fred");
        //Next two lines create a game with three players
        Game game = alley.Lanes[0].BookGame(member1, member2);
        game.AddCompetitor(member3);

        //Start of CLI side of the program
        Console.WriteLine("Welcome to Captain Bowls!");

        //Runs through each competitor in turn, starting by printing their name
        //All padding used in following code is to ensure smooth formatting of the game results in the CLI
        foreach (Competitor competitor in game.Competitors)
        {
            Console.WriteLine();
            Console.Write("|");
            Console.Write(competitor.Member.Name.PadRight(16));
            Console.Write("|");

            //This for loop plays each frame and prints results iteratively
            for (int i = 0; i < 10; i++)
            {
                //initialise variables required for later logic
                int firstBall;
                int secondBall;
                int thirdBall = -1; //Starts as -1 to determine if attempt was ever made for final frame logic
                string str1;
                string str2;
                //Logic for first 9 frames
                if (i < 9)
                {
                    firstBall = random.Next(0, 11);
                    secondBall = random.Next(0, (11 - firstBall));
                    competitor.Frames[i].BowlFrame(firstBall, secondBall);
                    competitor.CalculateScore(i);
                    str1 = $"{i + 1}: {competitor.Frames[i].Attempts[0]}/{competitor.Frames[i].Attempts[1]}";
                    str2 = $" [{competitor.Score}]";
                    Console.Write($"{str1.PadRight(8)}{str2.PadLeft(6)}");
                    Console.Write("|");
                } else //Logic for special tenth frame
                {
                    //Determines the random range for each throw based on the results of the preceeding throws to allow for a strike, two strikes or a spare, all creating a third attempt
                    firstBall = random.Next(0, 11);
                    if (firstBall == 10)
                    {
                        secondBall = random.Next(0, 11);
                        if (secondBall == 10)
                        {
                            thirdBall = random.Next(0, 11);
                        }
                        else
                        {
                            thirdBall = random.Next(0, (11 - secondBall));
                        }
                    } else
                    {
                        secondBall = random.Next(0, (11-firstBall));
                        if ((firstBall + secondBall) == 10)
                        {
                            thirdBall = random.Next(0, 11);
                        }
                    }
                    competitor.Frames[i].BowlFrame(firstBall, secondBall, thirdBall);
                    competitor.CalculateScore(i);
                    if (thirdBall == -1)
                    {
                        str1 = $"{i + 1}: {competitor.Frames[i].Attempts[0]}/{competitor.Frames[i].Attempts[1]}";

                    } else
                    {
                        str1 = $"{i + 1}: {competitor.Frames[i].Attempts[0]}/{competitor.Frames[i].Attempts[1]}/{competitor.Frames[i].Attempts[2]}";
                    }
                    str2 = $" [{competitor.Score}]";
                    Console.Write($"{str1.PadRight(12)}{str2.PadLeft(6)}");
                    Console.Write("|");
                }
                
            }

            //Prints the final score for the competitor
            Console.Write($" Total: {competitor.Score}");
        }

        //Stops CLI closing at program end
        Console.ReadLine();
    }
}