namespace Homework5

module Task1 = 
   
    let isBalanced str =
        let pairs  = [('(', ')'); ('[', ']'); ('{', '}')]
        let isPair (a, b) = pairs |> List.contains (a, b)
        let rec isBalanced' (str, ls) =
            match str with
            | h :: t when (h = '(' || h = '[' || h = '{') -> isBalanced' (t, h :: ls)
            | h :: t when (h = ')' || h = ']' || h = '}') -> match ls with
                                                             | [] -> false
                                                             | _ -> if isPair(ls.Head, h) then isBalanced' (t, ls.Tail) else false
            | _ :: t -> isBalanced' (t, ls)
            | [] -> ls.IsEmpty
        isBalanced' (str |> Seq.toList, [])


    