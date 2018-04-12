open NUnit.Framework
open FsUnit
open FsCheck
open Homework5.Task1
open Homework5.Task2
open Homework5.Task3

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

module Task2_Tests = 
    
    [<Test>]
    let ``Validation of func'1`` () = 
        Check.Quick (fun x y -> func x y = func'1 x y)

    [<Test>]
    let ``Validation of func'2`` () = 
        Check.Quick (fun x y -> func x y = func'2 x y)

    [<Test>]
    let ``Validation of func'3`` () = 
        Check.Quick (fun x y -> func x y = func'3 x y)
    
    [<Test>]
    let ``Validation of func'4`` () = 
        Check.Quick (fun x y -> func x y = func'4 x y)

module Task3_Tests = 
    
    open System

    let phoneBook = 
        [
            { Name = "Misha"; Phone = "12345"; };
            { Name = "Petr"; Phone = "2345"; };
            { Name = "Sasha"; Phone = "12345"; };
            { Name = "Masha"; Phone = "345"; };
            { Name = "Sasha"; Phone = "5678"; }
        ]

    [<Test>]
    let ``Add new record test`` () = 
        let updatedPhoneBook = addRecord "Pasha" "02" phoneBook
        updatedPhoneBook |> should contain {Name = "Pasha"; Phone = "02";}*)
        updatedPhoneBook |> should haveLength 6


    [<Test>]
    let ``Find phone by name test1`` () = 
        let filteredPhoneBook = findByName "John" phoneBook
        filteredPhoneBook |> should equal []
    
    [<Test>]
    let ``Find phone by name test2`` () = 
        let filteredPhoneBook = findByName "Misha" phoneBook
        filteredPhoneBook |> should equal [{ Name = "Misha"; Phone = "12345"; };]

    [<Test>]
    let ``Find phone by name test3`` () = 
        let filteredPhoneBook = findByName "Sasha" phoneBook
        filteredPhoneBook |> should contain { Name = "Sasha"; Phone = "12345"; }
        filteredPhoneBook |> should contain { Name = "Sasha"; Phone = "5678"; }
        filteredPhoneBook |> should haveLength 2

    [<Test>]
    let ``Find name by phone test1`` () = 
        let filteredPhoneBook = findByName "1" phoneBook
        filteredPhoneBook |> should equal []
    
    [<Test>]
    let ``Find name by phone test2`` () = 
        let filteredPhoneBook = findByName "2345" phoneBook
        filteredPhoneBook |> should equal [{ Name = "Petr"; Phone = "2345"; };]

    [<Test>]
    let ``Find name by phone test3`` () = 
        let filteredPhoneBook = findByName "12345" phoneBook
        filteredPhoneBook |> should contain { Name = "Misha"; Phone = "12345"; }
        filteredPhoneBook |> should contain { Name = "Sasha"; Phone = "12345"; }
        filteredPhoneBook |> should haveLength 2

    [<Test>]
    let ``Load from file test`` () = 
        let loadedPhoneBook = loadFromFile (Environment.CurrentDirectory + "\PB.txt")
        loadedPhoneBook |> should equal phoneBook