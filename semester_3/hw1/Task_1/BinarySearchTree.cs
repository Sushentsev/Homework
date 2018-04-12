using System;
using System.Collections;
using System.Collections.Generic;

namespace Task_1
{
    /// <summary>
    /// Binary search tree on generics
    /// </summary>
    /// <typeparam name="T">Value type</typeparam>
    public class BinarySearchTree<T> : IEnumerable<T> where T : IComparable
    {
        /// <summary>
        /// The node of a tree
        /// </summary>
        private class TreeNode
        {
            /// <summary>
            /// Node left child
            /// </summary>
            public TreeNode LeftChild;

            /// <summary>
            /// Node right child
            /// </summary>
            public TreeNode RightChild;

            /// <summary>
            /// Node value
            /// </summary>
            public T Value;

            /// <summary>
            /// Constructor for tree node
            /// </summary>
            /// <param name="leftChild">Node left child</param>
            /// <param name="rightChild">Node right child</param>
            /// <param name="value">Node value</param>
            public TreeNode(TreeNode leftChild, TreeNode rightChild, T value)
            {
                this.LeftChild = leftChild;
                this.RightChild = rightChild;
                this.Value = value;
            }
        }

        /// <summary>
        /// The root of a tree
        /// </summary>
        private TreeNode root;

        /// <summary>
        /// Adding new value to a binary tree
        /// </summary>
        /// <param name="value">Value for adding</param>
        public void AddValue(T value) => AddValue(ref root, value);

        /// <summary>
        /// Adding new value to a binary tree
        /// </summary>
        /// <param name="currentNode">Current node</param>
        /// <param name="value">Value for adding</param>
        private void AddValue(ref TreeNode currentNode, T value)
        {
            if (currentNode == null)
            {
                currentNode = new TreeNode(null, null, value);
                return;
            }

            switch (value.CompareTo(currentNode.Value))
            {
                case 0:
                    throw new AddContainedValueException("The value has already belonged to tree!");
                case 1:
                    AddValue(ref currentNode.RightChild, value);
                    break;
                case -1:
                    AddValue(ref currentNode.LeftChild, value);
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Checking value on containing
        /// </summary>
        /// <param name="value">Value for checking</param>
        /// <returns>True if value contains, false otherwise</returns>
        public bool IsContained(T value) => IsContained(root, value);

        /// <summary>
        /// Checking value on containing
        /// </summary>
        /// <param name="currentNode">Current node</param>
        /// <param name="value">Value for adding</param>
        private bool IsContained(TreeNode currentNode, T value)
        {
            if (currentNode == null)
            {
                return false;
            }

            switch (value.CompareTo(currentNode.Value))
            {
                case 0:
                    return true;
                case 1:
                    return IsContained(currentNode.RightChild, value);
                case -1:
                    return IsContained(currentNode.LeftChild, value);
                default:
                    return false; 
            }  
        }

        /// <summary>
        /// Removing value from binary tree
        /// </summary>
        /// <param name="value">Value for removing</param>
        public void RemoveValue(T value) => RemoveValue(ref root, value);

        /// <summary>
        /// Removing value from binary tree
        /// </summary>
        /// <param name="currentNode">Current node</param>
        /// <param name="value">Value for removing</param>
        private void RemoveValue(ref TreeNode currentNode, T value)
        {
            if (currentNode == null)
            {
                throw new NotExistedValueException("The value does not exist in the tree!");
            }

            switch (value.CompareTo(currentNode.Value))
            {
                case 0:
                    RemoveCurrentNode(ref currentNode, value);
                    break;
                case 1:
                    RemoveValue(ref currentNode.RightChild, value);
                    break;
                case -1:
                    RemoveValue(ref currentNode.LeftChild, value);
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Removing current node
        /// </summary>
        /// <param name="currentNode">Current node</param>
        /// <param name="value">Value for removing</param>
        private void RemoveCurrentNode(ref TreeNode currentNode, T value)
        {
            if (currentNode.LeftChild == null && currentNode.RightChild == null)
            {
                currentNode = null;
                return;
            }

            if (currentNode.LeftChild != null && currentNode.RightChild != null)
            {
                var minNode = FindMinNode(currentNode);
                currentNode.Value = minNode.Value;
                RemoveValue(ref minNode, value);
                return;
            }

            if (currentNode.LeftChild != null)
            {
                currentNode = currentNode.LeftChild;
                return;
            }

            if (currentNode.RightChild != null)
            {
                currentNode = currentNode.RightChild;
                return;
            }
        }

        /// <summary>
        /// Finding minimal node
        /// </summary>
        /// <param name="currentNode"></param>
        /// <returns>Minimal node</returns>
        private TreeNode FindMinNode(TreeNode currentNode)
        {
            currentNode = currentNode.RightChild;

            while (currentNode.LeftChild != null)
            {
                currentNode = currentNode.LeftChild;
            }

            return currentNode;
        }

        /// <summary>
        /// Getting tree enumerator
        /// </summary>
        /// <returns>Enumerator</returns>
        public IEnumerator<T> GetEnumerator() => new TreeEnumerator(root);

        /// <summary>
        /// Getting tree enumerator
        /// </summary>
        /// <returns>Enumerator</returns>
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        /// <summary>
        /// Tree Enumerator
        /// </summary>
        private class TreeEnumerator : IEnumerator<T>
        {
            /// <summary>
            /// Tree root
            /// </summary>
            private TreeNode root;

            /// <summary>
            /// Stack of tree nodes
            /// </summary>
            private Stack<TreeNode> stackNode = new Stack<TreeNode>();

            /// <summary>
            /// Collection is just started
            /// </summary>
            private bool isFirst = true;

            /// <summary>
            /// Constructor for tree enumerator
            /// </summary>
            /// <param name="root"></param>
            public TreeEnumerator(TreeNode root) => this.root = root;

            /// <summary>
            /// Getting value from current tree node
            /// </summary>
            public T Current => stackNode.Peek().Value;

            /// <summary>
            /// Getting current element
            /// </summary>
            object IEnumerator.Current => Current;

            public void Dispose()
            {

            }

            /// <summary>
            /// Moving to next node
            /// </summary>
            /// <returns></returns>
            public bool MoveNext()
            {
                if (isFirst)
                {
                    isFirst = false;
                    stackNode.Push(root);
                    return root != null;
                }

                var poppedNode = stackNode.Pop();

                if (poppedNode.LeftChild != null)
                {
                    stackNode.Push(poppedNode.LeftChild);
                }

                if (poppedNode.RightChild != null)
                {
                    stackNode.Push(poppedNode.RightChild);
                }

                return !stackNode.IsEmpty();
            }

            /// <summary>
            /// Resetting the tree enumerator 
            /// </summary>
            public void Reset()
            {
                stackNode = null;
                isFirst = true;
            }
        }
    }
}
