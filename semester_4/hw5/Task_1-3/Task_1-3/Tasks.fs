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

module Task3 = 

    open System

    type Record =
        { 
            Name: string;
            Phone: string; 
        }

    let addRecord (name : string) (phone : string) (phoneBook : List<Record>) = 
        { Name = name; Phone = phone; } :: phoneBook
    
    let findByName (name : string) (phoneBook : List<Record>) =
        phoneBook |> List.filter (fun record -> record.Name = name)

    let findByPhone (phone : string) (phoneBook : List<Record>) =
        phoneBook |> List.filter (fun record -> record.Phone = phone)

    let saveToFile (phoneBook : List<Record>) = printfn "Not implemented"

    let loadFromFile (phoneBook : List<Record>) = printfn "Not implemented"


    let rec handle (phoneBook : List<Record>) = 
        printfn "Enter command:"
        let command = Console.ReadLine()
        match command with
        | "1" -> printfn "Bye!"
        | "2" -> printfn "Enter name:"
                 let name = Console.ReadLine()
                 printfn "Enter phone:"
                 let phone = Console.ReadLine()
                 let newPhoneBook = addRecord name phone phoneBook
                 printfn "New record was successfully added!"
                 handle newPhoneBook
        | "3" -> printfn "Enter name:"
                 let name = Console.ReadLine()
                 let filteredBook = findByName name phoneBook
                 printfn "Found records:"
                 if (filteredBook |> List.length) = 0
                 then printfn "There is no such person"
                 else filteredBook |> List.iter (fun record -> printfn "%s" record.Phone)
                 handle phoneBook
        | "4" -> printfn "Enter phone:"
                 let phone = Console.ReadLine()
                 let filteredBook = findByPhone phone phoneBook
                 printfn "Found records:"
                 if (filteredBook |> List.length) = 0
                 then printfn "There is no such person"
                 else filteredBook |> List.iter (fun record -> printfn "%s" record.Name)
                 handle phoneBook
        | "5" -> if (phoneBook |> List.length) = 0
                 then printfn "PhoneBook is empty!"
                 else phoneBook |> List.iter (fun record -> printfn "%s %s" record.Name record.Phone)
                 handle phoneBook
        | "6" -> printfn "Not implemented"
                 handle phoneBook   
        | "7" -> printfn "Not implemented"
                 handle phoneBook  
        | _ -> printfn "Incorrect command! Try again"
               handle phoneBook

    let commands = 
        [|
            "1. Exit";
            "2. Add new record (name and phone)";
            "3. Find phone by name";
            "4. Find name by phone";
            "5. Print data";
            "6. Save current data to file";
            "7. Load data from file";
        |]
    
    let launch = 
        printfn "Available commands:"
        commands |> Array.iter (printfn "%s")
        handle []