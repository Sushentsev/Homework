namespace Task_1.View
{
    using System.Collections.Generic;
    using System.Drawing;
    using System.Windows.Forms;
    using Task_1.Model;

    /// <summary>
    /// Class for line view.
    /// </summary>
    public class LineView
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
        /// Draws the lines.
        /// </summary>
        /// <param name="lines">List of lines.</param>
        /// <param name="e">Data for painting.</param>
        public void DrawLines(IList<Line> lines, PaintEventArgs e)
        {
            foreach (var line in lines)
            {
                if (line.IsSelected)
                {
                    e.Graphics.DrawLine(this.selectedLinePen, line.StartPoint, line.EndPoint);
                    e.Graphics.DrawEllipse(this.selectedVertexPen, new Rectangle(line.StartPoint.X - 2, line.StartPoint.Y - 2, 3, 3));
                    e.Graphics.DrawEllipse(this.selectedVertexPen, new Rectangle(line.EndPoint.X - 2, line.EndPoint.Y - 2, 3, 3));
                }
                else
                {
                    e.Graphics.DrawLine(this.notSelectedLinePen, line.StartPoint, line.EndPoint);
                }
            }
        }
    }
}