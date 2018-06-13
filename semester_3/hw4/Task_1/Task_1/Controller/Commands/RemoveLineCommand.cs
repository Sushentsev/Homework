namespace Task_1.Controller.Commands
{
    using Task_1.Model;

    /// <summary>
    /// Command for removing a line.
    /// </summary>
    public class RemoveLineCommand : ICommand
    {
        /// <summary>
        /// Line for removing.
        /// </summary>
        private readonly Line line;

        /// <summary>
        /// Initializes a new instance of the <see cref="RemoveLineCommand"/> class.
        /// </summary>
        /// <param name="line">Line for removing.</param>
        public RemoveLineCommand(Line line) => this.line = line;

        /// <summary>
        /// Command has undo.
        /// </summary>
        public bool HasUndo => true;

        /// <summary>
        /// Removes a line.
        /// </summary>
        /// <param name="model">Current model.</param>
        public void Execute(Model model) => model.RemoveLine(this.line);

        /// <summary>
        /// Adds new line.
        /// </summary>
        /// <param name="model">Current model.</param>
        public void UnExecute(Model model) => model.AddLine(this.line);
    }
}
