let rec factorial n =
    match n with
    | n when n < 0 -> -1
    | 0 -> 1
    | _ -> n * factorial (n - 1)

let fibonacci n =
    [1..n] |> List.fold (fun (l, r) _ -> (r, l + r)) (0, 1) |> fst

let reverse ls = 
    match ls with
    | [] -> ls
    | _ -> List.fold (fun acc x -> x :: acc) [] ls

let makeList n m =
    let rec pow n =
        match n with
        | n when n < 0 -> -1
        | 0 -> 1
        | _ -> 2 * pow (n - 1)
    let rec make m acc = 
        if m < 0 then [] else acc :: make (m - 1) (acc * 2)
    make m (pow n)