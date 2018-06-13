namespace Task_1.Controller.Commands
{
    using Task_1.Model;

    /// <summary>
    /// Command for adding new line.
    /// </summary>
    public class AddLineCommand : ICommand
    {
        /// <summary>
        /// Line for adding.
        /// </summary>
        private readonly Line line;

        /// <summary>
        /// Initializes a new instance of the <see cref="AddLineCommand"/> class.
        /// </summary>
        /// <param name="line">Line for adding.</param>
        public AddLineCommand(Line line) => this.line = line;

        /// <summary>
        /// Command has undo.
        /// </summary>
        public bool HasUndo => true;

        /// <summary>
        /// Adds new line.
        /// </summary>
        /// <param name="model">Current model.</param>
        public void Execute(Model model) => model.AddLine(this.line);

        /// <summary>
        /// Removes a line.
        /// </summary>
        /// <param name="model">Current model.</param>
        public void UnExecute(Model model) => model.RemoveLine(this.line);
    }
}
