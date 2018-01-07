namespace Task_1.Controller.Commands
{
    using System;

    /// <summary>
    /// Command for clearing a selection.
    /// </summary>
    public class ClearSelectionCommand : ICommand
    {
        /// <summary>
        /// Command does not have undo.
        /// </summary>
        public bool HasUndo => false;

        /// <summary>
        /// Clears a selection.
        /// </summary>
        /// <param name="model">Model.</param>
        public void Execute(Model.Model model) => model.ClearSelection();

        /// <summary>
        /// Unexecutes a command.
        /// </summary>
        /// <param name="model">Model.</param>
        public void UnExecute(Model.Model model) => throw new NotImplementedException();
    }
}
