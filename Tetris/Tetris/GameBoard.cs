using System;
using System.Collections.Generic;
using System.Text;

namespace Tetris
{
    public class GameBoard
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
                    board[i,j] = new Block(ConsoleColor.Black);
        }

        public GameBoard(Block[,] input)
        {
            board = new Block[20, 10];
            for (int i = 0; i < 20; i++)
                for (int j = 0; j < 10; j++)
                    board[i, j] = new Block(input[i, j].Color);
        }

        public GameBoard Copy()
        {
            return new GameBoard(board);
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
        public void UpdateFrame(char ch,FallShape shape)
        {
            GameBoard showBoard = new GameBoard(board);
            try
            {
                showBoard.PlaceShape(shape, shape.x, shape.y);
            }
            catch
            { }
            int ypos = 3;
            for (int i = 0; i < 20; i++)
            {
                Console.SetCursorPosition(4, ypos + 3 * i);
                for (int j = 0; j < 10; j++)
                {
                    Console.ForegroundColor = showBoard.board[i, j].Color;

                    Random rng = new Random();
                    ch = (char)rng.Next((int)'a',(int)'z');

                    SetBlockOnScreen(ch);
                }
            }
        }

        public void DellShape(FallShape shape, int x0, int y0)
        {
            int n = shape.shapeblocks.GetLength(0);
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    if (i - 1 + x0 >= 0)
                        if (shape.shapeblocks[i, j]) board[i - 1 + x0, j - 1 + y0].Color = ConsoleColor.Black;
        }

        public void PlaceShape(FallShape shape, int x0, int y0)
        {
            int n = shape.shapeblocks.GetLength(0);
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    if (i - 1 + x0 >= 0)
                        if (shape.shapeblocks[i, j])
                            if (j - 1 + y0 >= 0)
                            {
                                if (j - 1 + y0 <= 9)
                                {
                                    if (i - 1 + x0 < 20)
                                        if (board[i - 1 + x0, j - 1 + y0].IsBlockEmpty())
                                            board[i - 1 + x0, j - 1 + y0].Color = shape.Color;
                                        else throw new Exception("Collision error");
                                    else throw new Exception("Collision error");
                                }
                                else throw new Exception("Right--");
                            }
                            else throw new Exception("Left++");
        }

        public void DellString(int index)
        {
            for (int i = index; i > 0; i--)
                for (int j = 0; j < 10; j++)
                    board[i, j] = board[i - 1, j];
            for (int j = 0; j < 10; j++)
                board[0, j] = new Block(ConsoleColor.Black);
        }

        public void CheckFullLines(ref int deleted)
        {
            for (int i=19;i>=0;i--)
            {
                bool isStringFull = true;
                for (int j = 0; j < 10; j++)
                    if (board[i, j].IsBlockEmpty()) isStringFull = false;
                if (isStringFull)
                {
                    DellString(i++);
                    deleted++;
                }
            }
        }
    }
}

/*   public void PlaceShape(FallShape shape, int x0, int y0, ref bool collision)
        {
            int n = shape.shapeblocks.GetLength(0);
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    if (i - 1 + x0 >= 0)
                        if (shape.shapeblocks[i, j])
                            if (j - 1 + y0 >= 0)
                            {
                                if (j - 1 + y0 <= 9)
                                {
                                    if (i - 1 + x0 >= 20)
                                        if (board[i - 1 + x0, j - 1 + y0].IsBlockEmpty())
                                            board[i - 1 + x0, j - 1 + y0].Color = shape.Color;
                                        else
                                        {
                                            collision = true;
                                            throw new Exception("Collision error");
                                        }
                                    else
                                    {
                                        collision = true;
                                        throw new Exception("Collision error");
                                    }
                                }
                                else throw new Exception("Right--");
                            }
                            else throw new Exception("Left++");
        }*/
