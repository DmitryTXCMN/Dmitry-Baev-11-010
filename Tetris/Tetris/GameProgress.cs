using System;
using System.Threading;
using System.IO;
using System.Media;

namespace Tetris
{
    class GameProgress : Controls
    {
        int hard = 150;
        int score = 0;

        public GameProgress()
        {

        }

        public void FallSleep(GameBoard currentBoard, FallShape currentShape, ref bool collision ,int fallTimeInTicks, ref bool done)
        {
            Thread.Sleep(fallTimeInTicks);
            if (!collision && !done) Fall(currentBoard, currentShape, ref collision);
            done = true;
        }

        public void GameModded(string playerName)
        {
            Player soundPlayer = new Player();
            soundPlayer.GameStart();
            Thread.Sleep(2000);
            GameBoard currentBoard = new GameBoard();
            GameBoard tempBoard = new GameBoard();
            FallShape currentShape = new FallShape();
            FallShape nextShape = new FallShape();
            UserInterface drawerUI = new UserInterface();

            int highscore;
            using (StreamReader reader = new StreamReader("highscore.txt"))
            {
                highscore = Convert.ToInt32(reader.ReadLine());
                drawerUI.DrawHighScoreUI(highscore);
            }
            bool collision = true;
            while (true)
            {
                currentShape = new FallShape(nextShape);
                nextShape = new FallShape();
                drawerUI.DrawNewShapeUI(nextShape);
                collision = false;
                tempBoard = currentBoard.Copy();
                try
                {
                    tempBoard.Copy().PlaceShape(currentShape, currentShape.x, currentShape.y);
                }
                catch
                {
                    break;
                }
                currentBoard.UpdateFrame('y', currentShape);
                while (!collision)
                {
                    bool done = false;
                    Thread falling = new Thread(() =>
                    {
                        FallSleep(currentBoard, currentShape, ref collision, hard, ref done);
                    });
                    falling.Start();
                    while (!done)
                    {
                        if (Console.KeyAvailable)
                        {
                            var pressedKey = Console.ReadKey();
                            if (done) break;
                            switch (pressedKey.Key)
                            {
                                case ConsoleKey.LeftArrow:
                                    Move(currentBoard, currentShape, -1);
                                    soundPlayer.Move();
                                    break;
                                case ConsoleKey.RightArrow:
                                    Move(currentBoard, currentShape, 1);
                                    soundPlayer.Move();
                                    break;
                                case ConsoleKey.UpArrow:
                                    ModRotate(currentBoard, ref currentShape);
                                    soundPlayer.Up();
                                    break;
                                case ConsoleKey.DownArrow:
                                    if (!collision)
                                    {
                                        soundPlayer.Up();
                                        Fall(currentBoard, currentShape, ref collision);
                                        done = true;
                                    }
                                    break;
                                default:
                                    break;
                            }
                        }
                        if (!collision) currentBoard.UpdateFrame('y', currentShape);
                    }
                }
                int deleted = 0;
                currentBoard.CheckFullLines(ref deleted);
                if (deleted != 0)
                    soundPlayer.Line();
                drawerUI.DrawScoreUI(score += 5 * deleted * deleted + 500 / hard);
            }
            SoundPlayer music = new SoundPlayer("GameOver.wav");
            music.Play();
            Thread.Sleep(3000);
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Игра окончена. Ваш счёт: " + score);
            File.AppendAllText("results.txt", score.ToString() + " " + playerName + " / modded\n");
            if (score > highscore)
            {
                File.WriteAllText("highscore.txt", score.ToString());
                Console.WriteLine("☺!!!НОВЫЙ РЕКОРД!!!☺");
                soundPlayer.Record();
            }
            Thread.Sleep(3000);
        }

        public void Game(string playerName)
        {
            Player soundPlayer = new Player();
            soundPlayer.GameStart();
            Thread.Sleep(2000);
            GameBoard currentBoard = new GameBoard();
            GameBoard tempBoard = new GameBoard();
            FallShape currentShape = new FallShape();
            FallShape nextShape = new FallShape();
            UserInterface drawerUI = new UserInterface();
            
            int highscore;
            using (StreamReader reader = new StreamReader("highscore.txt"))
            {
                highscore = Convert.ToInt32(reader.ReadLine());
                drawerUI.DrawHighScoreUI(highscore);
            }
            bool collision = true;
            while (true)
            {
                currentShape = new FallShape(nextShape);
                nextShape = new FallShape();
                drawerUI.DrawNewShapeUI(nextShape);
                collision = false;
                tempBoard = currentBoard.Copy();
                try
                {
                    tempBoard.Copy().PlaceShape(currentShape, currentShape.x, currentShape.y);
                }
                catch
                {
                    break;
                }
                currentBoard.UpdateFrame('y', currentShape);
                while (!collision)
                {
                    bool done = false;
                    Thread falling = new Thread(() =>
                    {
                        FallSleep(currentBoard, currentShape, ref collision, hard, ref done);
                    });
                    falling.Start();
                    while (!done)
                    {
                        if (Console.KeyAvailable)
                        {
                            var pressedKey = Console.ReadKey();
                            if (done) break;
                            switch (pressedKey.Key)
                            {
                                case ConsoleKey.LeftArrow:
                                    Move(currentBoard, currentShape, -1);
                                    soundPlayer.Move();
                                    break;
                                case ConsoleKey.RightArrow:
                                    Move(currentBoard, currentShape, 1);
                                    soundPlayer.Move();
                                    break;
                                case ConsoleKey.UpArrow:
                                    Rotate(currentBoard, currentShape);
                                    soundPlayer.Up();
                                    break;
                                case ConsoleKey.DownArrow:
                                    if (!collision)
                                    {
                                        soundPlayer.Up();
                                        Fall(currentBoard, currentShape, ref collision);
                                        done = true;
                                    }
                                    break;
                                default:
                                    break;
                            }
                        }
                        if (!collision) currentBoard.UpdateFrame('y', currentShape);
                    }
                }
                int deleted = 0;
                currentBoard.CheckFullLines(ref deleted);
                if (deleted != 0)
                    soundPlayer.Line();
                drawerUI.DrawScoreUI(score += 5 * deleted * deleted + 500 / hard);
            }
            SoundPlayer music = new SoundPlayer("GameOver.wav");
            music.Play();
            Thread.Sleep(3000);
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Игра окончена. Ваш счёт: "+score);
            File.AppendAllText("results.txt", score.ToString() + " " + playerName);
            if (score > highscore)
            {
                File.WriteAllText("highscore.txt", score.ToString());
                Console.WriteLine("☺!!!НОВЫЙ РЕКОРД!!!☺");
                soundPlayer.Record();
            }
            Thread.Sleep(3000);
        }
    }
}
