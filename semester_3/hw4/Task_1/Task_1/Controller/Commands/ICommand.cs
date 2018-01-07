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
        /// <param name="model">Model.</param>
        void Execute(Model model);

        /// <summary>
        /// Unexecutes a command.
        /// </summary>
        /// <param name="model">Model.</param>
        void UnExecute(Model model);
    }
}
