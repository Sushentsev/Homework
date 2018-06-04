open System.Net
open System.IO
open System.Text.RegularExpressions

/// <summary>
/// Gets and prints data.
/// </summary>
/// <param name="url">URL.</param>
let printData (url : string) = 
    
    let fetchAsync (url : string) = 
        async {
            let request = WebRequest.Create(url)
            use! response = request.AsyncGetResponse()
            use stream = response.GetResponseStream()
            use reader = new StreamReader(stream)
            let html = reader.ReadToEnd()
            do printfn "Read response for %s" url
            return html
        }

    let getLinks (html : string) = 
        let regex = new Regex("<a href=\"(https?://.+?)\">")
        let matches = regex.Matches(html)
        [for x in matches -> x.Groups.[1].Value]

    let print (list : (string * Choice<string, exn>) list) =
        for (url, choice) in list do
            match choice with
            | Choice1Of2 html -> printfn "Read %d characters for %s" html.Length url
            | Choice2Of2 (ex : exn) -> printfn "Exception for %s thrown: %s" url ex.Message

    url 
        |> fetchAsync 
        |> Async.Catch 
        |> Async.RunSynchronously 
        |> fun x ->
            match x with
            | Choice1Of2 result -> 
                let links =  result |> getLinks
                let results = links |> List.map (fetchAsync >> Async.Catch) |> Async.Parallel |> Async.RunSynchronously |> Array.toList
                (List.zip links results) |> print
            | Choice2Of2 (ex : exn) -> printfn "Exception thrown: %s" ex.Message  