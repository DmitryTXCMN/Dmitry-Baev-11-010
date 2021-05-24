using System;
using System.Collections.Generic;
using System.Text;

namespace Tetris
{
    public class FallShape
    {
        public enum Shape
        {
            IShape = 0,
            LShape = 1,
            TShape = 2,
            OShape = 3,
            ZShape = 4,
            SShape = 5,
            rShape = 6
        }

        public ConsoleColor Color { get; set; }
        public Shape ShapeType { get; set; }
        public int x { get; set; }
        public int y { get; set; }
        public bool[,] shapeblocks { get; set; }

        public FallShape()
        {
            Random rng = new Random();
            x = 0;
            y = 4;
            Color = (ConsoleColor)rng.Next(9, 15);
            ShapeType = (Shape)rng.Next(0, 7);
            switch (ShapeType)
            {
                case (Shape.IShape):
                    shapeblocks = new bool[4, 4];
                    shapeblocks[1, 0] = true;
                    shapeblocks[1, 1] = true;
                    shapeblocks[1, 2] = true;
                    shapeblocks[1, 3] = true;
                    break;
                case (Shape.LShape):
                    shapeblocks = new bool[3, 3];
                    shapeblocks[1, 1] = true;
                    shapeblocks[0, 0] = true;
                    shapeblocks[1, 0] = true;
                    shapeblocks[1, 2] = true;
                    break;
                case (Shape.rShape):
                    shapeblocks = new bool[3, 3];
                    shapeblocks[1, 1] = true;
                    shapeblocks[0, 2] = true;
                    shapeblocks[1, 0] = true;
                    shapeblocks[1, 2] = true;
                    break;
                case (Shape.TShape):
                    shapeblocks = new bool[3, 3];
                    shapeblocks[0, 0] = true;
                    shapeblocks[0, 1] = true;
                    shapeblocks[0, 2] = true;
                    shapeblocks[1, 1] = true;
                    break;
                case (Shape.OShape):
                    shapeblocks = new bool[2, 2];
                    shapeblocks[0, 0] = true;
                    shapeblocks[0, 1] = true;
                    shapeblocks[1, 0] = true;
                    shapeblocks[1, 1] = true;
                    break;
                case (Shape.ZShape):
                    shapeblocks = new bool[3, 3];
                    shapeblocks[0, 0] = true;
                    shapeblocks[0, 1] = true;
                    shapeblocks[1, 1] = true;
                    shapeblocks[1, 2] = true;
                    break;
                case (Shape.SShape):
                    shapeblocks = new bool[3, 3];
                    shapeblocks[0, 2] = true;
                    shapeblocks[0, 1] = true;
                    shapeblocks[1, 1] = true;
                    shapeblocks[1, 0] = true;
                    break;
            }
        }

        public FallShape(FallShape input)
        {
            Color = input.Color;
            ShapeType = input.ShapeType;
            x = input.x;
            y = input.y;
            int n = input.shapeblocks.GetLength(0);
            shapeblocks = new bool[n, n];
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    shapeblocks[i, j] = input.shapeblocks[i, j]; 
        }
        
        public void Rotate()
        {
            int n = shapeblocks.GetLength(0);
            for (int i = 0; i < n / 2; i++)
                for (int j = 0; j < (n + 1) / 2; j++)
                {
                    bool temp = shapeblocks[i, j];
                    shapeblocks[i, j] = shapeblocks[n - 1 - j, i];
                    shapeblocks[n - 1 - j, i] = shapeblocks[n - 1 - i, n - 1 - j];
                    shapeblocks[n - 1 - i, n - 1 - j] = shapeblocks[j, n - 1 - i];
                    shapeblocks[j, n - 1 - i] = temp;
                }
        }
    }
}





