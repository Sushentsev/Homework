open NUnit.Framework
open FsUnit
open LambdaInterpreter
open System


module Task3_Tests = 
    
    let GenerateNameData () =
        [ 
            (['a' .. 'c'] |> List.map Char.ToString, "d");
            ((['a' .. 'z'] |> List.map Char.ToString) @ ["aa"; "bb"], "cc")
        ] |> List.map (fun (item, res) -> TestCaseData(item).Returns(res))

    let GetFVData () = 
        [
            (App(Abs("x", Abs("y", Var ("x"))), Abs("x", App(Var("z"), Var("x")))), ["z"])
            (Abs("x", App(Var("x"), Var("y"))), ["y"])
        ] |> List.map (fun (item, res) -> TestCaseData(item).Returns(res))

    let BetaReductionData () = 
        [
            (App(Abs("x", Var("x")), Abs("x", Var("x"))), Abs("x", Var("x")));
            (App(Abs("x", Abs("y", Var("x"))), Abs("x", Var("x"))), Abs("y", Abs("x", Var("x"))));
        ] |> List.map (fun (item, res) -> TestCaseData(item).Returns(res))
    
    [<TestCaseSource("GenerateNameData")>]
    let ``GenerateName tests`` s = 
        generateName s

    [<TestCaseSource("GetFVData")>]
    let ``GetFV tests`` s =
        getFV s

    [<TestCaseSource("BetaReductionData")>]
    let ``BetaReduction tests`` s =
        reduction s

    [<Test>]
    let ``Substitution test1`` () =
        let S = Abs("x", Var("x"))
        let x = "x"
        let T = Var("y")
        (substitution S x T) |> should equal (Abs("x", Var("x")))
    
    [<Test>]
    let ``Substitution test2`` () = 
        let S = Abs("x", App(Var("x"), Var("y")))
        let x = "y"
        let T = Var("z")
        (substitution S x T) |> should equal (Abs("x", App(Var("x"), Var("z"))))