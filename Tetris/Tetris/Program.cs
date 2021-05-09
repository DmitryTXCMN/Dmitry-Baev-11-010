using System;

namespace Tetris
{
    class Program : GameProgress
    {
        public static void FullDesk()
        {
            for (int s = 0; s < 72; s++)
            {
                for (int si = 0; si < 269; si++)
                    Console.Write('0');
                Console.Write('\n');
            }
        }
        static void Main(string[] args)
        {
            FullDesk();
            GameProgress game = new GameProgress();
            game.Game();
            
        }
    }
}

/*GameBoard board = new GameBoard();
            char z = 'a';
            
            while (true)
            {
                
                if (z == 'z') z = 'a';
                FallShape currentShape = new FallShape();
                board.PlaceShape(currentShape, 4, 4);
                board.UpdateFrame(z++);
                board.DellShape(currentShape, 4, 4);
            }*/