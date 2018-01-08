namespace Task_1.Tests
{
    using System;
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

        [TestMethod]
        public void MoveLineTest()
        {
            const int numberOfPoint = 100;

            var line = this.GetRandomLine();

            for (var i = 0; i < numberOfPoint; ++i)
            {
                var point = this.GetRandomPoint();

                if (i < 50)
                {
                    line.MoveLine(line.StartPoint, point);
                    Assert.AreEqual(point, line.StartPoint);
                }
                else
                {
                    line.MoveLine(line.EndPoint, point);
                    Assert.AreEqual(point, line.EndPoint);
                }
            }
        }

        [TestMethod]
        public void IsPointContainedTest()
        {
            const int numberOfPoints = 100;

            var line = this.GetRandomLine();
            var xDiff = line.EndPoint.X - line.StartPoint.X;
            var yDiff = line.EndPoint.Y - line.StartPoint.Y;
            // Creates radious line.
            var radiousLine = new Line(new Point(0, 0), new Point(xDiff, yDiff));

            for (var j = 0; j <= numberOfPoints; ++j)
            {
                var xPoint = rand.Next(Math.Min(0, xDiff), Math.Max(0, xDiff));
                // Computes Y coordinate as Y = k * X.
                var yPoint = (yDiff / xDiff) * xPoint;
                // Parallel transfer.
                var point = new Point(xPoint + xDiff, yPoint + yDiff);

                Assert.IsTrue(line.IsPointContained(point));
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