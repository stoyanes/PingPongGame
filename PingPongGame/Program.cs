using System;
using System.Threading;

namespace PingPongGame
{
    public class Game
    {
        static void Main(string[] args)
        {
            Game.Start(5);
            Console.SetBufferSize(Console.WindowWidth, Console.WindowHeight);

            Player firstPlayer = new Player(10, 5);
            ComputerPlayer secondPlayer = new ComputerPlayer(10, 5);
            Ball ball = new Ball(Console.WindowWidth / 2, Console.WindowHeight / 2 , true, false, true);
           

            while (true)
            {
                firstPlayer.Draw();
                secondPlayer.Draw();
                if (!ball.BallIsInField)
                {
                    Game.Over();
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

        private static void Over()
        {
            Console.Clear();
            Console.SetCursorPosition((int)(Console.WindowWidth / 2.5) , Console.WindowHeight / 2);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("G A M E   O V E R!");
            Console.ReadKey();
        }

        private static void Start(int seconds)
        {
            Console.SetCursorPosition((int)(Console.WindowWidth / 2.5), Console.WindowHeight / 2);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("G E T  R E A D Y!");
            Console.ForegroundColor = ConsoleColor.White;
            Thread.Sleep(3000);

            while (seconds > 0)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.SetCursorPosition(Console.WindowWidth / 3, Console.WindowHeight / 2);
                Console.WriteLine("Game will start after {0} seconds.", seconds);
                Console.ForegroundColor = ConsoleColor.White;
                seconds--;
                Thread.Sleep(1000);
            }
        }
    }
}
