using System;
using System.Collections.Generic;
using System.Media;

namespace Tetris
{
    class Player
    {
        public void Move()
        {
            SoundPlayer sound = new SoundPlayer("Move.wav");
            sound.Play();
        }
        public void Up()
        {
            SoundPlayer sound = new SoundPlayer("Up.wav");
            sound.Play();
        }
        public void GameOver()
        {
            SoundPlayer sound = new SoundPlayer("GameOver.wav");
            sound.Play();
        }
        public void Line()
        {
            SoundPlayer sound = new SoundPlayer("Line.wav");
            sound.Play();
        }
        public void Record()
        {
            SoundPlayer sound = new SoundPlayer("Record.wav");
            sound.Play();
        }
        public void GameStart()
        {
            SoundPlayer sound = new SoundPlayer("GameStart.wav");
            sound.Play();
        }
    }
}
