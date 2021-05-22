using System;
using System.Collections.Generic;
using System.Text;

namespace Tetris
{
    class UserInterface : GameBoard
    {
        public UserInterface()
        { }

        public void SetBoard(int x, int y, int lenght)
        {
            Console.SetCursorPosition(x, y);
            Console.Write(' ');
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write('/');
            Console.BackgroundColor = ConsoleColor.White;
            Console.Write(' ');
            Console.SetCursorPosition(x + lenght + 3, y);
            Console.Write(' ');
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write('\\');
            Console.BackgroundColor = ConsoleColor.White;
            Console.Write(' ');
        }

        public void SetLowBoard(int x, int y, int lenght)
        {
            Console.SetCursorPosition(x, y);
            Console.Write(' ');
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write('/');
            Console.Write('▌');
            Console.BackgroundColor = ConsoleColor.White;
            Console.SetCursorPosition(x + lenght + 3, y);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write('▐');
            Console.Write('\\');
            Console.BackgroundColor = ConsoleColor.White;
            Console.Write(' ');
        }

        public void SetBoardInterface(int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.Write("                                                                  ");
            Console.SetCursorPosition(x, y + 1);
            Console.Write("                                                                  ");
            Console.ForegroundColor = ConsoleColor.White;
            for (int i = 0; i < 60; i++)
            {
                SetBoard(x, y + 2 + i, 60);
            }

            Console.SetCursorPosition(x, y + 62);
            Console.Write("                                                                  ");
            Console.SetCursorPosition(x, y + 63);
            Console.Write("                                                                  ");
        }

        public void SetNextShapeInterface(int x, int y)
        {
            Console.ForegroundColor = ConsoleColor.Black;
            Console.SetCursorPosition(x, y);
            Console.Write("             NEXT             ");
            Console.SetCursorPosition(x, y + 1);
            Console.Write("             SHAPE            ");
            Console.ForegroundColor = ConsoleColor.White;
            for (int i = 0; i < 6; i++)
            {
                SetBoard(x, y + 2 + i, 24);
            }
            Console.SetCursorPosition(x, y + 8);
            Console.Write("                              ");
            Console.SetCursorPosition(x, y + 9);
            Console.Write("                              ");
        }

        public void SetScoreInterface(int x, int y)
        {
            Console.ForegroundColor = ConsoleColor.Black;
            Console.SetCursorPosition(x, y);
            Console.Write("             YOUR             ");
            Console.SetCursorPosition(x, y + 1);
            Console.Write("             SCORE            ");
            Console.ForegroundColor = ConsoleColor.White;
            for (int i = 0; i < 6; i++)
            {
                SetLowBoard(x, y + 2 + i, 24);
            }
            Console.SetCursorPosition(x, y + 8);
            Console.Write("                              ");
            Console.SetCursorPosition(x, y + 9);
            Console.Write("                              ");
        }

        public void SetHighScoreInterface(int x, int y)
        {
            Console.ForegroundColor = ConsoleColor.Black;
            Console.SetCursorPosition(x, y);
            Console.Write("             HIGH             ");
            Console.SetCursorPosition(x, y + 1);
            Console.Write("             SCORE            ");
            Console.ForegroundColor = ConsoleColor.White;
            for (int i = 0; i < 6; i++)
            {
                SetLowBoard(x, y + 2 + i, 24);
            }
            Console.SetCursorPosition(x, y + 8);
            Console.Write("                              ");
            Console.SetCursorPosition(x, y + 9);
            Console.Write("                              ");
        }

        public void StartSetup()
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.BackgroundColor = ConsoleColor.White;
            SetBoardInterface(1, 1);
            SetNextShapeInterface(72, 1);
            SetScoreInterface(72, 13);
            SetHighScoreInterface(72, 25);
            Console.BackgroundColor = ConsoleColor.Black;
            NumDrawer drawer = new NumDrawer();
            drawer.SetNumber(75, 15, 0);
        }

        public void ClearNewshape()
        {
            for (int i = 0; i < 6; i++)
            {
                Console.SetCursorPosition(75, 3 + i);
                Console.Write("                        ");
            }
        }

        public void DrawNewShapeUI(FallShape shape)
        {
            ClearNewshape();
            for (int i = 0; i < 2; i++)
            {
                Console.SetCursorPosition(75, 3 + 3 * i);
                for (int j = 0; j < shape.shapeblocks.GetLength(1); j++)
                {
                    if (shape.shapeblocks[i, j])
                    {
                        Console.ForegroundColor = shape.Color;
                        SetBlockOnScreen('n');
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Black;
                        SetBlockOnScreen('b');
                    }
                }
            }
        }

        public void DrawScoreUI(int score)
        {
            NumDrawer scoreDrawer = new NumDrawer();
            scoreDrawer.SetNumber(75, 15, score);
        }

        public void DrawHighScoreUI(int score)
        {
            NumDrawer scoreDrawer = new NumDrawer();
            scoreDrawer.SetNumber(75, 27, score);
        }
    }
}
