namespace Task_1.Controller
{
    using System;

    /// <summary>
    /// Stack changed arguments class.
    /// </summary>
    public class StackChangedArgs : EventArgs
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="StackChangedArgs"/> class.
        /// </summary>
        /// <param name="isStackAvailable">Availability of stack.</param>
        public StackChangedArgs(bool isStackAvailable) => this.IsStackAvailable = isStackAvailable;

        /// <summary>
        /// Gets or sets a value indicating whether stack is available.
        /// </summary>
        public bool IsStackAvailable { get; private set; }
    }
}
