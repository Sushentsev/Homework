module Network
open Computer
open System
open System.IO

/// <summary>
/// Interface for network class.
/// </summary>
type INetwork = 

    /// <summary>
    /// Contains array of computers.
    /// </summary>
    abstract Computers : IComputer[]

    /// <summary>
    /// Contains adjacency matrix.
    /// </summary>
    abstract Graph : bool[][]

    /// <summary>
    /// Makes move: tries to infect computer.
    /// </summary>
    abstract MakeMove : unit -> unit

    /// <summary>
    /// Print detailed information: computer ID and whether it is infected.
    /// </summary>
    abstract PrintInformation : unit -> unit

    /// <summary>
    /// Gets number of infected computers.
    /// </summary>
    abstract NumberOfInfectedComputers : unit -> int

/// <summary>
/// Network class.
/// Contains all methods for performing basic network functions.
/// </summary>
type Network(computers : IComputer[], graph : bool[][], random : Random) = 
    
    let numberOfInfectedComputers () = 
        computers |> Array.filter (fun computer -> computer.IsInfected) |> Array.length
    let areAllInfected () =
        Array.length computers = numberOfInfectedComputers ()
    let areAllNotInfected () = 
        numberOfInfectedComputers () = 0
    let tryToInfectRandomComputer () =
        let index = random.Next(0, Array.length computers)
        computers.[index].TryToInfect ()

    /// <summary>
    /// Loads essential information from file: number of computers, operation systems, adjacency matrix.
    /// </summary>
    /// <param name="filePath">File path.</param>
    new (filePath : string) = 
        let random = new Random()
        let lines = File.ReadAllLines filePath
        let count = lines.[0].Split() |> Array.item 0 |> int
        let os = lines.[1].Split() |> Array.map (int >> enum)
        let computers = [| for index in 0 .. count - 1 -> new Computer(os.[index], random) :> IComputer |]
        let graph = 
            [| 
                for line in (lines |> Array.toSeq |> Seq.skip 2) do
                yield line.Split() |> Array.map (fun x -> if x = "1" then true else false)
            |]
        Network(computers, graph, random)
    
    interface INetwork with
        member this.Computers = computers
        member this.Graph = graph
        member this.MakeMove () =
            match areAllNotInfected (), areAllInfected () with
            | true, _ -> tryToInfectRandomComputer ()
            | _, false -> let infectRow row = graph.[row] |> Array.iteri (fun column state -> if (graph.[row].[column]) then computers.[column].TryToInfect ())
                          computers |> Array.iteri (fun index computer -> if computer.IsInfected then infectRow index)
            | _, _ -> ()
        member this.PrintInformation () =
            computers |> Array.iteri (fun index computer -> printfn "Computer %i on %O infection: %b" index computer.OS computer.IsInfected)
        member this.NumberOfInfectedComputers () = numberOfInfectedComputers ()