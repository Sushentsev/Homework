namespace Task_1.Model
{
    using System;
    using System.Drawing;
    using System.Windows.Forms;

    /// <summary>
    /// CLass Line.
    /// </summary>
    public class Line
    {
        /// <summary>
        /// Pen for not selected line.
        /// </summary>
        private readonly Pen notSelectedLinePen = new Pen(Color.Black, 2);

        /// <summary>
        /// Pen for selected line.
        /// </summary>
        private readonly Pen selectedLinePen = new Pen(Color.Red, 2);

        /// <summary>
        /// Pen for selected vertex.
        /// </summary>
        private readonly Pen selectedVertexPen = new Pen(Color.Black, 3);

        /// <summary>
        /// Initializes a new instance of the <see cref="Line"/> class.
        /// </summary>
        /// <param name="startPoint">Start point.</param>
        /// <param name="endPoint">End point.</param>
        public Line(Point startPoint, Point endPoint)
        {
            this.StartPoint = startPoint;
            this.EndPoint = endPoint;
        }

        /// <summary>
        /// Gets a start point.
        /// </summary>
        public Point StartPoint { get; private set; }

        /// <summary>
        /// Gets an end point.
        /// </summary>
        public Point EndPoint { get; private set; }

        /// <summary>
        /// Gets or sets a value indicating whether line is selected.
        /// </summary>
        public bool IsSelected { get; set; }

        /// <summary>
        /// Moves necessary vertex.
        /// </summary>
        /// <param name="oldPoint">Old vertex.</param>
        /// <param name="newPoint">New vertex.</param>
        public void MoveLine(Point oldPoint, Point newPoint)
        {
            if (Point.Equals(oldPoint, this.StartPoint))
            {
                this.StartPoint = newPoint;
            }
            else
            {
                this.EndPoint = newPoint;
            }
        }

        /// <summary>
        /// Draws a line.
        /// </summary>
        /// <param name="e">Data for painting.</param>
        public void Draw(PaintEventArgs e)
        {
            if (this.IsSelected)
            {
                e.Graphics.DrawLine(this.selectedLinePen, this.StartPoint, this.EndPoint);
                e.Graphics.DrawEllipse(this.selectedVertexPen, new Rectangle(this.StartPoint.X - 2, this.StartPoint.Y - 2, 3, 3));
                e.Graphics.DrawEllipse(this.selectedVertexPen, new Rectangle(this.EndPoint.X - 2, this.EndPoint.Y - 2, 3, 3));
            }
            else
            {
                e.Graphics.DrawLine(this.notSelectedLinePen, this.StartPoint, this.EndPoint);
            }
        }

        /// <summary>
        /// Checks whether point is contained in line.
        /// </summary>
        /// <param name="point">Point.</param>
        /// <returns>Whether point is contained.</returns>
        public bool IsPointContained(Point point) => this.GetDistance(point).CompareTo(7) <= 0;

        /// <summary>
        /// Calculates the distance from point to line.
        /// </summary>
        /// <param name="point">Necessary point.</param>
        /// <returns>Distance from point to line.</returns>
        private double GetDistance(Point point)
        {
            var a = this.StartPoint;
            var b = this.EndPoint;
            var p = point;

            var vector1 = new int[] { p.X - a.X, p.Y - a.Y };
            var vector2 = new int[] { b.X - a.X, b.Y - a.Y };

            var value1 = Math.Pow(vector2[0], 2) + Math.Pow(vector2[1], 2);
            var value2 = (vector1[0] * vector2[0]) + (vector1[1] * vector2[1]);

            var t = value2 / value1;

            var x = a.X + (vector2[0] * t);
            var y = a.Y + (vector2[1] * t);

            return Math.Sqrt(Math.Pow(p.X - x, 2) + Math.Pow(p.Y - y, 2));
        }
    }
}
