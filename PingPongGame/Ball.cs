using System;
using System.Threading;

namespace PingPongGame
{
    public class Ball
    {
        public int CoordX { get; set; }
        public int CoordY { get; set; }
        public bool IsUp { get; set; }
        public bool IsRight { get; set; }
        public bool BallIsInField { get; set; }

        public Ball(int coordX, int coordY, bool isU, bool isR, bool ballInField)
        {
            CoordX = coordX;
            CoordY = coordY;
            IsUp = isU;
            IsRight = isR;
            BallIsInField = ballInField;

        }

        public void Draw()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.SetCursorPosition(CoordX, CoordY);
            Console.Write('@');
            Console.ForegroundColor = ConsoleColor.White;
        }

        public void Move()
        {
            if (this.CoordX == Console.WindowWidth - 1)
            {
                this.BallIsInField = false;
                return;
            }
            if (this.IsUp && this.IsRight)
            {
                if (this.CoordX <= Console.WindowWidth && this.CoordY > 0)
                {
                    CoordX++;
                    CoordY--;
                    this.Draw();
                }

                if (this.CoordY == 0)
                {
                    this.IsUp = false;
                }
                if (this.CoordX == 0)
                {
                    IsRight = false;
                }
            }

            if (!IsUp && IsRight)
            {
                if (CoordX < Console.WindowWidth && CoordY < Console.WindowHeight - 1)
                {
                    CoordX++;
                    CoordY++;
                    this.Draw();
                }

                if (CoordY == Console.WindowHeight - 1)
                {
                    IsUp = true;
                }
            }

            if (IsUp && !IsRight)
            {
                if (CoordX > 0 && CoordY > 0)
                {
                    CoordX--;
                    CoordY--;
                    this.Draw();
                }

                if (CoordY == 0)
                {
                    IsUp = false;
                }
                if (CoordX == 0)
                {
                    BallIsInField = false;
                }

            }

            if (!IsUp && !IsRight)
            {
                if (CoordY < Console.WindowHeight - 1 && CoordX > 0)
                {
                    CoordX--;
                    CoordY++;
                    this.Draw();
                }

                if (CoordY == Console.WindowHeight - 1)
                {
                    IsUp = true;
                }
                if (CoordX == 0)
                {
                    BallIsInField = false;
                }
            }


        }

    }
}
