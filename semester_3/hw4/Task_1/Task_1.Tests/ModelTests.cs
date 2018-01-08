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
        private  readonly Random rand = new Random();

        [TestMethod]
        public void AddLineTest()
        {
            const int numberOfLines = 100;
            var lines = new List<Line>();

            for (var i = 0; i < numberOfLines; ++i)
            {
                lines.Add(this.GetRandomLine());
                this.model.AddLine(lines[i]);
            }

            foreach (var line in lines)
            {
                Assert.IsTrue(this.model.LinesList.Contains(line));
            }
        }

        [TestMethod]
        public void RemoveLineTest()
        {
            const int numberOfLines = 100;
            var lines = new List<Line>();

            for (var i = 0; i < numberOfLines; ++i)
            {
                lines.Add(this.GetRandomLine());
                this.model.AddLine(lines[i]);
            }

            for (var i = 0; i < numberOfLines; ++i)
            {
                var index = this.rand.Next(lines.Count);
                var line = lines[index];
                lines.RemoveAt(index);
                this.model.RemoveLine(line);
                Assert.IsFalse(this.model.LinesList.Contains(line));
            }
        }

        [TestMethod]
        public void TryToSelectLineTest()
        {
            // Y = k * X.
            const int numberOfLines = 100;
            const int numberOfPointsForEveryLine = 100;
            var lines = new List<Line>();

            for (var i = 0; i < numberOfLines; ++i)
            {
                lines.Add(this.GetRandomLine());
                this.model.AddLine(lines[i]);
            }

            for (var i = 0; i < numberOfLines; ++i)
            {
                var xDiff = lines[i].EndPoint.X - lines[i].StartPoint.X;
                var yDiff = lines[i].EndPoint.Y - lines[i].StartPoint.Y;
                // Creates radious line.
                var radiousLine = new Line(new Point(0, 0), new Point(xDiff, yDiff));

                for (var j = 0; j < numberOfPointsForEveryLine; ++j)
                {
                    var xPoint = rand.Next(Math.Min(0, xDiff), Math.Max(0, xDiff));
                    // Computes Y coordinate as Y = k * X.
                    var yPoint = (yDiff / xDiff) * xPoint;
                    // Parallel transfer.
                    var point = new Point(xPoint + xDiff, yPoint + yDiff);

                    this.model.TryToSelectLine(point);
                    Assert.IsTrue(this.model.HasSelectedLine);
                    this.model.ClearSelection();
                }
            }
        }

        [TestMethod]
        public void MoveLineTest()
        {
            // Y = k * X.
            const int numberOfLines = 100;
            const int numberOfPointsForEveryLine = 100;
            var lines = new List<Line>();

            for (var i = 0; i < numberOfLines; ++i)
            {
                lines.Add(this.GetRandomLine());
                this.model.AddLine(lines[i]);
            }

            for (var i = 0; i < numberOfLines; ++i)
            {
                var xDiff = lines[i].EndPoint.X - lines[i].StartPoint.X;
                var yDiff = lines[i].EndPoint.Y - lines[i].StartPoint.Y;
                // Creates radious line.
                var radiousLine = new Line(new Point(0, 0), new Point(xDiff, yDiff));

                for (var j = 0; i < numberOfPointsForEveryLine; ++i)
                {
                    var point = this.GetRandomPoint();

                    if (i < 50)
                    {
                        this.model.MoveLine(lines[i], lines[i].StartPoint, point);
                        Assert.AreEqual(point, lines[i].StartPoint);
                    }
                    else
                    {
                        this.model.MoveLine(lines[i], lines[i].EndPoint, point);
                        Assert.AreEqual(point, lines[i].EndPoint);
                    }
                }
            }
        }

        private Point GetRandomPoint() => new Point(this.rand.Next(100), this.rand.Next(100));

        private Line GetRandomLine()
        {
            // Y = k * X.
            var k = this.rand.Next(100);
            var x1 = this.rand.Next(100);
            var x2 = this.rand.Next(100);

            while (x1 == x2)
            {
                x2 = this.rand.Next(100);
            }

            var p1 = new Point(x1, k * x1);
            var p2 = new Point(x2, k * x2);

            return new Line(p1, p2);
        }
    }
}