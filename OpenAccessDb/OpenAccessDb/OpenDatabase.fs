module OpenDatabase

//
//open System.Data.OleDb
//open System.Data
//
//
//////Connect to Access Db//
//    use ADOCon = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;
//        Data Source=D:\Amo.accdb")
//
//        ADOCon.Open()
//
//       // let DAdapter = new OleDbDataAdapter("Select MSysObjects.Name from MSysObjects", ADOCon)
//
//        let oleDbCommand = new OleDbCommand("Product", ADOCon)
//  
//
//         use reader = oleDbCommand.ExecuteReader
//            while reader.Read() do
//                printfn "Data: %s" reader.ProductCode
//