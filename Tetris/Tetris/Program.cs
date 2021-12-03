using System;
using System.Media;
using System.Diagnostics;

namespace Tetris
{
    class Program : GameProgress
    {
        public static void FullDesk()
        {
            for (int s = 0; s < 72; s++)
            {
                for (int si = 0; si < 269; si++)
                    Console.Write('0');
                Console.Write('\n');
            }
            UserInterface deskUI = new UserInterface();
            deskUI.StartSetup();
        }

        static void Main(string[] args)
        {
            while (true)
            {
                SoundPlayer music = new SoundPlayer("TetrisSong.wav");
                music.Play();
                Console.Clear();
                Console.WriteLine("Введите ваше имя");
                string playerName = Console.ReadLine();
                Console.Clear();
                Console.WriteLine("Выберите режим игры. Classic - Нажмите Любую кнопку / Modded - Нажмите Пробел");
                var gameMode = Console.ReadKey();
                Console.Clear();
                UserInterface deskUI = new UserInterface();
                deskUI.StartSetup();
                GameProgress game = new GameProgress();
                if (gameMode.Key == ConsoleKey.Spacebar)
                    game.GameModded(playerName);
                else
                    game.Game(playerName);
                Console.WriteLine("\n\n ESC - выход \n Любая кнопка - рестарт\n");
                var keyPressed = Console.ReadKey();
                if (keyPressed.Key == ConsoleKey.Escape)
                    Process.GetCurrentProcess().Kill();
            }
        }
    }
}