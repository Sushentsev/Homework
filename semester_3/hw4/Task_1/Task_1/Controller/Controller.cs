namespace Task_1.Controller
{
    using System.Collections.Generic;
    using Task_1.Controller.Commands;
    using Task_1.Model;

    /// <summary>
    /// Controller class.
    /// </summary>
    public class Controller
    {
        /// <summary>
        /// Model.
        /// </summary>
        private readonly Model model;

        /// <summary>
        /// Stack with undo commands.
        /// </summary>
        private Stack<ICommand> undoCommandStack = new Stack<ICommand>();

        /// <summary>
        /// Stack with redo commands.
        /// </summary>
        private Stack<ICommand> redoCommandStack = new Stack<ICommand>();

        /// <summary>
        /// Initializes a new instance of the <see cref="Controller"/> class.
        /// </summary>
        /// <param name="model">Model.</param>
        public Controller(Model model) => this.model = model;

        /// <summary>
        /// Gets a value indicating whether undo stack is available.
        /// </summary>
        public bool IsUndoAvailable { get => this.undoCommandStack.Count != 0; }

        /// <summary>
        /// Gets a value indicating whether redo stack is available.
        /// </summary>
        public bool IsRedoAvailavle { get => this.redoCommandStack.Count != 0; }

        /// <summary>
        /// Handles a command.
        /// </summary>
        /// <param name="command">Command for handling.</param>
        public void HandleCommand(ICommand command)
        {
            command.Execute(this.model);

            if (command.HasUndo)
            {
                this.undoCommandStack.Push(command);
            }
        }

        /// <summary>
        /// Undo a command.
        /// </summary>
        public void Undo()
        {
            if (this.IsUndoAvailable)
            {
                var command = this.undoCommandStack.Pop();
                command.UnExecute(this.model);
                this.redoCommandStack.Push(command);
            }        
        }

        /// <summary>
        /// Redo a command.
        /// </summary>
        public void Redo()
        {
            if (this.IsRedoAvailavle)
            {
                var command = this.redoCommandStack.Pop();
                command.Execute(this.model);
                this.undoCommandStack.Push(command);
            }            
        }
    }
}
