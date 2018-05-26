open NUnit.Framework
open FsUnit
open BinaryTree

module Tests = 
    
    let mutable tree = new BinaryTree<int>()

    //// <summary>
    /// Sets up a tree.
    /// </summary>
    [<SetUp>]
    let ``SetUp`` () = 
        tree <- new BinaryTree<int>()
        (tree :> IBinaryTree<int>).AddValue(6);
        (tree :> IBinaryTree<int>).AddValue(3);
        (tree :> IBinaryTree<int>).AddValue(8);
        (tree :> IBinaryTree<int>).AddValue(2);
        (tree :> IBinaryTree<int>).AddValue(4);
        (tree :> IBinaryTree<int>).AddValue(1);
        (tree :> IBinaryTree<int>).AddValue(5);
        (tree :> IBinaryTree<int>).AddValue(7);
        (tree :> IBinaryTree<int>).AddValue(10);
        (tree :> IBinaryTree<int>).AddValue(9);

    //// <summary>
    /// Simple enumerator test.
    /// </summary>
    [<Test>]
    let ``Enumerator test`` () =
        let expected = [| for i in 1..10 -> i |]
        let actual = [| for i in tree -> i |]
        actual |> should equal expected
    
    //// <summary>
    /// Simple IsContained test.
    /// </summary>
    [<Test>]
    let ``IsContained test`` () =
        for i in 1..10 do
            (tree :> IBinaryTree<int>).IsContained i |> should equal true
        (tree :> IBinaryTree<int>).GetLength |> should equal 10

    //// <summary>
    /// Simple remove existed values test.
    /// </summary>
    [<Test>]
    let ``Simple remove existed values test`` () = 
        (tree :> IBinaryTree<int>).RemoveValue 1
        (tree :> IBinaryTree<int>).RemoveValue 10
        (tree :> IBinaryTree<int>).IsContained 1 |> should equal false
        (tree :> IBinaryTree<int>).IsContained 10 |> should equal false
        for i in 2..9 do
            (tree :> IBinaryTree<int>).IsContained i |> should equal true
        (tree :> IBinaryTree<int>).GetLength  |> should equal 8
        (tree :> IBinaryTree<int>).RemoveValue 7
        (tree :> IBinaryTree<int>).IsContained 7 |> should equal false
        (tree :> IBinaryTree<int>).GetLength  |> should equal 7
      
    //// <summary>
    /// Complicated remove existed values test.
    /// Should save the structure of a binary tree.
    /// </summary>
    [<Test>]
    let ``Complicated remove existed values test`` () = 
        (tree :> IBinaryTree<int>).RemoveValue 3
        (tree :> IBinaryTree<int>).RemoveValue 6
        (tree :> IBinaryTree<int>).RemoveValue 8
        (tree :> IBinaryTree<int>).RemoveValue 4
        let expected = [| 1; 2; 5; 7; 9; 10 |]
        let actual = [| for i in tree -> i |]
        actual |> should equal expected 
    
    //// <summary>
    /// Simple remove not existed values test.
    /// An exception should be thrown.
    /// </summary>
    [<Test>]
    let ``Simple remove not existed values test`` () = 
        (fun () -> (tree :> IBinaryTree<int>).RemoveValue 0 |> ignore)
            |> should throw typeof<System.Exception>