/* public GameBoard ShowShape(GameBoard board)
        {
            switch (ShapeType)
            {
                case (Shape.IShape):
                    board.board[x, y].Color = Color;
                    if (x > 0) board.board[x - 1, y].Color = Color;
                    if (x > 1) board.board[x - 2, y].Color = Color;
                    if (x > 2) board.board[x - 3, y].Color = Color;
                    break;
                case (Shape.LShape):
                    board.board[x, y].Color = Color;
                    board.board[x, y + 1].Color = Color;
                    if (x > 0) board.board[x - 1, y].Color = Color;
                    if (x > 1) board.board[x - 2, y].Color = Color;
                    break;
                case (Shape.TShape):
                    board.board[x, y].Color = Color;
                    board.board[x, y - 1].Color = Color;
                    board.board[x, y + 1].Color = Color;
                    if (x > 0) board.board[x - 1, y].Color = Color;
                    break;
                case (Shape.OShape):
                    board.board[x, y].Color = Color;
                    board.board[x, y + 1].Color = Color;
                    if (x > 0)
                    {
                        board.board[x - 1, y].Color = Color;
                        board.board[x - 1, y + 1].Color = Color;
                    }
                    break;
                case (Shape.ZShape):
                    board.board[x, y].Color = Color;
                    if (x > 0) board.board[x - 1, y].Color = Color;
                    if (x > 0) board.board[x - 1, y + 1].Color = Color;
                    if (x > 1) board.board[x - 2, y + 1].Color = Color;
                    break;
                case (Shape.SShape):
                    board.board[x, y].Color = Color;
                    if (x > 0) board.board[x - 1, y].Color = Color;
                    if (x > 0) board.board[x - 1, y - 1].Color = Color;
                    if (x > 1) board.board[x - 2, y - 1].Color = Color;
                    break;
                default:
                    break;
            }
            return board;
        }

        public GameBoard HideShape(GameBoard board)
        {
            switch (ShapeType)
            {
                case (Shape.IShape):
                    board.board[x, y].Color = ConsoleColor.Black;
                    if (x > 0) board.board[x - 1, y].Color = ConsoleColor.Black;
                    if (x > 1) board.board[x - 2, y].Color = ConsoleColor.Black;
                    if (x > 2) board.board[x - 3, y].Color = ConsoleColor.Black;
                    break;
                case (Shape.LShape):
                    board.board[x, y].Color = ConsoleColor.Black;
                    board.board[x, y + 1].Color = ConsoleColor.Black;
                    if (x > 0) board.board[x - 1, y].Color = ConsoleColor.Black;
                    if (x > 1) board.board[x - 2, y].Color = ConsoleColor.Black;
                    break;
                case (Shape.TShape):
                    board.board[x, y].Color = ConsoleColor.Black;
                    board.board[x, y - 1].Color = ConsoleColor.Black;
                    board.board[x, y + 1].Color = ConsoleColor.Black;
                    if (x > 0) board.board[x - 1, y].Color = ConsoleColor.Black;
                    break;
                case (Shape.OShape):
                    board.board[x, y].Color = ConsoleColor.Black;
                    board.board[x, y + 1].Color = ConsoleColor.Black;
                    if (x > 0)
                    {
                        board.board[x - 1, y].Color = ConsoleColor.Black;
                        board.board[x - 1, y + 1].Color = ConsoleColor.Black;
                    }
                    break;
                case (Shape.ZShape):
                    board.board[x, y].Color = ConsoleColor.Black;
                    if (x > 0) board.board[x - 1, y].Color = ConsoleColor.Black;
                    if (x > 0) board.board[x - 1, y + 1].Color = ConsoleColor.Black;
                    if (x > 1) board.board[x - 2, y + 1].Color = ConsoleColor.Black;
                    break;
                case (Shape.SShape):
                    board.board[x, y].Color = ConsoleColor.Black;
                    if (x > 0) board.board[x - 1, y].Color = ConsoleColor.Black;
                    if (x > 0) board.board[x - 1, y - 1].Color = ConsoleColor.Black;
                    if (x > 1) board.board[x - 2, y - 1].Color = ConsoleColor.Black;
                    break;
                default:
                    break;
            }
            return board;
        }*/