using System;
using System.Collections.Generic;
using System.Text;

namespace Tetris
{
    public class Block
    {
        public ConsoleColor Color { get; set; }

        public Block()
        {
            Color = ConsoleColor.Black;
        }

        public Block(ConsoleColor inputColor)
        {
            Color = inputColor;
        }

        public bool IsBlockEmpty()
        {
            if (Color == ConsoleColor.Black) return true;
            return false;
        }
    }
}
