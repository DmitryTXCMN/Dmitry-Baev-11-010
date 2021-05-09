using System;
using System.Collections.Generic;
using System.Media;

namespace Tetris
{
    class Player
    {
        public void StartMainTheme()
        {
            SoundPlayer music = new SoundPlayer("TetrisSong.wav");
            music.Play();
        }
    }
}
