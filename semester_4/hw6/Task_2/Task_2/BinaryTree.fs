module BinaryTree
open System.Collections
open System.Collections.Generic

/// <summary>
/// Type for binary tree node.
/// </summary>
type TreeNode<'T> = 
    | TreeNode of 'T * TreeNode<'T> * TreeNode<'T>
    | Empty

/// <summary>
/// Interface for binary tree node.
/// </summary>
type IBinaryTree<'T> =

    /// <summary>
    /// Adds new value to binary tree.
    /// </summary>
    abstract AddValue : 'T -> unit

    /// <summary>
    /// Removes value from tree.
    /// If value is not found, exception will be thrown.
    /// </summary>
    abstract RemoveValue : 'T -> unit

    /// <summary>
    /// Checks whether the value is contained in the tree.
    /// Returns true if the value is contained, otherwise false.
    /// </summary>
    abstract IsContained : 'T -> bool

    /// <summary>
    /// Gets the length of tree.
    /// </summary>
    abstract GetLength : int with get

/// <summary>
/// Binary tree class.
/// Contains all methods for performing basic binary tree functions.
/// </summary>
/// <remarks>
/// Implements <see cref="IBinaryTree{'T}"/> and <see cref="IEnumerable{'T}"/> interfaces.
/// </remarks>
type BinaryTree<'T when 'T : comparison>() =

    let mutable root = Empty
    let mutable length = 0
    let ascendingSeq () = 
        let rec ascendingSeq' (node : TreeNode<'T>) = 
            seq {
                match node with
                | TreeNode(nodeValue, left, right) -> 
                    yield! ascendingSeq' left
                    yield nodeValue
                    yield! ascendingSeq' right
                | Empty -> yield! Seq.empty
            }
        ascendingSeq' root

    interface IBinaryTree<'T> with

        member this.AddValue (value : 'T) =

            let rec addValue (value : 'T) (node : TreeNode<'T>) = 
                match node with
                | Empty -> TreeNode(value, Empty, Empty)     
                | TreeNode(nodeValue, left, right) when value < nodeValue -> TreeNode(nodeValue, addValue value left, right) 
                | TreeNode(nodeValue, left, right) when value > nodeValue -> TreeNode(nodeValue, left, addValue value right)
                | _ -> failwith "The value is already contained in the tree!"

            root <- addValue value root
            length <- length + 1

        member this.RemoveValue (value : 'T) = 

            let rec getMinNode (node : TreeNode<'T>) = 
                match node with
                | Empty -> failwith "The node is empty!"
                | TreeNode(_, leftChild, _) when leftChild = Empty -> node
                | TreeNode(_, leftChild, _) -> getMinNode leftChild

            let rec removeValue (value : 'T) (node : TreeNode<'T>) = 
                match node with 
                | Empty -> failwith "The value is not found!"
                | TreeNode(nodeValue, left, right) when value < nodeValue -> TreeNode(nodeValue, removeValue value left, right) 
                | TreeNode(nodeValue, left, right) when value > nodeValue -> TreeNode(nodeValue, left, removeValue value right)
                | TreeNode(nodeValue, left, right) ->
                    match left, right with
                    | Empty, Empty -> Empty
                    | Empty, TreeNode(_, _, _) -> right
                    | TreeNode(_, _, _), Empty -> left
                    | _ -> 
                        let minNode = getMinNode(right)
                        match minNode with
                        | TreeNode(minNodeValue, _, _) -> TreeNode(minNodeValue, left, removeValue minNodeValue right)
                        | Empty -> failwith "The node is empty!"
          
            root <- removeValue value root
            length <- length - 1

        member this.IsContained (value : 'T) =

            let rec isContained (value : 'T) (node : TreeNode<'T>) = 
                match node with
                | Empty -> false
                | TreeNode(nodeValue, left, right) when value < nodeValue -> isContained value left
                | TreeNode(nodeValue, left, right) when value > nodeValue -> isContained value right
                | _ -> true
            isContained value root

        member this.GetLength
            with get () = length
            
    interface IEnumerable<'T> with

        member this.GetEnumerator(): IEnumerator<'T> =
            ascendingSeq().GetEnumerator()

        member this.GetEnumerator(): IEnumerator =
            ascendingSeq().GetEnumerator() :> IEnumerator