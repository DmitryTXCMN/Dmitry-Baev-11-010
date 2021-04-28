using System;

namespace Tetris
{
    class Program
    {
        static void Main(string[] args)
        {
            int i = 1;
            for (int s = 0; s < 72; s++)
            {
                for (int si = 0; si < 269; si++)
                    Console.Write('0');
                Console.Write('\n');
            }
            GameBoard board = new GameBoard();
            char z = 'a';
            while (true)
            {
                var time = DateTime.Now.Second;
                while (time - DateTime.Now.Second > -1) ;
                if (z == 'z') z = 'a';
                board.UpdateFrame(z++);
            }
        }
    }
}
