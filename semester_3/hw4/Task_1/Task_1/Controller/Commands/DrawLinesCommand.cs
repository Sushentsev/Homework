namespace Task_1.Controller.Commands
{
    using System;
    using System.Windows.Forms;

    /// <summary>
    /// Command for drawing lines.
    /// </summary>
    public class DrawLinesCommand : ICommand
    {
        /// <summary>
        /// Data for drawing.
        /// </summary>
        private readonly PaintEventArgs e;

        /// <summary>
        /// Initializes a new instance of the <see cref="DrawLinesCommand"/> class.
        /// </summary>
        /// <param name="e">Data for painting.</param>
        public DrawLinesCommand(PaintEventArgs e) => this.e = e;

        /// <summary>
        /// Command does not have undo.
        /// </summary>
        public bool HasUndo => false;

        /// <summary>
        /// Draws a line.
        /// </summary>
        /// <param name="model">Model.</param>
        public void Execute(Model.Model model) => model.DrawLines(this.e);

        /// <summary>
        /// Unexecutes a command.
        /// </summary>
        /// <param name="model">Model.</param>
        public void UnExecute(Model.Model model) => throw new NotImplementedException();
    }
}
