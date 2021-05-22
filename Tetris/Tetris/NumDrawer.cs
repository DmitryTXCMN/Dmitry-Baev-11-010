using System;
using System.Collections.Generic;
using System.Text;

namespace Tetris
{
    class NumDrawer
    {
        public NumDrawer()
        { }

        public void SetNumber(int x, int y, int num)
        {
            Console.ForegroundColor = ConsoleColor.White;
            SetDigit(x, y, num / 10000);
            SetDigit(x + 5, y, num % 10000 / 1000);
            SetDigit(x + 10, y, num % 1000 / 100);
            SetDigit(x + 15, y, num % 100 / 10);
            SetDigit(x + 20, y, num % 10);
        }

        public void SetDigit(int x, int y, int digit)
        {
            switch (digit)
            {
                case (1):
                    Console.SetCursorPosition(x, y);
                    Console.Write("   ■");
                    Console.SetCursorPosition(x, y + 1);
                    Console.Write("  ■■");
                    Console.SetCursorPosition(x, y + 2);
                    Console.Write(" ■ ■");
                    Console.SetCursorPosition(x, y + 3);
                    Console.Write("   ■");
                    Console.SetCursorPosition(x, y + 4);
                    Console.Write("   ■");
                    Console.SetCursorPosition(x, y + 5);
                    Console.Write("   ■");
                    break;
                case (2):
                    Console.SetCursorPosition(x, y);
                    Console.Write(" ■■ ");
                    Console.SetCursorPosition(x, y + 1);
                    Console.Write("■  ■");
                    Console.SetCursorPosition(x, y + 2);
                    Console.Write("   ■");
                    Console.SetCursorPosition(x, y + 3);
                    Console.Write(" ■■ ");
                    Console.SetCursorPosition(x, y + 4);
                    Console.Write("■   ");
                    Console.SetCursorPosition(x, y + 5);
                    Console.Write("■■■■");
                    break;
                case (3):
                    Console.SetCursorPosition(x, y);
                    Console.Write(" ■■ ");
                    Console.SetCursorPosition(x, y + 1);
                    Console.Write("■  ■");
                    Console.SetCursorPosition(x, y + 2);
                    Console.Write("  ■ ");
                    Console.SetCursorPosition(x, y + 3);
                    Console.Write("   ■");
                    Console.SetCursorPosition(x, y + 4);
                    Console.Write("■  ■");
                    Console.SetCursorPosition(x, y + 5);
                    Console.Write(" ■■ ");
                    break;
                case (4):
                    Console.SetCursorPosition(x, y);
                    Console.Write("  ■■");
                    Console.SetCursorPosition(x, y + 1);
                    Console.Write(" ■ ■");
                    Console.SetCursorPosition(x, y + 2);
                    Console.Write("■  ■");
                    Console.SetCursorPosition(x, y + 3);
                    Console.Write("■■■■");
                    Console.SetCursorPosition(x, y + 4);
                    Console.Write("   ■");
                    Console.SetCursorPosition(x, y + 5);
                    Console.Write("   ■");
                    break;
                case (5):
                    Console.SetCursorPosition(x, y);
                    Console.Write("■■■■");
                    Console.SetCursorPosition(x, y + 1);
                    Console.Write("■   ");
                    Console.SetCursorPosition(x, y + 2);
                    Console.Write("■■■ ");
                    Console.SetCursorPosition(x, y + 3);
                    Console.Write("   ■");
                    Console.SetCursorPosition(x, y + 4);
                    Console.Write("■  ■");
                    Console.SetCursorPosition(x, y + 5);
                    Console.Write(" ■■ ");
                    break;
                case (6):
                    Console.SetCursorPosition(x, y);
                    Console.Write(" ■■ ");
                    Console.SetCursorPosition(x, y + 1);
                    Console.Write("■  ■");
                    Console.SetCursorPosition(x, y + 2);
                    Console.Write("■   ");
                    Console.SetCursorPosition(x, y + 3);
                    Console.Write("■■■ ");
                    Console.SetCursorPosition(x, y + 4);
                    Console.Write("■  ■");
                    Console.SetCursorPosition(x, y + 5);
                    Console.Write(" ■■ ");
                    break;
                case (7):
                    Console.SetCursorPosition(x, y);
                    Console.Write("■■■");
                    Console.SetCursorPosition(x, y + 1);
                    Console.Write("   ■");
                    Console.SetCursorPosition(x, y + 2);
                    Console.Write("  ■ ");
                    Console.SetCursorPosition(x, y + 3);
                    Console.Write(" ■  ");
                    Console.SetCursorPosition(x, y + 4);
                    Console.Write("■   ");
                    Console.SetCursorPosition(x, y + 5);
                    Console.Write("■   ");
                    break;
                case (8):
                    Console.SetCursorPosition(x, y);
                    Console.Write(" ■■ ");
                    Console.SetCursorPosition(x, y + 1);
                    Console.Write("■  ■");
                    Console.SetCursorPosition(x, y + 2);
                    Console.Write(" ■■ ");
                    Console.SetCursorPosition(x, y + 3);
                    Console.Write("■  ■");
                    Console.SetCursorPosition(x, y + 4);
                    Console.Write("■  ■");
                    Console.SetCursorPosition(x, y + 5);
                    Console.Write(" ■■ ");
                    break;
                case (9):
                    Console.SetCursorPosition(x, y);
                    Console.Write(" ■■ ");
                    Console.SetCursorPosition(x, y + 1);
                    Console.Write("■  ■");
                    Console.SetCursorPosition(x, y + 2);
                    Console.Write(" ■■■");
                    Console.SetCursorPosition(x, y + 3);
                    Console.Write("   ■");
                    Console.SetCursorPosition(x, y + 4);
                    Console.Write("■  ■");
                    Console.SetCursorPosition(x, y + 5);
                    Console.Write(" ■■ ");
                    break;
                case (0):
                    Console.SetCursorPosition(x, y);
                    Console.Write(" ■■ ");
                    Console.SetCursorPosition(x, y + 1);
                    Console.Write("■  ■");
                    Console.SetCursorPosition(x, y + 2);
                    Console.Write("■ ■■");
                    Console.SetCursorPosition(x, y + 3);
                    Console.Write("■■ ■");
                    Console.SetCursorPosition(x, y + 4);
                    Console.Write("■  ■");
                    Console.SetCursorPosition(x, y + 5);
                    Console.Write(" ■■ ");
                    break;
                default:
                    break;
            }
        }
    }
}
