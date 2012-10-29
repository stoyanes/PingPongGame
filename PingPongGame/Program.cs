using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace PingPongGame
{

    class Player
    {
        public int CoordXOfPad { get; set; }
        public int LenghtOfPad { get; set; }

        public Player(int coorXPad, int lenOfPad)
        {
            CoordXOfPad = coorXPad;
            LenghtOfPad = lenOfPad;
        }

        public void Draw()
        {
            Console.SetCursorPosition(0, CoordXOfPad);
            for (int i = 0; i < LenghtOfPad; i++)
            {
                Console.WriteLine('|');
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

                Thread.Sleep(60);
            }
            
        }
    }
}
