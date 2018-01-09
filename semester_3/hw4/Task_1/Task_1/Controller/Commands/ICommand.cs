namespace Task_1.Controller.Commands
{
    using Task_1.Model;

    /// <summary>
    /// Interface for command.
    /// </summary>
    public interface ICommand
    {
        /// <summary>
        /// Gets a value indicating whether command has undo.
        /// </summary>
        bool HasUndo { get; }

        /// <summary>
        /// Executes a command.
        /// </summary>
        /// <param name="model">Current model.</param>
        void Execute(Model model);

        /// <summary>
        /// Unexecutes a command.
        /// If HasUndo returns false, throw NotImplementedException.
        /// </summary>
        /// <param name="model">Current model.</param>
        void UnExecute(Model model);
    }
}
