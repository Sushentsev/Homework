namespace Task_1.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Task_1.Controller;
    using Task_1.Controller.Commands;
    using Task_1.Model;

    /// <summary>
    /// Tests for <see cref="Controller"/> class.
    /// </summary>
    [TestClass]
    public class ControllerTests
    {
        static private readonly Model Model = new Model();
        private readonly Random rand = new Random();
        private readonly Controller controller = new Controller(Model);

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
                this.controller.HandleCommand(new AddLineCommand(this.lines[i]));
            }
        }

        [TestMethod]
        public void AddLineCommandTest()
        {
            foreach (var line in this.lines)
            {
                Assert.IsTrue(Model.LinesList.Contains(line));
            }
        }

        [TestMethod]
        public void RemoveLineCommandTest()
        {
            for (var i = 0; i < this.lines.Count; ++i)
            {
                this.controller.HandleCommand(new RemoveLineCommand(this.lines[i]));
                Assert.IsFalse(Model.LinesList.Contains(this.lines[i]));
            }
        }

        [TestMethod]
        public void SelectLineCommand()
        {
            for (var i = 0; i < this.lines.Count; ++i)
            {
                for (var j = 0; j < this.points[i].Count; ++j)
                {
                    this.controller.HandleCommand(new SelectLineCommand(this.points[i][j]));
                    Assert.IsTrue(Model.HasSelectedLine);
                    Model.ClearSelection();
                }
            }
        }

        [TestMethod]
        public void MoveLineCommandTest()
        {
            var p1 = new Point(1, 2);
            var p2 = new Point(5, 6);
            var newP1 = new Point(2, 2);
            var newP2 = new Point(7, 8);

            var line = new Line(p1, p2);

            this.controller.HandleCommand(new MoveLineCommand(line, p1, newP1));
            this.controller.HandleCommand(new MoveLineCommand(line, p2, newP2));

            Assert.AreEqual(line.StartPoint, newP1);
            Assert.AreEqual(line.EndPoint, newP2);
        }

        [TestMethod]
        public void UndoTests()
        {
            Assert.IsTrue(this.controller.IsUndoAvailable);

            for (var i = 0; i < this.lines.Count; ++i)
            {
                this.controller.Undo();

                for (var j = this.lines.Count - 1 - i; j < this.lines.Count; ++j)
                {
                    Assert.IsFalse(Model.LinesList.Contains(this.lines[j]));
                }
            }
        }

        [TestMethod]
        public void RedoTest()
        {
            Assert.IsFalse(this.controller.IsRedoAvailable);

            for (var i = 0; i < this.lines.Count; ++i)
            {
                this.controller.Undo();
            }

            Assert.IsTrue(this.controller.IsRedoAvailable);

            for (var i = 0; i < this.lines.Count; ++i)
            {
                this.controller.Redo();

                for (var j = 0; j <= i; ++j)
                {
                    Assert.IsTrue(Model.LinesList.Contains(this.lines[j]));
                }
            }
        }
    }
}
