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
        /// Checks whether point is contained in line.
        /// </summary>
        /// <param name="point">Current point.</param>
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

            var vector1 = new[] { p.X - a.X, p.Y - a.Y };
            var vector2 = new[] { b.X - a.X, b.Y - a.Y };

            var value1 = Math.Pow(vector2[0], 2) + Math.Pow(vector2[1], 2);
            var value2 = (vector1[0] * vector2[0]) + (vector1[1] * vector2[1]);

            var t = value2 / value1;

            var x = a.X + (vector2[0] * t);
            var y = a.Y + (vector2[1] * t);

            return Math.Sqrt(Math.Pow(p.X - x, 2) + Math.Pow(p.Y - y, 2));
        }
    }
}
