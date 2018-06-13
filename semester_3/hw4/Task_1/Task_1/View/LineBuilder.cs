namespace Task_1.View
{
    using System.Drawing;
    using System.Windows.Forms;
    using Task_1.Model;

    /// <summary>
    /// Line builder class.
    /// </summary>
    public class LineBuilder
    {
        /// <summary>
        /// Pen for line.
        /// </summary>
        private readonly Pen linePen = new Pen(Color.Black, 2);

        /// <summary>
        /// Start point.
        /// </summary>
        private Point startPoint;

        /// <summary>
        /// End point.
        /// </summary>
        private Point endPoint;

        /// <summary>
        /// Sets start point.
        /// </summary>
        /// <param name="startPoint">Start point.</param>
        public void SetStartPoint(Point startPoint) => this.startPoint = startPoint;

        /// <summary>
        /// Sets end point.
        /// </summary>
        /// <param name="endPoint">End point.</param>
        public void SetEndPoint(Point endPoint) => this.endPoint = endPoint;

        /// <summary>
        /// Gets a value whether line is point.
        /// </summary>
        /// <returns>Whether line is point.</returns>
        public bool IsPoint() => this.startPoint == this.endPoint;

        /// <summary>
        /// Clears line builder data.
        /// </summary>
        public void Clear() => this.startPoint = this.endPoint = new Point();

        /// <summary>
        /// Draws a line.
        /// </summary>
        /// <param name="e">Data for painting.</param>
        public void DrawLine(PaintEventArgs e) => e.Graphics.DrawLine(this.linePen, this.startPoint, this.endPoint);

        /// <summary>
        /// Gets new instance of the <see cref="Line"/> class.
        /// </summary>
        /// <returns>Current line.</returns>
        public Line GetLine() => new Line(this.startPoint, this.endPoint);
    }
}
