using System;
using System.Threading;

namespace PingPongGame
{
    public class ComputerPlayer : Player
    {
        private Random randomGenerator = new Random();

        public ComputerPlayer()
            : base()
        {
        }
        public ComputerPlayer(int coordOfPad, int lenOfPad)
            : base(coordOfPad, lenOfPad)
        {
        }
        public override void Draw()
        {
            for (int i = 0; i < LenghtOfPad; i++)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.SetCursorPosition(Console.WindowWidth - 1, CoordOfPad + i);
                Console.Write('|');
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        public void Move(bool isBallUp)
        {
            int randomNumber = randomGenerator.Next(0, 101);

            if (randomNumber <= 80)
            {
                if (isBallUp)
                {
                    if (this.CoordOfPad > 0)
                    {
                        CoordOfPad--;
                        this.Draw();
                    }
                }
                else
                {
                    if (this.CoordOfPad + this.LenghtOfPad < Console.WindowHeight - 1)
                    {
                        CoordOfPad++;
                        this.Draw();
                    }
                }
            }
            else
            {
                if (randomNumber % 2 == 0)
                {
                    if (this.CoordOfPad - 1 > 0)
                    {
                        CoordOfPad--;
                        this.Draw();
                    }
                }

                else
                {
                    if (CoordOfPad + LenghtOfPad < Console.WindowHeight - 1)
                    {
                        CoordOfPad++;
                        this.Draw();
                    }
                }
            }

        }


        public override bool IsPadContainsBall(int ballCoordX, int ballCoordY)
        {
            for (int i = CoordOfPad; i < CoordOfPad + LenghtOfPad; i++)
            {
                if (i == ballCoordY && ballCoordX == Console.WindowWidth - 2)
                {
                    return true;
                }
            }
            return false;
        }

    }
}
