namespace Homework3

module Task1 =

    let evenNumbersMap ls = ls |> List.map (fun x -> (x + 1) % 2) |> List.sum 

    let evenNumbersFilter ls = ls |> List.filter (fun x -> x % 2 = 0) |> List.length

    let evenNumbersFold ls = ls |> List.fold (fun acc x -> acc + (x + 1) % 2) 0

module Task2 = 

    type Tree<'a> = 
        | Tree of 'a * Tree<'a> * Tree<'a>
        | Tip of 'a

    let rec map tree func = 
        match tree with
        | Tip(x) -> Tip(func x)
        | Tree(x, left, right) -> Tree(func x, map left func, map right func)

module Task3 =

    type Proposition =
        | Value of float
        | Add of Proposition * Proposition
        | Sub of Proposition * Proposition
        | Mul of Proposition * Proposition
        | Div of Proposition * Proposition

    let rec eval (p : Proposition) = 
        match p with
        | Value(x) -> x
        | Add(l, r) -> eval(l) + eval(r)
        | Sub(l, r) -> eval(l) - eval(r)
        | Mul(l, r) -> eval(l) * eval(r)
        | Div(l, r) -> eval(l) / eval(r)

module Task4 =

    let primeSeq =
        let isPrime n =
            let sqrt' = n |> float |> sqrt |> int
            [2 .. sqrt'] |> List.forall (fun x -> n % x <> 0)
        Seq.initInfinite(fun i -> i + 2) |> Seq.filter isPrime