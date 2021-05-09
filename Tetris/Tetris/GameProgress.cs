using System;
using System.Collections.Generic;
using System.Threading;

namespace Tetris
{
    class GameProgress : Controls
    {
        int hard = 500;

        public GameProgress()
        {

        }

        public void FallSleep(GameBoard currentBoard, FallShape currentShape, ref bool collision ,int fallTimeInTicks, ref bool done)
        {
            Thread.Sleep(fallTimeInTicks);
            if (!collision) Fall(currentBoard, currentShape, ref collision);
            done = true;
        }

        public void Game()
        {
            GameBoard currentBoard = new GameBoard();
            GameBoard tempBoard = new GameBoard();
            FallShape currentShape = new FallShape();
            bool collision = true;
            while (true)
            {
                if (collision)
                {
                    currentShape = new FallShape();
                    collision = false;
                }
                tempBoard = currentBoard.Copy();
                try
                {
                    tempBoard.Copy().PlaceShape(currentShape, currentShape.x, currentShape.y);
                }
                catch
                {
                    break;
                }
                currentBoard.UpdateFrame('y', currentShape);
                while (!collision)
                {
                    bool done = false;
                    Thread falling = new Thread(() =>
                    {
                        FallSleep(currentBoard, currentShape, ref collision, hard, ref done);
                    });
                    falling.Start();
                    while (!done)
                    {
                        if (Console.KeyAvailable)
                        {
                            var pressedKey = Console.ReadKey();
                            switch (pressedKey.Key)
                            {
                                case ConsoleKey.LeftArrow:
                                    Move(currentBoard, currentShape, -1);
                                    break;
                                case ConsoleKey.RightArrow:
                                    Move(currentBoard, currentShape, 1);
                                    break;
                                case ConsoleKey.UpArrow:
                                    Rotate(currentBoard, currentShape);
                                    break;
                                case ConsoleKey.DownArrow:
                                    if (!collision) Fall(currentBoard, currentShape, ref collision);
                                    break;
                                default:
                                    break;
                            }
                        }
                        if (!collision) currentBoard.UpdateFrame('y', currentShape);
                    }
                }
                currentBoard.CheckFullLines();
            }
        }
    }
}


/*long currentTime = (long)DateTime.Now.Ticks;
                    while ((long)DateTime.Now.Ticks - currentTime < 40 && !collision)
                    {
 * 
 * 
                        */