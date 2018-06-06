module Computer
open System
open OS

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
    let system = OS
    
    interface IComputer with
        member this.OS = OS
        member this.IsInfected
            with get () = isInfected
            and set x = isInfected <- x
        member this.TryToInfect () = 
            let random' = random.Next(1, 100)
            if random' <= OS.GetProbability() then isInfected <- true