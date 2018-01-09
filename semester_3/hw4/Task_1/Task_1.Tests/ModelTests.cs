namespace Task_1.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Task_1.Model;

    /// <summary>
    /// Tests for <see cref="Model"/> class.
    /// </summary>
    [TestClass]
    public class ModelTests
    {
        private readonly Model model = new Model();
        private IList<Line> lines;
        private IList<IList<Point>> points;

        [TestInitialize]
        public void Initialize()
        {
            var data = new DataClass("lines.txt", "points.txt");
            this.lines = data.Lines;
            this.points = data.Points;

            for (var i = 0; i < this.lines.Count; ++i)
            {
                this.model.AddLine(this.lines[i]);
            }
        }

        [TestMethod]
        public void AddLineTest()
        {
            foreach (var line in this.lines)
            {
                Assert.IsTrue(this.model.LinesList.Contains(line));
            }
        }

        [TestMethod]
        public void RemoveLineTest()
        {
            for (var i = 0; i < this.lines.Count; ++i)
            {
                this.model.RemoveLine(this.lines[i]);
                Assert.IsFalse(this.model.LinesList.Contains(this.lines[i]));
            }
        }

        [TestMethod]
        public void TryToSelectLineTest()
        {
            for (var i = 0; i < this.lines.Count; ++i)
            {
                for (var j = 0; j < this.points[i].Count; ++j)
                {
                    this.model.TryToSelectLine(this.points[i][j]);
                    Assert.IsTrue(this.model.HasSelectedLine);
                    this.model.ClearSelection();
                }
            }
        }

        [TestMethod]
        public void MoveLineTest()
        {
            var p1 = new Point(1, 2);
            var p2 = new Point(5, 6);
            var newP1 = new Point(2, 2);
            var newP2 = new Point(7, 8);

            var line = new Line(p1, p2);

            this.model.MoveLine(line, p1, newP1);
            this.model.MoveLine(line, p2, newP2);

            Assert.AreEqual(line.StartPoint, newP1);
            Assert.AreEqual(line.EndPoint, newP2);
        }
    }
}