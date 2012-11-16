open System.IO
open System

let ParseFile = 
    let ParseFile = File.ReadAllLines("D:\\ErrorFile.txt")
    
    let ParseFileForErrors = 
        ParseFile
        |> Seq.filter(fun x -> if x.Contains("_warning_") then false else true)
    
    let ParseFileForWarnings = 
        ParseFile
        |> Seq.filter(fun x -> if x.Contains("_warning_") then true else false)

    let myFileSet = 
        let mySubFileSet = Seq.append ParseFileForErrors ParseFileForWarnings    
        let FileSummary = "Number of Entries : " + ParseFile.Length.ToString() + " Number of Errors : " + (ParseFileForErrors |> Seq.length).ToString()
        Seq.append ( FileSummary |> Seq.singleton) mySubFileSet
    
    File.WriteAllLines("D:\\ErrorResults.txt", myFileSet)        

ParseFile
printfn "Done"

