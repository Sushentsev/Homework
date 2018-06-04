open NUnit.Framework
open FsUnit
open System
open System.Threading
open Homework9.Lazy
open Homework9.LazyFactory

type Task1_Tests() = 

    let random = new Random()

    let testHelper (object : ILazy<int>) = 
        let threadCount = 100
        let exp = object.Get()
        let results = Array.zeroCreate threadCount
        let threads = [| for index in 0..threadCount - 1 -> new Thread(fun () -> results.[index] <- object.Get()) |]
        threads |> Array.iter (fun thread -> thread.Start())
        threads |> Array.iter (fun thread -> thread.Join())
        let expected = object.Get()
        results |> Array.iter (should equal expected)

    /// <summary>
    /// Test for SingleLazy type.
    /// </summary>
    [<Test>]
    member this.``SingleLazy test`` () = 
        let count = 10
        let object = LazyFactory.CreateSingleLazy(fun () -> random.Next())
        let expected = (object :> ILazy<int>).Get()
        let actualList = [for index in 1..count -> (object :> ILazy<int>).Get()]
        actualList |> List.iter (should equal expected)

    /// <summary>
    /// Test for MultiLazy type.
    /// </summary>
    [<Test>]
    member this.``MultiLazy test`` () = 
        let object = LazyFactory.CreateMultiLazy(fun () -> random.Next())
        testHelper(object :> ILazy<int>)

    /// <summary>
    /// Test for LockFreeLazy type.
    /// </summary>
    [<Test>]
    member this.``LockFreeLazy test`` () = 
        let object = LazyFactory.CreateLockFreeLazy(fun () -> random.Next())
        testHelper(object :> ILazy<int>)