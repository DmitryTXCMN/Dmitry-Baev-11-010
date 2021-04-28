using System;
using System.Collections.Generic;
using System.Text;

namespace Tetris
{
    class GameBoard
    {
        public Block[,] board;

        public void SetBlockOnScreen(char ch)
        {
            Console.Write("┌────┐");
            Console.SetCursorPosition(Console.CursorLeft - 6, Console.CursorTop + 1);
            Console.Write("|*" + ch + ch + "*|");
            Console.SetCursorPosition(Console.CursorLeft - 6, Console.CursorTop + 1);
            Console.Write("└────┘");
            Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop-2);
        }

        public GameBoard()
        {
            board = new Block[20,10];
            for (int i = 0; i < 20; i++)
                for (int j = 0; j < 10; j++)
                    board[i,j] = new Block(ConsoleColor.Red);
        }

        public void UpdateFrame()
        {
            int ypos = 3;
            for (int i = 0; i < 20; i++)
            {
                Console.SetCursorPosition(3, ypos + 3*i);
                for (int j = 0; j < 30; j=j+3)
                {
                    Console.ForegroundColor = board[i, j].Color;
                    Console.Write("$");
                }
            }
        }
        public void UpdateFrame(char ch)
        {
            int ypos = 3;
            for (int i = 0; i < 20; i++)
            {
                Console.SetCursorPosition(3, ypos + 3 * i);
                for (int j = 0; j < 10; j++)
                {
                    Console.ForegroundColor = board[i, j].Color;
                    SetBlockOnScreen(ch);
                }
            }
        }
    }
}
