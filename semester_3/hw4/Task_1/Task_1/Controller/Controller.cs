namespace Task_1.Controller
{
    using System;
    using System.Collections.Generic;
    using Task_1.Controller.Commands;
    using Task_1.Model;

    /// <summary>
    /// Controller class.
    /// </summary>
    public class Controller
    {
        /// <summary>
        /// Current model.
        /// </summary>
        private readonly Model model;

        /// <summary>
        /// Stack with undo commands.
        /// </summary>
        private readonly Stack<ICommand> undoCommandStack = new Stack<ICommand>();

        /// <summary>
        /// Stack with redo commands.
        /// </summary>
        private readonly Stack<ICommand> redoCommandStack = new Stack<ICommand>();

        /// <summary>
        /// Initializes a new instance of the <see cref="Controller"/> class.
        /// </summary>
        /// <param name="model">Current model.</param>
        public Controller(Model model) => this.model = model;

        /// <summary>
        /// Event is raised when undo stack is updated.
        /// </summary>
        public event EventHandler<StackChangedArgs> UndoUpdated;

        /// <summary>
        /// Event is raised when redo stack is updated.
        /// </summary>
        public event EventHandler<StackChangedArgs> RedoUpdated;

        /// <summary>
        /// Gets a value indicating whether undo stack is available.
        /// </summary>
        public bool IsUndoAvailable => this.undoCommandStack.Count != 0;

        /// <summary>
        /// Gets a value indicating whether redo stack is available.
        /// </summary>
        public bool IsRedoAvailable => this.redoCommandStack.Count != 0;

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
                this.UndoUpdated?.Invoke(this, new StackChangedArgs(true));
                this.redoCommandStack.Clear();
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
                this.RedoUpdated?.Invoke(this, new StackChangedArgs(true));

                if (!this.IsUndoAvailable)
                {
                    this.UndoUpdated?.Invoke(this, new StackChangedArgs(false));
                }
            }
        }

        /// <summary>
        /// Redo a command.
        /// </summary>
        public void Redo()
        {
            if (this.IsRedoAvailable)
            {
                var command = this.redoCommandStack.Pop();
                command.Execute(this.model);
                this.undoCommandStack.Push(command);
                this.UndoUpdated?.Invoke(this, new StackChangedArgs(true));

                if (!this.IsRedoAvailable)
                {
                    this.RedoUpdated?.Invoke(this, new StackChangedArgs(false));
                }
            }            
        }
    }
}
