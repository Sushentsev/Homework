namespace Task_1.Model
{
    using System;

    /// <summary>
    /// Selection changed arguments class.
    /// </summary>
    public class SelectionChangedArgs : EventArgs
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SelectionChangedArgs"/> class.
        /// </summary>
        /// <param name="isRemoveAvailable">Availability of remove button.</param>
        public SelectionChangedArgs(bool isRemoveAvailable) => this.IsRemoveAvailable = isRemoveAvailable;

        /// <summary>
        /// Gets or sets a value indicating whether remove button is available.
        /// </summary>
        public bool IsRemoveAvailable { get; private set; }
    }
}
