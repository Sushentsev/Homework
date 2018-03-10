namespace Homework3

module Task1 =

    let evenNumbersMap = List.map (fun x -> (x + 1) % 2) >> List.sum 

    let evenNumbersFilter = List.filter (fun x -> x % 2 = 0) >> List.length

    let evenNumbersFold = List.fold (fun x acc -> acc + (x + 1) % 2) 0

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