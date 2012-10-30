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
                Console.SetCursorPosition(Console.WindowWidth - 1, CoordOfPad - i);
                Console.Write('|');
            }
        }

        public void Move()
        {
            int randomNumber = randomGenerator.Next(0, 101);

            // TODO - finish implementation

        }

    }

    public class Ball
    {
        public int CoordX { get; set; }
        public int CoordY { get; set; }
        public bool IsUp { get; set; }
        public bool IsRight { get; set; }

        public Ball(int coordX, int coordY, bool isU, bool isR)
        {
            CoordX = coordX;
            CoordY = coordY;
            IsUp = isU;
            IsRight = isR;
        }

        public void Draw()
        {
            Console.SetCursorPosition(CoordX, CoordY);
            Console.Write('@');
        }

        public void Move()
        {
            if (this.IsUp && this.IsRight)
            {
                CoordX++;
                CoordY--;
                this.Draw();
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
            Ball ball = new Ball(Console.WindowWidth / 2, Console.WindowHeight / 2 , true, true); 
            
            while (true)
            {
                firstPlayer.Draw();
                secondPlayer.Draw();
                ball.Draw();
                ball.Move();
                if (Console.KeyAvailable)
                {
                    firstPlayer.Move(Console.ReadKey().Key);
                }
                
                
                Thread.Sleep(100);
                Console.Clear();
            }
            
        }
    }
}
