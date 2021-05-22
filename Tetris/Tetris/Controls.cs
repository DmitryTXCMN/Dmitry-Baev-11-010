using System;
using System.Collections.Generic;
using System.Text;

namespace Tetris
{
    class Controls
    {
        public int timer { get; set; }

        public void ModRotate(GameBoard board,ref FallShape shape)
        {
            GameBoard tempBoard = board.Copy();
            FallShape tempShape = new FallShape();
            bool catchError = true;
            while (catchError)
            {
                catchError = false;
                tempShape = new FallShape();
                tempShape.x = shape.x;
                tempShape.y = shape.y;
                Random rng = new Random();

                for (int i = 0; i < rng.Next(1, 5); i++)
                {
                    Rotate(tempBoard, tempShape);
                }
                try
                {
                    tempBoard.PlaceShape(tempShape, tempShape.x, tempShape.y);
                }
                catch
                { catchError = true;}
            }
            shape = new FallShape(tempShape);
        }

        public void Rotate(GameBoard board, FallShape shape)
        {
            GameBoard tempBoard = board.Copy();
            FallShape tempShape = new FallShape(shape);
            tempShape.Rotate();
            try
            {
                tempBoard.PlaceShape(tempShape, shape.x, shape.y);
            }
            catch
            {
                try
                {
                    tempBoard = board.Copy();
                    tempBoard.PlaceShape(tempShape, shape.x, shape.y+1);
                }
                catch
                {
                    try
                    {
                        tempBoard = board.Copy();
                        tempBoard.PlaceShape(tempShape, shape.x, shape.y-1);
                    }
                    catch
                    {
                        if (tempShape.ShapeType == FallShape.Shape.IShape)
                        {
                            try
                            {
                                tempBoard = board.Copy();
                                tempBoard.PlaceShape(tempShape, shape.x, shape.y - 2);
                            }
                            catch
                            {
                                try
                                {
                                    tempBoard = board.Copy();
                                    tempBoard.PlaceShape(tempShape, shape.x, shape.y + 2);
                                }
                                catch
                                {
                                    return;
                                }
                                shape.y += 2;
                                shape.Rotate();
                                return;
                            }
                            shape.y -= 2;
                            shape.Rotate();
                        }
                        return;
                    }
                    shape.y--;
                    shape.Rotate();
                    return;
                }
                shape.y++;
                shape.Rotate();
                return;
            }
            shape.Rotate();
            return;
        }

        public void Move(GameBoard board, FallShape shape, int direction)
        {
            GameBoard tempBoard = board.Copy();
            try
            {
                tempBoard.PlaceShape(shape, shape.x, shape.y + direction);
            }
            catch
            {
                return;
            }
            shape.y += direction;
        }

        public void Fall(GameBoard board, FallShape shape, ref bool shapeCollision)
        {
            GameBoard tempBoard = board.Copy();
            try
            {
                tempBoard.PlaceShape(shape, shape.x + 1, shape.y);
            }
            catch
            {
                shapeCollision = true;
                board.PlaceShape(shape, shape.x, shape.y);
                return;
            }
            shape.x++;
        }
    }
}
