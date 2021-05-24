using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tetris;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameBoardTests
{
    [TestClass]
    public class GameBoardTests
    {
        public void AreBoardEqual(GameBoard expected, GameBoard actual)
        {
            for (int i = 0; i < 20; i++)
                for (int j = 0; j < 10; j++)
                    Assert.AreEqual(expected.board[i, j].Color, actual.board[i, j].Color);
        }

        [TestMethod]
        public void DellString_Test_0()
        {
            GameBoard actual = new GameBoard();
            GameBoard expected = new GameBoard();
            for (int i = 0; i < 10; i++)
                actual.board[4, i] = new Block(ConsoleColor.Red);

            actual.DellString(4);

            AreBoardEqual(expected, actual);
        }

        [TestMethod]
        public void DellString_Test_1()
        {
            GameBoard actual = new GameBoard();
            GameBoard expected = new GameBoard();
            for (int i = 0; i < 10; i++)
                actual.board[4, i] = new Block(ConsoleColor.Red);
            actual.board[7, 9] = new Block(ConsoleColor.Red);
            expected.board[7, 9] = new Block(ConsoleColor.Red);

            actual.DellString(4);

            AreBoardEqual(expected, actual);
        }

        [TestMethod]
        public void DellString_Test_2()
        {
            GameBoard actual = new GameBoard();
            GameBoard expected = new GameBoard();
            for (int i = 0; i < 10; i++)
                actual.board[4, i] = new Block(ConsoleColor.Red);
            actual.board[2, 9] = new Block(ConsoleColor.Red);
            expected.board[3, 9] = new Block(ConsoleColor.Red);

            actual.DellString(4);

            AreBoardEqual(expected, actual);
        }

        [TestMethod]
        public void CheckFullLines_Test_0()
        {
            int deleted = 0;
            GameBoard actual = new GameBoard();

            for (int i = 0; i < 9; i++)
                actual.board[15, i] = new Block(ConsoleColor.Red);

            actual.CheckFullLines(ref deleted);

            Assert.AreEqual(deleted, 0);
        }

        [TestMethod]
        public void CheckFullLines_Test_1()
        {
            int deleted = 0;
            GameBoard actual = new GameBoard();

            for (int i = 0; i < 10; i++)
                actual.board[15, i] = new Block(ConsoleColor.Red);

            actual.CheckFullLines(ref deleted);

            Assert.AreEqual(deleted, 1);
        }

        [TestMethod]
        public void CheckFullLines_Test_2()
        {
            int deleted = 0;
            GameBoard actual = new GameBoard();

            for (int i = 0; i < 2; i++)
                for (int j = 0; j < 10; j++)
                actual.board[15+i, j] = new Block(ConsoleColor.Red);

            actual.CheckFullLines(ref deleted);

            Assert.AreEqual(deleted, 2);
        }

        [TestMethod]
        public void CheckFullLines_Test_3()
        {
            int deleted = 0;
            GameBoard actual = new GameBoard();

            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 10; j++)
                    actual.board[15 + i, j] = new Block(ConsoleColor.Red);

            actual.CheckFullLines(ref deleted);

            Assert.AreEqual(deleted, 3);
        }

        [TestMethod]
        public void CheckFullLines_Test_4()
        {
            int deleted = 0;
            GameBoard actual = new GameBoard();

            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 10; j++)
                    actual.board[15 + i, j] = new Block(ConsoleColor.Red);

            actual.CheckFullLines(ref deleted);

            Assert.AreEqual(deleted, 4);
        }

        [TestMethod]
        public void CheckFullLines_Test_5()
        {
            int deleted = 0;
            GameBoard actual = new GameBoard();

            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 10; j++)
                    actual.board[15 + i, j] = new Block(ConsoleColor.Red);

            actual.DellString(17);

            actual.CheckFullLines(ref deleted);

            Assert.AreEqual(deleted, 3);
        }

        [TestMethod]
        public void CheckFullLines_Test_6()
        {
            int deleted = 0;
            GameBoard actual = new GameBoard();

            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 10; j++)
                    actual.board[15 + i, j] = new Block(ConsoleColor.Red);

            actual.DellString(16);
            actual.DellString(17);

            actual.CheckFullLines(ref deleted);

            Assert.AreEqual(deleted, 2);
        }
    }
}