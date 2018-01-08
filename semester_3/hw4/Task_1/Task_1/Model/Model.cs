namespace Task_1.Model
{
    using System.Collections.Generic;
    using System.Drawing;
    using System.Windows.Forms;

    /// <summary>
    /// Model class.
    /// </summary>
    public class Model
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Model"/> class.
        /// </summary>
        public Model() => this.LinesList = new List<Line>();

        /// <summary>
        /// List of lines.
        /// </summary>
        public List<Line> LinesList { get; private set; }

        /// <summary>
        /// Gets a selected line.
        /// </summary>
        public Line SelectedLine { get; private set; }

        /// <summary>
        /// Gets a value indicating whether model has selected line.
        /// </summary>
        public bool HasSelectedLine { get => this.SelectedLine != null; }

        /// <summary>
        /// Adds new line to list.
        /// </summary>
        /// <param name="line">Line for adding.</param>
        public void AddLine(Line line)
        {
            this.ClearSelection();
            this.LinesList.Add(line);
        }

        /// <summary>
        /// Removes line from list.
        /// </summary>
        /// <param name="line">Line for removing.</param>
        public void RemoveLine(Line line) => this.LinesList.Remove(line);

        /// <summary>
        /// Tries to select a line.
        /// </summary>
        /// <param name="point">Point.</param>
        public void TryToSelectLine(Point point)
        {
            this.ClearSelection();

            foreach (var line in this.LinesList)
            {
                if (line.IsPointContained(point))
                {
                    this.SelectedLine = line;
                    this.SelectedLine.IsSelected = true;
                    return;
                }
            }
        }

        /// <summary>
        /// Clears a selection.
        /// </summary>
        public void ClearSelection()
        {
            if (this.SelectedLine != null)
            {
                this.SelectedLine.IsSelected = false;
                this.SelectedLine = null;
            }     
        }

        /// <summary>
        /// Moves line.
        /// </summary>
        /// <param name="movingLine">Line for moving.</param>
        /// <param name="oldPoint">Old vertex.</param>
        /// <param name="newPoint">New vertex.</param>
        public void MoveLine(Line movingLine, Point oldPoint, Point newPoint) => movingLine.MoveLine(oldPoint, newPoint);

        /// <summary>
        /// Draws all lines.
        /// </summary>
        /// <param name="e">Data for painting.</param>
        public void DrawLines(PaintEventArgs e)
        {
            foreach (var line in this.LinesList)
            {
                line.Draw(e);
            }
        }
    }
}
