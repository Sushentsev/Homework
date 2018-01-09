namespace Task_1.Controller.Commands
{
    using System.Drawing;
    using Task_1.Model;

    /// <summary>
    /// Command for moving a line.
    /// </summary>
    public class MoveLineCommand : ICommand
    {
        /// <summary>
        /// Line for moving.
        /// </summary>
        private readonly Line movingLine;

        /// <summary>
        /// Old vertex.
        /// </summary>
        private readonly Point oldPoint;

        /// <summary>
        /// New vertex.
        /// </summary>
        private readonly Point newPoint;

        /// <summary>
        /// Initializes a new instance of the <see cref="MoveLineCommand"/> class.
        /// </summary>
        /// <param name="movingLine">Line for moving.</param>
        /// <param name="oldPoint">Old vertex.</param>
        /// <param name="newPoint">New vertex.</param>
        public MoveLineCommand(Line movingLine, Point oldPoint, Point newPoint)
        {
            this.movingLine = movingLine;
            this.oldPoint = oldPoint;
            this.newPoint = newPoint;
        }
        
        /// <summary>
        /// Command has undo.
        /// </summary>
        public bool HasUndo => true;

        /// <summary>
        /// Moves a line.
        /// </summary>
        /// <param name="model">Current model.</param>
        public void Execute(Model model) => model.MoveLine(this.movingLine, this.oldPoint, this.newPoint);

        /// <summary>
        /// Moves a line.
        /// </summary>
        /// <param name="model">Current model.</param>
        public void UnExecute(Model model) => model.MoveLine(this.movingLine, this.newPoint, this.oldPoint);
    }
}
