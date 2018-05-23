open NUnit.Framework
open FsUnit
open System.IO
open Computer
open Network

module Tests = 
    
    let getFilePath (fileName : string) = 
        let path = System.AppDomain.CurrentDomain.BaseDirectory;
        Path.GetFullPath(Path.Combine(path, @"..\..\")) + @"Data\" + fileName;
  
  //  let randomComputers = new Network(getFilePath("Test2.txt"));
  //  let safeOSComputers = new Network(getFilePath("Test3.txt"));

    /// <summary>
    /// Tries to infect independent computers.
    /// No more than one computer must be infected.
    /// </summary>
    [<Test>]
    let ``Infecting independent computers test`` () = 
        let network = new Network(getFilePath("Test1.txt"))
        printfn "%A" (network :> INetwork).Graph
        (network :> INetwork).Computers.Length |> should equal 7
        for i in 0..50 do
            (network :> INetwork).MakeMove()
        (network :> INetwork).Computers |> Array.iter (fun computer -> printfn "%A" (computer :> IComputer).IsInfected)
     //   (network :> INetwork).NumberOfInfectedComputers () |> should be (lessThanOrEqualTo 1)