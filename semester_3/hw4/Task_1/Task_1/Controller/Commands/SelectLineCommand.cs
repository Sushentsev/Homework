namespace Task_1.Controller.Commands
{
    using System;
    using System.Drawing;

    /// <summary>
    /// Command for selecting a line.
    /// </summary>
    public class SelectLineCommand : ICommand
    {
        /// <summary>
        /// Point which can belong to line.
        /// </summary>
        private readonly Point point;

        /// <summary>
        /// Initializes a new instance of the <see cref="SelectLineCommand"/> class.
        /// </summary>
        /// <param name="point">Point.</param>
        public SelectLineCommand(Point point) => this.point = point;

        /// <summary>
        /// Command does not have undo.
        /// </summary>
        public bool HasUndo => false;

        /// <summary>
        /// Tries to select a line.
        /// </summary>
        /// <param name="model">Model.</param>
        public void Execute(Model.Model model) => model.TryToSelectLine(this.point);

        /// <summary>
        /// Unexecutes a command.
        /// </summary>
        /// <param name="model">Model.</param>
        public void UnExecute(Model.Model model) => throw new NotImplementedException();
    }
}
