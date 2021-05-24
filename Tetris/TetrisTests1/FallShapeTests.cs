using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tetris;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fallshape.Tests
{
    [TestClass]
    public class FallShapeTests
    {
        public void AreArrayEqual(bool[,] expected, bool[,] actual)
        {
            if (expected.GetLength(0) != actual.GetLength(0) || expected.GetLength(1) != actual.GetLength(1))
            {
                Assert.Fail();
                return;
            }
            for (int i = 0; i < expected.GetLength(1); i++)
                for (int j = 0; j < expected.GetLength(1); j++)
                    Assert.AreEqual(expected[i, j], actual[i, j]);
        }

        [TestMethod]
        public void Rotate_Test()
        {
            for (int k = 0; k < 50; k++)
            {
                bool[,] testShapeArray = new bool[3, 3];
                bool[,] expectedShapeArray = new bool[3, 3];
                Random rng = new Random((int)DateTime.Now.Ticks);
                for (int i = 0; i < 3; i++)
                    for (int j = 0; j < 3; j++)
                    {
                        if (rng.Next() == 1)
                        {
                            testShapeArray[i, j] = true;
                            expectedShapeArray[2 - j, i] = true;
                        }
                        else
                        {
                            testShapeArray[i, j] = false;
                            expectedShapeArray[2 - j, i] = false;
                        }
                    }

                FallShape testShape = new FallShape();
                testShape.shapeblocks = testShapeArray;

                testShape.Rotate();

                AreArrayEqual(expectedShapeArray, testShape.shapeblocks);
            }
        }
    }
}