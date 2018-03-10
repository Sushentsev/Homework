open NUnit.Framework
open FsUnit
open Homework3.Task1
open Homework3.Task2
open Homework3.Task3

module Task1 = 

    module MapFunc = 

        [<Test>]
        let ``Amount of even numbers in empty list should be 0`` () =
            evenNumbersMap [] |> should equal 0
        
        [<Test>]
        let ``Amount of even numbers in [2; 4; ... ; 200]  should be 100`` () =
            evenNumbersMap [for x in 1..100 -> 2 * x] |> should equal 100

        [<Test>]
        let ``Amount of even numbers in [3; 5; ... ; 201]  should be 0`` () =
            evenNumbersMap [for x in 1..100 -> 2 * x + 1] |> should equal 0

        [<Test>]
        let ``Amount of even numbers in [1..100]  should be 50`` () =
            evenNumbersMap [1..100] |> should equal 50

    module FilterFunc = 

        [<Test>]
        let ``Amount of even numbers in empty list should be 0`` () =
            evenNumbersFilter [] |> should equal 0
        
        [<Test>]
        let ``Amount of even numbers in [2; 4; ... ; 200]  should be 100`` () =
            evenNumbersFilter [for x in 1..100 -> 2 * x] |> should equal 100

        [<Test>]
        let ``Amount of even numbers in [3; 5; ... ; 201]  should be 0`` () =
            evenNumbersFilter [for x in 1..100 -> 2 * x + 1] |> should equal 0

        [<Test>]
        let ``Amount of even numbers in [1..100]  should be 50`` () =
            evenNumbersFilter [1..100] |> should equal 50

    module FoldFunc = 

        [<Test>]
        let ``Amount of even numbers in empty list should be 0`` () =
            evenNumbersFold [] |> should equal 0
        
        [<Test>]
        let ``Amount of even numbers in [2; 4; ... ; 200]  should be 100`` () =
            evenNumbersFold [for x in 1..100 -> 2 * x] |> should equal 100

        [<Test>]
        let ``Amount of even numbers in [3; 5; ... ; 201]  should be 0`` () =
            evenNumbersFold [for x in 1..100 -> 2 * x + 1] |> should equal 0

        [<Test>]
        let ``Amount of even numbers in [1..100]  should be 50`` () =
            evenNumbersFold [1..100] |> should equal 50

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