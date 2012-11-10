using System;
using System.Threading;

namespace PingPongGame
{
    public class Player
    {
        public int CoordOfPad { get; set; }
        public int LenghtOfPad { get; set; }

        public Player()
        {
            CoordOfPad = 0;
            LenghtOfPad = 0;
        }

        public Player(int coorPad, int lenOfPad)
        {
            CoordOfPad = coorPad;
            LenghtOfPad = lenOfPad;
        }

        public virtual void Draw()
        {
            Console.SetCursorPosition(0, CoordOfPad);
            for (int i = 0; i < LenghtOfPad; i++)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine('|');
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        public virtual void Move(ConsoleKey pressedKey)
        {
            // moving the pad up
            if (pressedKey == ConsoleKey.UpArrow && CoordOfPad - 1 >= Console.WindowTop)
            {
                CoordOfPad -= 1;
                this.Draw();
            }

            // moving the pad down
            if (pressedKey == ConsoleKey.DownArrow && CoordOfPad + this.LenghtOfPad < Console.WindowHeight - 1)
            {
                CoordOfPad += 1;
                this.Draw();
            }
        }

        public virtual bool IsPadContainsBall(int ballCoordX, int ballCoordY)
        {
            for (int i = CoordOfPad; i < CoordOfPad + LenghtOfPad; i++)
            {
                if (i == ballCoordY && ballCoordX == 1)
                {
                    return true;
                }
            }
            return false;
        }

    }
}
