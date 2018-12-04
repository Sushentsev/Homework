﻿module LambdaInterpreter
open System

let alphabet () = ['a' .. 'z'] |> List.map Char.ToString

/// <summary>
/// Type for term.
/// Uses string in order to allow variables of several letters.
/// </summary>
type Term = 
    | Var of string
    | App of Term * Term
    | Abs of string * Term

/// <summary>
/// Generates not reserved name for variable.
/// New name is generated by replicating items from alphabet the appropriate times (until they are free).
/// </summary>
let generateName (reserved : string list) = 
    let rec generateName' (iteration : int) = 
        let names = alphabet () |> List.map (String.replicate iteration)
        let notReserved = ((Set.ofList names) - (Set.ofList reserved)) |> Set.toList
        match notReserved.Length with
        | 0 -> generateName' (iteration + 1)
        | _ -> List.head notReserved
    generateName' 1

/// <summary>
/// Gets free variables from term.
/// </summary>
let getFV (term : Term) = 
    let rec getFV' (term' : Term) (ls : string list) = 
        match term' with
        | Var (x) -> x :: ls
        | App (S, T) -> (getFV' S ls) @ (getFV' T ls)
        | Abs (x, S) ->  getFV' S ls |> List.filter ((<>) x)
    getFV' term [] |> List.distinct

/// <summary>
/// Implements substitution.
/// </summary>
let rec substitution (S : Term) (x : string) (T : Term) = 
    match S with
    | Var (y) when y = x -> T
    | Var (y) -> S
    | App (t1, t2) -> App (substitution t1 x T, substitution t2 x T)
    | Abs (y, t) when y = x -> S 
    | Abs (y, t) when not (getFV T |> List.contains y) || not (getFV S |> List.contains x) -> Abs(y, substitution t x T)
    | Abs (y, t) -> 
        let z = generateName ((getFV S) @ (getFV T))
        Abs(z, substitution (substitution t y (Var z)) x T)   
    
/// <summary>
/// Implements reduction.
/// </summary>
let rec reduction (term : Term) = 
    match term with
    | Var (x) -> term
    | App (Abs (x, S), T) -> reduction (substitution S x T)
    | App (S, T) -> reduction (App (reduction S, T))
    | Abs (x, S) -> Abs (x, reduction S)