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
    
    type Task3_Tests() = 

        let hashFunction (value : string) = String.length value

        let mutable hashTable = new HashTable<string>(hashFunction)

        let data = [ "first"; "second"; "third"; "fourth"; "fifth" ]

        let falseData = [ "one"; "two"; "tree" ]

        [<SetUp>]
        member this.``SetUp``() = 
            hashTable <- new HashTable<string>(hashFunction)
            data |> List.iter hashTable.AddValue

        [<Test>]
        member this.``IsContained test`` () =
            data |> List.iter (fun element -> hashTable.IsContained element |> should be True)
            falseData |> List.iter (fun element -> hashTable.IsContained element |> should be False)

        [<Test>]
        member this.``RemoveValue test`` () =
            hashTable.RemoveValue data.[0]
            let data1 = data |> List.filter (fun element -> element <> data.[0])
            hashTable.IsContained data.[0] |> should be False
            data1 |> List.iter (fun element -> hashTable.IsContained element |> should be True)