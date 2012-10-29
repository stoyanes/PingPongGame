using System;
using System.Threading;

namespace PingPongGame
{

    class Player
    {
        public int CoordOfPad { get; set; }
        public int LenghtOfPad { get; set; }

        public Player(int coorPad, int lenOfPad)
        {
            CoordOfPad = coorPad;
            LenghtOfPad = lenOfPad;
        }

        public void Draw()
        {
            Console.SetCursorPosition(0, CoordOfPad);
            for (int i = 0; i < LenghtOfPad; i++)
            {
                Console.WriteLine('|');
            }
        }

        public void Move(ConsoleKey pressedKey)
        {
            // moving the pad up
            if (pressedKey == ConsoleKey.UpArrow && CoordOfPad - 1 >= Console.WindowTop)
            {
                CoordOfPad -= 1;
                Console.Clear();
                this.Draw();
            }

            // moving the pad down
            if (pressedKey == ConsoleKey.DownArrow && CoordOfPad + this.LenghtOfPad < Console.WindowHeight - 1)
            {
                CoordOfPad += 1;
                Console.Clear();
                this.Draw();
            }
        }

    }

    class Game
    {
        static void Main(string[] args)
        {
            Console.SetBufferSize(Console.WindowWidth, Console.WindowHeight);

            Player firstPlayer = new Player(10, 5);


            while (true)
            {
                firstPlayer.Draw();
                
                if (Console.KeyAvailable)
                {
                    firstPlayer.Move(Console.ReadKey().Key);
                }
                
                Thread.Sleep(60);
            }
            
        }
    }
}
