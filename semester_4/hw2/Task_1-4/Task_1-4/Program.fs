let rec product n = 
    if n < 10 then n else (n % 10) * product (n / 10)

let findPosition ls n =
    let rec position ls pos =
        match ls with
        | [] -> -1
        | h :: t -> if h = n then pos else position t (pos + 1)
    position ls 0

let isPalindrome str =
    let newStr = str |> Seq.filter (fun x -> x <> ' ') |> Seq.toList
    newStr = List.rev newStr