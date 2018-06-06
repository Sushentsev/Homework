module OS
open System

/// <summary>
/// Available types of operating systems.
/// </summary>
type SystemType = 
    | Windows = 0
    | Linux = 1
    | MacOS = 2
    | Embox = 3
    | SafeOS = 4

/// <summary>
/// Type for system.
/// </summary>
type OS(index : int, random : Random) = 

    let system = enum index
    let probabilityOfInfection =
        match system with
        | SystemType.Windows -> random.Next(50, 70)
        | SystemType.Linux -> random.Next(10, 25)
        | SystemType.MacOS -> random.Next(25, 40)
        | SystemType.Embox -> random.Next(0, 10)
        | SystemType.SafeOS -> 0
        | _ -> 100

    member this.GetProbability () = 
        probabilityOfInfection
 