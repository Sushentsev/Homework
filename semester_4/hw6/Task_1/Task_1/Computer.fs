module Computer
open System

/// <summary>
/// Available types of operating systems.
/// </summary>
type OS = 
    | Windows = 0
    | Linux = 1
    | MacOS = 2
    | Embox = 3
    | SafeOS = 4

/// <summary>
/// Interface for computer class.
/// </summary>
type IComputer = 

    /// <summary>
    /// Indicates the type of OS.
    /// </summary>
    abstract OS : OS

    /// <summary>
    /// Indicates whether the computer is infected.
    /// </summary>
    abstract IsInfected : bool with get, set

    /// <summary>
    /// Tries to infect random computer.
    /// </summary>
    abstract TryToInfect : unit -> unit
    
/// <summary>
/// Computer class.
/// Contains all methods for performing basic computer functions.
/// </summary>
type Computer(OS : OS, random : Random) = 
    
    let mutable isInfected = false
    let probabitityOfInfection =
        match OS with
        | OS.Windows -> random.Next(50, 70)
        | OS.Linux -> random.Next(10, 25)
        | OS.MacOS -> random.Next(25, 40)
        | OS.Embox -> random.Next(0, 10)
        | OS.SafeOS -> 0
        | _ -> 100
    
    interface IComputer with
        member this.OS = OS
        member this.IsInfected
            with get () = isInfected
            and set x = isInfected <- x
        member this.TryToInfect () = 
            let random' = random.Next(1, 100)
            if random' <= probabitityOfInfection then isInfected <- true