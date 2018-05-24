open NUnit.Framework
open FsUnit
open System.IO
open Computer
open Network

module Tests = 
    
    let getFilePath (fileName : string) = 
        let path = System.AppDomain.CurrentDomain.BaseDirectory;
        Path.GetFullPath(Path.Combine(path, @"..\..\")) + @"Data\" + fileName;

    /// <summary>
    /// Tries to infect independent computers.
    /// No more than one computer must be infected.
    /// </summary>
    [<Test>]
    let ``Infecting independent computers test`` () = 
        let network = new Network(getFilePath("Test1.txt"))
        for i in 0..50 do
            (network :> INetwork).MakeMove()
        (network :> INetwork).NumberOfInfectedComputers () |> should be (lessThanOrEqualTo 1)
    
    /// <summary>
    /// Tries to infect computers with safe operation system.
    /// All computers must not be infected.
    /// </summary>
    [<Test>]
    let ``Infecting computers with safeOS test`` () = 
        let network = new Network(getFilePath("Test2.txt"))
        for i in 0..50 do
            (network :> INetwork).MakeMove()
        (network :> INetwork).NumberOfInfectedComputers () |> should equal 0