// Crib sheet http://msdn.microsoft.com/en-us/library/hh361033.aspx
// We will do the following in the script
// 1) Find customers
// 2) Find Customer Orders
// 3) Replicate logic from the Complete Button in AMO
// 3.i) Call CalcLettersDue
// 3 ii) Call CalcTotalSpend
// 3 iii) Call Loyalty
// 3 iiii) Call Complimentary


System.IO.Directory.SetCurrentDirectory (__SOURCE_DIRECTORY__)

#I @"C:\Program Files (x86)\Reference Assemblies\Microsoft\FSharp\3.0\Runtime\v4.0\Type Providers\FSharp.Data.TypeProviders.dll"
#r "FSharp.Data.TypeProviders"
open Microsoft.FSharp.Data.TypeProviders

// to get the interactive window to run with the DLL i want
#I @"C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.5\"
#r "System.Data.Linq"
open System.Data.Linq

// Cannot get the Configuration working
#load "ConfigurationSetup.fs"
open ConfigurationSetup

let config = ConfigurationSetup.GetConfiguration
let databaseLocation = config.AmoDatabaseLocation

//type sqlSchema = SqlDataConnection<config.AmoDatabaseLocation>

type amoSchema = SqlDataConnection<"Data Source=DEV02a\DEV2005;Initial Catalog=amo;Integrated Security=SSPI", StoredProcedures=true>
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


let nullable value = new System.Nullable<_>(value)



// Calculate Total Spend Stored Proc
let calcTotalSpendStoredProc customerId =
   let spendResults = db.Pr_AMO_CalcTotalSpend(nullable customerId)
//  for result in spendResults do
   printfn "Calc Total Spend %s" (spendResults.ToString())

// Calculate Letters Due
let calcLettersDue customerId orderId = 
    let letterResults = db.Pr_AMO_CalcLettersDue(nullable orderId, nullable customerId, "", "", nullable 1)
    printfn "Calculate Letters Due"

// Calculate Loyalty Due's
let calculateLoyaltysDue customerId =
    //let loyaltys = db.Pr_AMO_Loyalty_new 
    printfn "Calculate Loyalty's Due"

// Calculate which Complimentary Gifts are due....
let calculateComplimentaryGifts customerId orderId =
    let complimentary = db.pr_TS_TargetSampling(nullable customerId, nullable 1, nullable 100,  nullable orderId, "LEBM")
    printfn "Calculate Complimentary Gifts"


// run the combined efforts 
let runOrderAdditions customerId orderId =
     calcTotalSpendStoredProc customerId
     calcLettersDue customerId orderId
     calculateLoyaltysDue customerId
     calculateComplimentaryGifts customerId orderId
     printfn "Completed Successfully"

runOrderAdditions 150 10



// TO DO  - Db inserting, db updating etc etc





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

