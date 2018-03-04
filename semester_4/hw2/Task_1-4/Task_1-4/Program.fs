let product n = 
    let rec productPositiveValue value = 
        if value < 10 then value else (value % 10) * productPositiveValue (value / 10)
    productPositiveValue (abs(n))

let findPosition ls n =
    let rec position ls pos =
        match ls with
        | [] -> None
        | h :: t -> if h = n then Some(pos) else position t (pos + 1)
    position ls 0

let isPalindrome str =
    let newStr = str |> Seq.filter (fun x -> x <> ' ') |> Seq.toList
    newStr = List.rev newStr

let rec mergeSort ls =
    let rec split ls (left, right) =
        match ls with
        | [] -> (left, right)
        | [a] -> (a :: left, right)
        | a :: b :: tail -> split tail (a :: left, b :: right)
    let rec merge (left, right) = 
        match (left, right) with
        | (left, []) -> left
        | ([], right) -> right
        | (hl :: tl, hr :: tr) -> if hl < hr then hl :: merge (tl, right) else hr :: merge (left, tr)
    match ls with
    | [] -> ls
    | [a] -> ls
    | _ -> 
        let left, right = split ls ([], [])
        merge (mergeSort left, mergeSort right)