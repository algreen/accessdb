// Crib sheet http://msdn.microsoft.com/en-us/library/hh361033.aspx

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

let query2 = 
    query {
        for row in db.TblCustomers do
        join row2 in db.TblOrders on (row.CustomerID = row2.CustomerID)
        select (row, row2)
    }

// find specific data
let findCustomer customerId =
    query {
        for row in db.TblCustomers do
        where (row.CustomerID = customerId)
        select row
        }

findCustomer 100 |> Seq.iter (fun row -> printfn "Found row: %d %s" row.CustomerID row.LastName)

// calling Stored Procs, have to pass in StoredProcs = true

type storedProcSchema = SqlDataConnection<"Data Source=DEV02a\DEV2005; Initial Catalog=amo;Integrated Security=SSPI", StoredProcedures=true>

let testdb = storedProcSchema.GetDataContext()

// nullable parameters to be passed across as nullable
let nullable value = new System.Nullable<_>(value)
//
//let calcTotalSpendStoredProc customerId =
//    let spendResults = testdb.Pr_AMO_CalcTotalSpend(nullable customerId)
//  //  for result in spendResults do
//        printfn "%d" (spendResults.ToString()) // should be something like (results.Data.GetValueorDefault()
//  
//        spendResults.Return

// Inserting or updating the database

//let newRecord = new dbSchema.ServiceTypes.TblCustomers(FirstName = "Ted",
//                                                        LastName = "Baker")
//
//let newValues = 
//    [
//        for i in [1 .. 10] ->
//            new dbSchema.ServiceTypes.Table3(Id = 700 + i,
//                                            Name = "Testing" + i.ToString(),
//                                            Data = i) ]

//
db.Table1.InsertOnSubmit(newRecord)
db.Table3.InsertAllOnSubmit(newValues)
try
    db.DataContext.SubmitChanges()
    printfn "Successfully inserted new rows"
with
    |   exn -> printfn "Exception:\n%s" exn.Message




// Customer Web Service

type CustomerWebService = WsdlService<"http://?wsdl">

try

with
    |

