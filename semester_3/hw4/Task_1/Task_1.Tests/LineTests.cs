namespace Task_1.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Task_1.Model;

    /// <summary>
    /// Tests for <see cref="Line"/> class.
    /// </summary>
    [TestClass]
    public class LineTests
    {
        private readonly Random rand = new Random();
        private IList<Line> lines;
        private IList<IList<Point>> points;

        [TestInitialize]
        public void Initialize()
        {
            var data = new DataClass("lines.txt", "points.txt");
            this.lines = data.Lines;
            this.points = data.Points;
        }
            
        [TestMethod]
        public void MoveLineTest()
        {
            var p1 = new Point(1, 2);
            var p2 = new Point(5, 6);
            var newP1 = new Point(2, 2);
            var newP2 = new Point(7, 8);

            var line = new Line(p1, p2);

            line.MoveLine(p1, newP1);
            line.MoveLine(p2, newP2);

            Assert.AreEqual(line.StartPoint, newP1);
            Assert.AreEqual(line.EndPoint, newP2);
        }

        [TestMethod]
        public void IsPointContainedTest()
        {
            for (var i = 0; i < this.lines.Count; ++i)
            {
                for (var j = 0; j < this.points[i].Count; ++j)
                {
                    Assert.IsTrue(this.lines[i].IsPointContained(this.points[i][j]));
                }
            }
        }
    }
}