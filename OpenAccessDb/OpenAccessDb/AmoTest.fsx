

#I "C:\Program Files (x86)\Reference Assemblies\Microsoft\FSharp\3.0\Runtime\v4.0\Type Providers\FSharp.Data.TypeProviders.dll"
#r "FSharp.Data.TypeProviders"
open Microsoft.FSharp.Data.TypeProviders

// to get the interactive window to run with the DLL i want
#I "C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.5\System.Data.Linq.dll"
#r "System.Data.Linq" ;;
open System.Data.Linq;;


type amoSchema = SqlDataConnection<"Data Source=DEV02A\DEV2005;Initial Catalog=amo;Integrated Security=SSPI;">
let db = amoSchema.GetDataContext()

db.DataContext.Log <- System.Console.Out

let table1 = db.TblCustomers

// build the query
let query1 =
    query {
        for row in db.TblCustomers do
            select row
    }
query1 |> Seq.iter (fun row -> printfn "%s %d" row.LastName row.CustomerID)

