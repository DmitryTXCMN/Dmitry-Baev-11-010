using System;
using System.Collections.Generic;

namespace AISD
{
    class Program
    {
        enum Direction
        {
            Left = 0,
            Up= 1,
            Right = 2,
            Down = 3
        }

        static int[,] CreateLab()
        {
            int[,] field = new int[10, 10];
            for (int i = 0; i < 10; i++)
                for (int j = 0; j < 10; j++)
                    field[i, j] = 0;
           
            field[5, 5] = 1;
            field[5, 4] = 1;
            field[3, 5] = 1;
            field[5, 3] = 1;
            field[4, 5] = 1;
            field[6, 5] = 1;
            field[5, 6] = 1;
            field[5, 7] = 1;
            field[5, 8] = 1;
            field[5, 9] = 0;
            field[4, 3] = 1;
            field[3, 3] = 1;
            field[3, 4] = 1;
            field[3, 2] = 1;
            field[3, 1] = 1;
            field[2, 1] = 1;
            field[1, 1] = 1;
            field[1, 2] = 1;
            field[1, 3] = 1;
            field[1, 4] = 1;
            field[1, 5] = 1;
            field[1, 6] = 1;
            field[2, 6] = 1;
            field[3, 6] = 1;
            field[4, 6] = 1;
            field[6, 4] = 1;
            field[6, 3] = 1;
            field[7, 3] = 1;
            field[7, 2] = 1;
            field[8, 2] = 1;
            field[9, 2] = 1;
            return field;
        }

        static void ShowLab(int[,] field)
        {
            Console.WriteLine();
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                    if (field[i, j] == 1) Console.Write(" ");
                    else if (field[i, j] == 2) Console.Write("*");
                    else Console.Write("#");
                Console.WriteLine();
            }
        }

        static bool CanGo(int[,] field, int xpos, int ypos, Direction dir)
        {
            switch (dir)
            {
                case Direction.Left:
                    if (field[xpos, ypos - 1] == 1) return true;
                    return false;
                case Direction.Right:
                    if (field[xpos, ypos + 1] == 1) return true;
                    return false;
                case Direction.Up:
                    if (field[xpos + 1, ypos] == 1) return true;
                    return false;
                case Direction.Down:
                    if (field[xpos - 1, ypos] == 1) return true;
                    return false;
                default:
                    return false;
            }
        }

        static bool CanGoBack(int[,] field, int xpos, int ypos, Direction dir)
        {
            switch (dir)
            {
                case Direction.Left:
                    if (field[xpos, ypos - 1] == 2) return true;
                    return false;
                case Direction.Right:
                    if (field[xpos, ypos + 1] == 2) return true;
                    return false;
                case Direction.Up:
                    if (field[xpos + 1, ypos] == 2) return true;
                    return false;
                case Direction.Down:
                    if (field[xpos - 1, ypos] == 2) return true;
                    return false;
                default:
                    return false;
            }
        }

        static void Go(int[,] field, ref int xpos, ref int ypos, Direction dir)
        {
            switch (dir)
            {
                case Direction.Left:
                    field[xpos, --ypos] = 2;
                    break;
                case Direction.Right:
                    field[xpos, ++ypos] = 2;
                    break;
                case Direction.Up:
                    field[++xpos, ypos] = 2;
                    break;
                case Direction.Down:
                    field[--xpos, ypos] = 2;
                    break;
                default:
                    break;
            }
        }

        static void GoBack(int[,] field, ref int xpos, ref int ypos, Direction dir)
        {
            switch (dir)
            {
                case Direction.Left:
                    field[xpos, ypos--] = 0;
                    break;
                case Direction.Right:
                    field[xpos, ypos++] = 0;
                    break;
                case Direction.Up:
                    field[xpos++, ypos] = 0;
                    break;
                case Direction.Down:
                    field[xpos--, ypos] = 0;
                    break;
                default:
                    break;
            }
        }

        static void Main(string[] args)
        {
            int[,] field = CreateLab();
            ShowLab(field);
            int xPos = 5;
            int yPos = 5;
            Stack<int[]> way = new Stack<int[]>();
            field[xPos, yPos] = 2;
            way.Push(new int[] { xPos, yPos });

            while (xPos != 0 && xPos != 9 && yPos != 0 && yPos != 9)
            {
                Direction currentDirection = Direction.Left;
                int nextStep = 0;
                for (int i = 0; i < 4; i++)
                    if (CanGo(field, xPos, yPos, currentDirection))
                    {
                        nextStep = 1;
                        break;
                    }
                    else if (currentDirection != Direction.Down) currentDirection = (Direction)((int)currentDirection + 1);
                    else currentDirection = Direction.Left;
                if (nextStep != 1)
                    for (int i = 0; i < 4; i++)
                        if (CanGoBack(field, xPos, yPos, currentDirection))
                        {
                            nextStep = 2;
                            break;
                        }
                        else if (currentDirection != Direction.Down) currentDirection = (Direction)((int)currentDirection + 1);
                        else currentDirection = Direction.Left;
                if (nextStep == 0)
                {
                    Console.WriteLine("путей нету!");
                    break;
                }
                if (nextStep == 2 && field[xPos, yPos] == 2)
                {
                    GoBack(field, ref xPos, ref yPos, currentDirection);
                    way.Pop();

                }
                else
                {
                    Go(field, ref xPos, ref yPos, currentDirection);
                    way.Push(new int[] { xPos, yPos });
                }
                ShowLab(field);
            }
            foreach (var step in way)
                Console.Write("(" + step[0] + ";" + step[1] + ") <- ");
        }
    }
}
