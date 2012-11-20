


#I "C:\Program Files\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.5\System.ServiceModel.dll"
#r "System.ServiceModel"
open System.ServiceModel
open System
open Microsoft.FSharp.Linq
#I "C:\Program Files\Reference Assemblies\Microsoft\FSharp\3.0\Runtime\v4.0\Type Providers\FSharp.Data.TypeProviders.dll"
#r "FSharp.Data.TypeProviders"
open Microsoft.FSharp.Data.TypeProviders

//type twitter = "http://twitter.com/statuses/user_timeline.xml?id=joelcomm"

type TerraService = WsdlService<"http://msrmaps.com/TerraService2.asmx?WSDL">

try
    let terraClient = TerraService.GetTerraServiceSoap()
    let myPlace = new TerraService.ServiceTypes.msrmaps.com.Place(City = "Redmond", State = "Washington", Country = "United States")
    let myLocation = terraClient.ConvertPlaceToLonLatPt(myPlace)
    printfn "Redmond Latitude: %f Longitude: %f" (myLocation.Lat) (myLocation.Lon)
with
    | :? ServerTooBusyException as exn ->
        let innerMessage =
            match (exn.InnerException) with
            | null -> ""
            | innerExn -> innerExn.Message
        printfn "An exception occurred:\n %s\n %s" exn.Message innerMessage
    | exn -> printfn "An exception occurred: %s" exn.Message
