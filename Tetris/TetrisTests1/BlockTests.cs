using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tetris;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlockTests
{
    [TestClass]
    public class BlockTests
    {
        [TestMethod]
        public void IsBlockEmpty_Test_0()
        {
            Block actual = new Block();
            Assert.AreEqual(actual.IsBlockEmpty(), true);
        }

        [TestMethod]
        public void IsBlockEmpty_Test_1()
        {
            Block actual = new Block(ConsoleColor.Black);
            Assert.AreEqual(actual.IsBlockEmpty(), true);
        }

        [TestMethod]
        public void IsBlockEmpty_Test_2()
        {
            for (int i = 0; i < 50; i++)
            {
                Random rng = new Random((int)DateTime.Now.Ticks);
                Block actual = new Block((ConsoleColor)rng.Next(1, 15));
                Assert.AreEqual(actual.IsBlockEmpty(), false);
            }
        }
    }
}