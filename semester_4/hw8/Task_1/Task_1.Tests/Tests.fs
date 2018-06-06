open FsUnit
open NUnit.Framework
open Homework.Task

[<Test>]
let ``Get URLs test1`` () =
    let expected = 
        [
            "http://www.math.spbu.ru/";
            "http://www.euler-foundation.org/";
        ]
    let url = "http://www.math.spbu.ru/Euler/"
    url |> getData |> List.iter (fun (item, _) -> expected |> should contain item)

[<Test>]
let ``Get URLs test2`` () =
    let expected = 
        [
            "http://se.math.spbu.ru/SE/SE/programer.doc";
            "http://se.math.spbu.ru/SE/Members/ylitvinov/styleguide";
        ]
    let url = "http://hwproj.me/courses/12"
    url |> getData |> List.iter (fun (item, _) -> expected |> should contain item)

[<Test>]
let ``Get URLs test3`` () =
    let url = "http://orlo.lolo"
    (fun () ->  url |> getData |> ignore)
        |> should throw typeof<System.Exception>