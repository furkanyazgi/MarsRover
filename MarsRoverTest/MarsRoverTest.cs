using System.Collections.Generic;
using MarsRover.ValueObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MarsRoverTest
{
    [TestClass]
    public class MarsRoverTest
    {
        [TestMethod]
        public void TestInput_55_12N_LMLMLMLMM_Than_Check_Result_13N()
        {
            var position = new Position()
            {
                X = 1,
                Y = 2,
                Direction = Directions.N
            };

            var maxPoints = new List<int>() { 5, 5 };
            const string moves = "LMLMLMLMM";

            position.StartMoving(maxPoints, moves);

            var actualOutput = $"{position.X} {position.Y} {position.Direction.ToString()}";
            const string expectedOutput = "1 3 N";

            Assert.AreEqual(expectedOutput, actualOutput);
        }

        [TestMethod]
        public void TestInput_33E_MMRMMRMRRM_Than_Check_Result_51E()
        {
            var position = new Position()
            {
                X = 3,
                Y = 3,
                Direction = Directions.E
            };

            var maxPoints = new List<int>() { 5, 5 };
            const string moves = "MMRMMRMRRM";

            position.StartMoving(maxPoints, moves);

            var actualOutput = $"{position.X} {position.Y} {position.Direction.ToString()}";
            const string expectedOutput = "5 1 E";

            Assert.AreEqual(expectedOutput, actualOutput);
        }
    }
}
