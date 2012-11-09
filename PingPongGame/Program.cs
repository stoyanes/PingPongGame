﻿using System;
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
                Console.WriteLine('|');
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

    public class ComputerPlayer : Player
    {
        private Random randomGenerator = new Random();
        
        public ComputerPlayer()
            : base()
        {
        }
        public ComputerPlayer(int coordOfPad, int lenOfPad)
            :base(coordOfPad, lenOfPad)
        {
        }
        public override void Draw()
        {
            for (int i = 0; i < LenghtOfPad; i++)
            {
                Console.SetCursorPosition(Console.WindowWidth - 1, CoordOfPad + i);
                Console.Write('|');
            }
        }

        public void Move(bool isBallUp)
        {
            int randomNumber = randomGenerator.Next(0, 101);

            if (randomNumber <= 70)
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
            Console.SetCursorPosition(CoordX, CoordY);
            Console.Write('@');
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

    public class Game
    {
        static void Main(string[] args)
        {
            Console.SetBufferSize(Console.WindowWidth, Console.WindowHeight);

            Player firstPlayer = new Player(10, 5);
            ComputerPlayer secondPlayer = new ComputerPlayer(10, 5);
            Ball ball = new Ball(Console.WindowWidth / 2, Console.WindowHeight / 2 , false, true, true);
           

            while (true)
            {
                firstPlayer.Draw();
                secondPlayer.Draw();
                ball.Draw();
                if (!ball.BallIsInField)
                {
                    Console.SetCursorPosition(Console.WindowWidth / 2, Console.WindowHeight / 2);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Game Over!");
                    Console.ReadKey();
                    return;
                }
                // TODO - implement result
                if (Console.KeyAvailable)
                {
                    firstPlayer.Move(Console.ReadKey().Key);
                }

                if (firstPlayer.IsPadContainsBall(ball.CoordX, ball.CoordY))
                {
                    if (ball.IsUp && !ball.IsRight)
                    {
                        ball.IsRight = true;
                    }
                    if (!ball.IsUp && !ball.IsRight)
                    {
                        ball.IsRight = true;
                    }
                }

                if (secondPlayer.IsPadContainsBall(ball.CoordX, ball.CoordY))
                {
                    if (ball.IsUp && ball.IsRight)
                    {
                        ball.IsRight = false;
                    }
                    if (!ball.IsUp && ball.IsRight)
                    {
                        ball.IsRight = false;
                    }
                }

                secondPlayer.Move(ball.IsUp);  
                ball.Move();
                Thread.Sleep(100);
                Console.Clear();
            }
            
        }
    }
}
