namespace MyTasks

module Task1 = 

    let averageSin ls = 
        let rec sumSin ls (acc : float) =
            match ls with
            | [] -> acc
            | head :: tail -> sumSin tail (acc + sin(head))
        (sumSin ls 0.0) / (float)ls.Length

module Task2 = 
    
    let createSquare (n : int) = 
        let rec printSquare (row : int, column : int) = 
            match (row, column) with
            | (x, y) when x = n && y = n -> printfn "*"
            | (x, y) when y = n -> printfn "*"
                                   printSquare (x + 1, 1)
            | (x, y) when (x = 1) || (x = n) || (y = 1) -> printf "*"
                                                           printSquare (x, y + 1)
            | (x, y) -> printf " "
                        printSquare (x, y + 1)
        printSquare (1, 1)

module Task3 = 
        
    type QueueElement<'T> = { Value : 'T; Key : int}

    type Queue<'T>() = 

        let mutable queue = List.empty<QueueElement<'T>>
        
        member this.Insert (value : 'T) (key : int) =
            {Value = value; Key = key} :: queue |> ignore
        member this.Get () = 
            match queue.Length with
            | 0 -> failwith "Queue is empty!"
            | _ ->  queue |> List.rev |> List.head
        member this.ExtractMin () = 
            match queue.Length with
            | 0 -> failwith "Queue is empty!"
            | _ -> queue |> List.minBy (fun element -> element.Key) |> (fun element -> element)
        member this.ExtractMax () = 
            match queue.Length with
            | 0 -> failwith "Queue is empty!"
            | _ -> queue |> List.maxBy (fun element -> element.Key) |> (fun element -> element)
        member this.DeleteMin () = 
            match queue.Length with
            | 0 -> failwith "Queue is empty!"
            | _ -> let minKey = queue |> List.minBy (fun element -> element.Key) |> (fun element -> element.Key)
                   queue <- queue |> List.filter (fun element -> element.Key <> minKey)
        member this.DeleteMax () = 
            match queue.Length with
            | 0 -> failwith "Queue is empty!"
            | _ -> let maxKey = queue |> List.maxBy (fun element -> element.Key) |> (fun element -> element.Key)
                   queue <- queue |> List.filter (fun element -> element.Key <> maxKey)
        member this.List
            with get () = queue