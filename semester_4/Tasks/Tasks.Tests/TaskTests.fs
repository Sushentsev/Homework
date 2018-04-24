open FsUnit
open NUnit.Framework
open MyTasks.Task1
open MyTasks.Task2
open MyTasks.Task3
open System


module Task1_Tests = 
    
    [<Test>]
    let ``List of zeros`` = 
        [0.0; 0.0; 0.0] |> averageSin |> should equal 0.0
    
    [<Test>]
    let ``List of pi/2`` = 
        [(Math.PI) / 2.0; (Math.PI) / 2.0; (Math.PI) / 2.0] |> averageSin |> should equal 1.0

module Task3_Tests = 

    let mutable queue = new Queue<int>()

    [<SetUp>]
    let ``SetUp``() = 
        queue.Insert 1 1
        queue.Insert 2 2
        queue.Insert 3 3

    [<Test>]
    let ``Insert test`` () = 
        queue.List |> should contain { Value = 1; Key = 1 } 
        queue.List |> should contain { Value = 1; Key = 1 }
        queue.List |> should contain { Value = 1; Key = 1 }

    [<Test>]
    let ``Get test`` () = 
        queue.Get () |> should equal { Value = 1; Key = 1 } 

    [<Test>]
    let ``ExtractMin test`` () = 
        queue.ExtractMin () |> should equal { Value = 1; Key = 1 } 

    [<Test>]
    let ``ExtractMax test`` () = 
        queue.ExtractMax () |> should equal { Value = 3; Key = 3 }

    [<Test>]
    let ``DeleteMin test`` () = 
        queue.DeleteMin ()
        queue.List |> should haveLength 2
        queue.List |> should not' (contain { Value = 1; Key = 1 })

    [<Test>]
    let ``DeleteMax test`` () = 
        queue.DeleteMax ()
        queue.List |> should haveLength 2
        queue.List |> should not' (contain { Value = 3; Key = 3 })


        