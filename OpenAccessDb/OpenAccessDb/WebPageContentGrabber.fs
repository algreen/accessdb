// http://fsharpforfunandprofit.com/posts/fvsc-download/  
// This sort of file would allow you to scrape a web page for specific information

module WebPageContentGrabber

    open System.Net
    open System
    open System.IO

    // Open the contents of the Web Page
    let fetchUrl callback url = 
        let req = WebRequest.Create(Uri(url))
        use resp= req.GetResponse()
        use stream = resp.GetResponseStream()
        use reader = new IO.StreamReader(stream)
        callback reader url

    let myCallback (reader:IO.StreamReader) url =
        let html = reader.ReadToEnd()
        let html1000 = html.Substring(0,1000)
        printfn "Downloaded %s. First 1000 is %s" url html1000
        html  // return all the html

    // test
    let scottsSite = fetchUrl myCallback "http://fsharpforfunandprofit.com/posts/fvsc-download/"

    // build a function with the callback "baked in"
    let fetchUrl1 = fetchUrl myCallback

    // test
    let google      = fetchUrl1 "http://www.google.co.uk"
    let bbc         = fetchUrl1 "http://news.bbc.co.uk"

    // test a list of sites
    let sites   =   ["http://onthewight.com";
                    "http://iwight.com"]

    let content = sites |>  List.map fetchUrl1
    
    //lets write output to a text file
    File.WriteAllLines(@"D:\AlsOutputFile.txt", content)

    // lets try to find specific words in this file
    let ParseFile = File.ReadAllLines("D:\\AlsOutputFile.txt")

    let ParseFileForSpecificWords = 
        ParseFile
        |> Seq.filter(fun x -> if x.Contains("broadband") then false else true)

    let FileSummary = "Length of file : " + ParseFile.Length.ToString() + " - Number of Occurrances : " + (ParseFileForSpecificWords |> (Seq.length)).ToString()

