open FsUnit
open NUnit.Framework
open MyTasks.Task1
open MyTasks.Task2
open System


module Task1_Tests = 
    
    [<Test>]
    let ``List of zeros`` = 
        [0.0; 0.0; 0.0] |> averageSin |> should equal 0.0
    
    [<Test>]
    let ``List of pi/2`` = 
        [(Math.PI) / 2.0; (Math.PI) / 2.0; (Math.PI) / 2.0] |> averageSin |> should equal 1.0

module Task2_Tests = 

    [<Test>]
    let ``Empty tree`` () = 
        Empty |> getMinHeight |> should equal 0
    
    [<Test>]
    let ``Not empty tree1`` () = 
        let tree = Tree(5, Empty, Empty)
        tree |> getMinHeight |> should equal 0

    [<Test>]
    let ``Not empty tree2`` () = 
        let tree = Tree(5, Empty, Tree(6, Empty, Empty))
        tree |> getMinHeight |> should equal 0

    [<Test>]
    let ``Not empty tree3`` () = 
        let tree = Tree(5, Tree(6, Empty, Empty), Tree(7, Empty, Empty))
        tree |> getMinHeight |> should equal 1