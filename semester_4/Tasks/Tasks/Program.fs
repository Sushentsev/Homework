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

                

