open NUnit.Framework
open FsUnit
open Homework3.Task1
open Homework3.Task2
open Homework3.Task3
open Homework3.Task4

module Task1_Tests = 
 
    let data () = 
        [
            ([], 0);
            ([for x in 1..100 -> 2 * x], 100);
            ([for x in 1..100 -> 2 * x + 1], 0);
            ([1..100], 50);
        ] |> List.map (fun (ls, res) -> TestCaseData(ls).Returns(res))

    [<TestCaseSource("data")>]
    let ``MapFunc test`` s =
        evenNumbersMap s

    [<TestCaseSource("data")>]
    let ``FilterFunc test`` s =
        evenNumbersFilter s
        
    [<TestCaseSource("data")>]
    let ``FoldFunc test`` s =
        evenNumbersFold s

module Task2_Tests = 

    [<Test>]
    let ``Map with id function of not empty tree`` () = 
        let tree = Tree(4, Tree(2, Tip(1), Tip(3)), Tip(5))
        map tree id |> should equal tree

    [<Test>]
    let ``Map with square function of not empty tree`` () = 
        let func = fun x -> x * x
        let tree = Tree(4, Tree(2, Tip(1), Tip(3)), Tip(5))
        let res = Tree(16, Tree(4, Tip(1), Tip(9)), Tip(25))
        map tree func |> should equal res

module Task3_Tests = 

    [<Test>]
    let ``Eval of const should be const`` () = 
        eval (Value(-1.0)) |> should equal -1.0
        eval (Value(42.0)) |> should equal 42.0
        eval (Value(22.8)) |> should equal 22.8

    [<Test>]
    let ``Eval of 2 * 4 + 9 / 3 - 4 * 5 / 2 should be 1`` () = 
        let tree = Sub(Add(Mul(Value(2.0), Value(4.0)), Div(Value(9.0), Value(3.0))), Div(Mul(Value(4.0), Value(5.0)), Value(2.0)))
        eval tree |> should equal 1.0

    [<Test>]
    let ``Eval of 1.0 / 0.0 should be infinity`` () = 
        let tree = Div(Value(1.0), Value(0.0))
        eval tree |> should equal infinity

module Task4_Tests = 
    
    [<Test>]
    let ``1st prime number should be 2`` () = 
        primeSeq () |> Seq.item 0 |> should equal 2

    [<Test>]
    let ``5th prime number should be 11`` () = 
        primeSeq () |> Seq.item 4 |> should equal 11

    [<Test>]
    let ``10th prime number should be 29`` () = 
        primeSeq () |> Seq.item 9 |> should equal 29