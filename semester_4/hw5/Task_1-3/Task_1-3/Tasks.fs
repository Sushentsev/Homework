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
    open System.IO

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

    let saveToFile (filePath : string) (phoneBook : List<Record>) = 
        use sw = new StreamWriter(File.OpenWrite(filePath))
        phoneBook |> List.iter (fun record -> sw.WriteLine(record.Name + " | " + record.Phone))
        sw.Close()

    let readData (sr : StreamReader) = 
        let rec readData' (sr : StreamReader) (phoneBook : List<Record>) = 
            if (not sr.EndOfStream)
            then
                let subString = sr.ReadLine().Split([|" | "|], StringSplitOptions.None)
                readData' sr ({ Name = subString.[0]; Phone = subString.[1]; } :: phoneBook)
            else
                sr.Close()
                phoneBook
        readData' sr []

    let loadFromFile (filePath : string) = 
        if (File.Exists filePath)
        then
            use sr = new StreamReader(File.OpenRead(filePath))
            readData sr
        else
            []

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
        | "5" -> printfn "Your PhoneBook:"
                 if (phoneBook |> List.length) = 0
                 then printfn "PhoneBook is empty!"
                 else phoneBook |> List.iter (fun record -> printfn "%s | %s" record.Name record.Phone)
                 handle phoneBook
        | "6" -> printfn "Enter file path:"
                 let filePath = Console.ReadLine()
                 saveToFile filePath phoneBook
                 printfn "Data was successfully saved!"
                 handle phoneBook
        | "7" -> printfn "Enter file path:"
                 let filePath = Console.ReadLine()
                 let loadedPhoneBook = loadFromFile filePath
                 printfn "Data was successfully loaded!"
                 handle loadedPhoneBook
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