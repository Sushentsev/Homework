open NUnit.Framework
open FsUnit
open Tasks.Task1
open Tasks.Task2

type Task1_Tests() = 
    
    let rounding x = new RoundingBuilder(x)

    [<Test>]
    member this.``Test 1`` () = 
        let actual = rounding 3 {
            let! a = 2.0 / 12.0
            let! b = 3.5
            return a / b
        }

        actual |> should equal 0.048

    [<Test>]
    member this.``Test 2`` () = 
        let actual = rounding 2 {
            let! a = 22.0
            let! b = 7.0
            return a / b
        }

        actual |> should equal 3.14
  
type Task2_Tests() = 

    let calculate = new CalculationBuilder()

    [<Test>]
    member this.``Correct data test`` () = 
        let actual = calculate {
            let! x = "1"
            let! y = "2"
            let z = x + y
            return z
        }

        actual |> should equal (Some 3)

    [<Test>]
    member this.``Incorrect data test`` () =
        let actual = calculate {
            let! x = "1"
            let! y = "Ъ"
            let z = x + y
            return z
        }

        actual |> should equal None