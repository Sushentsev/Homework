namespace MyTasks

module Task1 = 

    let averageSin ls = 
        let rec sumSin ls (acc : float) =
            match ls with
            | [] -> acc
            | head :: tail -> sumSin tail (acc + sin(head))
        (sumSin ls 0.0) / (float)ls.Length

module Task2 = 
    
    type Tree<'a> = 
        | Node of 'a * Tree<'a> * Tree<'a>
        | Empty

    let getMinHeight tree = 
        let rec getMinHeight' tree ls acc = 
            match tree with
            | Node(a, left, Empty) -> acc :: ls
            | Node(a, Empty, right) -> acc :: ls
            | Node(a, left, right) -> 
                getMinHeight' left ls (acc + 1) |> ignore
                getMinHeight' right ls (acc + 1)
            | _ -> ls
        getMinHeight' tree [] 0