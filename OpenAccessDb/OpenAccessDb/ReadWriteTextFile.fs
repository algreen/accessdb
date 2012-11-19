//Puts padding into the output
module ReadWriteTextFile


open System
open System.IO

let CreateNewFile = 
    let obtainWords (line : string) =
        line.Split(" ".ToCharArray())
        
    let padWord (word : string) = 
        word.PadRight(10, ' ')


    let applyPadding (words : string []) =
        Array.map (padWord) words

    let joinWords (words : string []) = 
        System.String.Concat(words)
        
          
    let readFile =
        File.ReadAllLines(@"D:\AlsFile.txt")
        |> Array.map(obtainWords)
        |> Array.map(applyPadding)
        |> Array.map(joinWords)
    File.WriteAllLines(@"D:\AlsOutputFile.txt", readFile)

CreateNewFile
printfn "Completed"
             