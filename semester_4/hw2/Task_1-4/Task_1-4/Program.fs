let rec product n = 
    if abs(n) < 10 then abs(n) else (abs(n) % 10) * product (n / 10)

let findPosition ls n =
    let rec position ls pos =
        match ls with
        | [] -> None
        | h :: t -> if h = n then Some(pos) else position t (pos + 1)
    position ls 0

let isPalindrome str =
    let newStr = str |> Seq.filter (fun x -> x <> ' ') |> Seq.toList
    newStr = List.rev newStr