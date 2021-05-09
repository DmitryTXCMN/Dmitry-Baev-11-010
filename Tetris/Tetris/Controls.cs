using System;
using System.Collections.Generic;
using System.Text;

namespace Tetris
{
    class Controls
    {
        public int timer { get; set; }
        public void Rotate(GameBoard board, FallShape shape)
        {
            GameBoard tempBoard = board.Copy();
            FallShape tempShape = new FallShape(shape);
            try
            {
                tempShape.Rotate();
                tempBoard.PlaceShape(tempShape, shape.x, shape.y);
            }
            catch
            {
                try
                {
                    tempBoard = board.Copy();
                    tempShape.Rotate();
                    tempBoard.PlaceShape(tempShape, shape.x, shape.y);
                }
                catch
                {
                    try
                    {
                        tempBoard = board.Copy();
                        tempShape.Rotate();
                        tempBoard.PlaceShape(tempShape, shape.x, shape.y);
                    }
                    catch
                    {
                        return;
                    }
                    shape.Rotate();
                    shape.Rotate();
                    shape.Rotate();
                    return;
                }
                shape.Rotate();
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
