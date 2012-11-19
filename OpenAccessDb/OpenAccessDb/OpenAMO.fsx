// Open AMO script file
// Goal is to Open AMO
// Return all of the Object names, tables, queries, forms, reports

open System.IO
open System

//let OpenAccessFile = 
let openAccess = File.ReadAllBytes("D:\\Amo.accdb")

//let openAccessDb = File.WriteAllLines("D:\\Amo.accdb")
//
//
//open System.Windows.Forms
open System.Data.OleDb
open System.Data

////Connect to Access Db//
    let ADOCon = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;
        Data Source=D:\Amo.accdb")

        
       // let DAdapter = new OleDbDataAdapter("Select MSysObjects.Name from MSysObjects", ADOCon)

        let oleDbCommand = new OleDbCommand("Product", ADOCon)
     //   ADOCon.Open()

            let OleDbDataReader reader = oleDbCommand.ExecuteReader
           //     let DataTable table = reader.GetSchemaTable()
