namespace OpenAccessDb

open System.IO 
open System.Net
open System   


// Fetches one at a time
let fetchUrl url =
    let req = WebRequest.Create(Uri(url))
    use resp = req.GetResponse()
    use stream = resp.GetResponseStream()
    use reader = new IO.StreamReader(stream)
    let html = reader.ReadToEnd()
    printfn "finished downloading %s" url

let sites = ["http://fsharpforfunandprofit.com";
             "http://www.bbc.co.uk";
             "http://www.google.co.uk"]

#time
sites
|> List.map fetchUrl
#time


// Now the Concurrent version
open Microsoft.FSharp.Control.CommonExtensions

// Fetch the contents of a web page asynchronously
let fetchUrlAsync url = 
    async   {
        let req = WebRequest.Create(Uri(url))
        use! resp = req.AsyncGetResponse() 
        use stream = resp.GetResponseStream()
        use reader = new IO.StreamReader(stream)
        let html = reader.ReadToEnd()
        printfn "finished downloading %s" url
        }

#time                       //  turn interactive timer on
sites
|> List.map fetchUrlAsync   //  make a list of async tasks
|> Async.Parallel           //  set up the tasks to run in parallel
|> Async.RunSynchronously   //  start them off
#time                       //  turn timer off



// web request
let fetchUrlTest url = 
    async {
        let request = WebRequest.Create(Uri(url))
        use! resp = request.AsyncGetResponse()
        use stream = resp.GetResponseStream()
        use reader = new IO.StreamReader(stream)
        let html = reader.ReadToEnd()
        printfn "Finished downloading %s" url
        }

        sites |> List.map fetchUrlTest


let serializedExample = 
    let logger = new SerializedLogger()
    [1..5]
        |> List.map (fun i -> makeTask logger.Log i)
        |> Async.Parallel
        |> Async.RunSynchronously
        |> ignore
