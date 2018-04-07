open NUnit.Framework
open FsUnit
open Homework5.Task1


module Task1_Tests = 
    
    [<Test>]
    let ``Empty string test should be true`` () = 
        let str = ""
        str |> isBalanced |> should equal true

    [<Test>]
    let ``String without brackets test should be true`` () = 
        let str = "qwerty42"
        str |> isBalanced |> should equal true

    [<Test>]
    let ``Correct test1`` () = 
        let str = "efw()wd(we(we))"
        str |> isBalanced |> should equal true

    [<Test>]
    let ``Correct test2`` () = 
        let str = "[[adsddd[a]sdsd]d]"
        str |> isBalanced |> should equal true

    [<Test>]
    let ``Correct test3`` () = 
        let str = "{}{}asa{aa}{{}a}"
        str |> isBalanced |> should equal true

    [<Test>]
    let ``Correct test4`` () = 
        let str = "([{adadd{(ad)}ad}]adad)dd"
        str |> isBalanced |> should equal true

    [<Test>]
    let ``Correct test5`` () = 
        let str = "{}sfsf[]add(a){q(as)q}"
        str |> isBalanced |> should equal true

    [<Test>]
    let ``Incorrect test1`` () = 
        let str = "eerer)(wdw"
        str |> isBalanced |> should equal false

    [<Test>]
    let ``Incorrect test2`` () = 
        let str = "wdwd[wef]wr["
        str |> isBalanced |> should equal false

    [<Test>]
    let ``Incorrect test3`` () = 
        let str = "{{sdsdd}sfsf}}"
        str |> isBalanced |> should equal false

    [<Test>]
    let ``Incorrect test4`` () = 
        let str = "{}sfsf([)]sff{}"
        str |> isBalanced |> should equal false

    [<Test>]
    let ``Incorrect test5`` () = 
        let str = "{}sfsf[]add(aq(as)q}"
        str |> isBalanced |> should equal false