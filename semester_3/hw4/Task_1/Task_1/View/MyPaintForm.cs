namespace Task_1
{
    using System;
    using System.Drawing;
    using System.Windows.Forms;
    using Task_1.Controller.Commands;
    using Task_1.View;

    /// <summary>
    /// MyPaintForm class.
    /// </summary>
    public partial class MyPaintForm : Form
    {
        /// <summary>
        /// Model field.
        /// </summary>
        private readonly Model.Model model;

        /// <summary>
        /// Controller field.
        /// </summary>
        private readonly Controller.Controller controller;

        /// <summary>
        /// Line builder field.
        /// </summary>
        private readonly LineBuilder lineBuilder;

        /// <summary>
        /// Gets a value indicating whether user is drawing.
        /// </summary>
        private bool isDrawing;

        /// <summary>
        /// Old point of moving line.
        /// </summary>
        private Point oldPoint;

        public MyPaintForm()
        {
            this.InitializeComponent();
            this.model = new Model.Model();
            this.controller = new Controller.Controller(this.model);
            this.lineBuilder = new LineBuilder();
        }

        private void OnUndoButton_Click(object sender, EventArgs e)
        {
            this.controller.Undo();
            this.DrawingArea.Invalidate();
        }

        private void OnRedoButton_Click(object sender, EventArgs e)
        {
            this.controller.Redo();
            this.DrawingArea.Invalidate();
        }

        private void OnRemoveButton_Click(object sender, EventArgs e)
        {
            if (this.model.HasSelectedLine)
            {
                this.controller.HandleCommand(new RemoveLineCommand(this.model.SelectedLine));
                this.DrawingArea.Invalidate();
            }
        }

        private void OnDrawingArea_MouseDown(object sender, MouseEventArgs e)
        {
            if (this.DrawRadioButton.Checked)
            {
                this.isDrawing = true;
                this.lineBuilder.SetStartPoint(new Point(e.X, e.Y));
            }

            if (this.SelectRadioButton.Checked)
            {
                if (this.model.HasSelectedLine)
                {
                    var selectedLine = this.model.SelectedLine;
                    var currentPoint = new Point(e.X, e.Y);

                    if (this.GetDistance(selectedLine.StartPoint, currentPoint).CompareTo(3) <= 0)
                    {
                        this.isDrawing = true;
                        this.oldPoint = selectedLine.StartPoint;
                        this.lineBuilder.SetStartPoint(selectedLine.EndPoint);
                    }
                    else if (this.GetDistance(selectedLine.EndPoint, currentPoint).CompareTo(3) <= 0)
                    {
                        this.isDrawing = true;
                        this.oldPoint = selectedLine.EndPoint;
                        this.lineBuilder.SetStartPoint(selectedLine.StartPoint);
                    }
                    else
                    {
                        this.controller.HandleCommand(new SelectLineCommand(new Point(e.X, e.Y)));
                        this.DrawingArea.Invalidate();
                    }
                }
                else
                {
                    this.controller.HandleCommand(new SelectLineCommand(new Point(e.X, e.Y)));
                    this.DrawingArea.Invalidate();
                }         
            }
        }

        private void OnDrawingArea_MouseMove(object sender, MouseEventArgs e)
        {
            if (this.isDrawing)
            {
                this.lineBuilder.SetEndPoint(new Point(e.X, e.Y));
                this.DrawingArea.Invalidate();
            }
        }

        private void OnDrawingArea_MouseUp(object sender, MouseEventArgs e)
        {
            if (this.isDrawing)
            {
                if (this.DrawRadioButton.Checked)
                {
                    this.lineBuilder.SetEndPoint(new Point(e.X, e.Y));

                    if (!this.lineBuilder.IsPoint())
                    {
                        this.controller.HandleCommand(new AddLineCommand(this.lineBuilder.GetLine()));

                    }
                }

                if (this.SelectRadioButton.Checked)
                {
                    var newPoint = new Point(e.X, e.Y);
                    this.controller.HandleCommand(new MoveLineCommand(this.model.SelectedLine, this.oldPoint, newPoint));
                }

                this.isDrawing = false;
                this.DrawingArea.Invalidate();
                this.lineBuilder.Clear();
            }
        }

        private void OnDrawingArea_Paint(object sender, PaintEventArgs e)
        {
            if (this.isDrawing)
            {
                this.lineBuilder.DrawLine(e);
            }

            this.controller.HandleCommand(new DrawLinesCommand(e));
        }

        private void DrawRadioButton_Click(object sender, EventArgs e)
        {
            this.controller.HandleCommand(new ClearSelectionCommand());
            this.DrawingArea.Invalidate();
        }

        /// <summary>
        /// Calculates a distance between two points.
        /// </summary>
        /// <param name="p1">First point.</param>
        /// <param name="p2">Second point.</param>
        /// <returns>Distance.</returns>
        private double GetDistance(Point p1, Point p2) => Math.Sqrt(Math.Pow(p1.X - p2.X, 2) + Math.Pow(p1.Y - p2.Y, 2));
    }
}
