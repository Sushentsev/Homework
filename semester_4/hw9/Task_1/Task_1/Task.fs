namespace Homework9

module Lazy =

    open System.Threading
    open System

    /// <summary>
    /// Interface for Lazy objects.
    /// </summary>
    type ILazy<'a> = 
        abstract member Get : unit -> 'a

    /// <summary>
    /// Lazy type for single-threaded mode.
    /// </summary>
    type SingleLazy<'a> (supplier : unit -> 'a) = 
    
        let mutable value = None

        interface ILazy<'a> with
            member this.Get () = 
                match value with 
                | Some x -> x
                | None -> 
                    let res = supplier ()
                    value <- Some res
                    res
                               
    /// <summary>
    /// Lazy type for multithreaded mode.
    /// Uses Monitor.
    /// </summary>
    type MultiLazy<'a> (supplier : unit -> 'a) = 

        let mutable value = None
        let guardObject = obj()

        interface ILazy<'a> with 
            member this.Get () = 
                match value with
                | Some (x) -> x
                | None ->
                    Monitor.Enter guardObject
                    try
                        if value.IsNone 
                        then
                            let res = supplier ()
                            value <- Some res
                    finally
                        Monitor.Exit guardObject
                    Option.get value

    /// <summary>
    /// Lazy type for multithreaded mode.
    /// Uses Interlocked.
    /// </summary>
    type LockFreeLazy<'a> (supplier : unit -> 'a) = 
        
        let mutable value = ref None

        interface ILazy<'a> with
            member this.Get () = 
                if (!value).IsNone
                then
                    let res = supplier ()
                    Interlocked.CompareExchange(value, Some res, None) |> ignore
                Option.get !value

                    
module LazyFactory = 

    open Lazy

    /// <summary>
    /// Factory for lazy objects.
    /// </summary>
    type LazyFactory() = 

        static member CreateSingleLazy (supplier : unit -> 'a) = 
            SingleLazy<'a>(supplier)

        static member CreateMultiLazy (supplier : unit -> 'a) =
            MultiLazy<'a>(supplier)

        static member CreateLockFreeLazy (supplier : unit -> 'a) = 
            LockFreeLazy<'a>(supplier)