namespace Task_1.Model
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;

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
        ///  Event is raised when selected line is updated.
        /// </summary>
        public event EventHandler<SelectionChangedArgs> SelectionChanged;

        /// <summary>
        /// Gets the list of lines.
        /// </summary>
        public IList<Line> LinesList { get; }

        /// <summary>
        /// Gets a selected line.
        /// </summary>
        public Line SelectedLine { get; private set; }

        /// <summary>
        /// Gets a value indicating whether model has selected line.
        /// </summary>
        public bool HasSelectedLine => this.SelectedLine != null;

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
        public void RemoveLine(Line line)
        {
            this.ClearSelection();
            this.LinesList.Remove(line);
        }

        /// <summary>
        /// Tries to select a line.
        /// </summary>
        /// <param name="point">Current point.</param>
        public void TryToSelectLine(Point point)
        {
            this.ClearSelection();

            foreach (var line in this.LinesList)
            {
                if (line.IsPointContained(point))
                {
                    this.SelectedLine = line;
                    this.SelectedLine.IsSelected = true;
                    this.SelectionChanged?.Invoke(this, new SelectionChangedArgs(true));
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
                this.SelectionChanged?.Invoke(this, new SelectionChangedArgs(false));
            }     
        }

        /// <summary>
        /// Moves line.
        /// </summary>
        /// <param name="movingLine">Line for moving.</param>
        /// <param name="oldPoint">Old vertex.</param>
        /// <param name="newPoint">New vertex.</param>
        public void MoveLine(Line movingLine, Point oldPoint, Point newPoint) => movingLine.MoveLine(oldPoint, newPoint);
    }
}
