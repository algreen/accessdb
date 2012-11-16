// Open AMO script file
// Goal is to Open AMO
// Return all of the Object names, tables, queries, forms, reports

open System.IO
open System

//let OpenAccessFile = 
    let openAccess = File.ReadAllBytes("D:\\Amo.accdb")

    let openAccessDb = File.WriteAllLines("D:\\Amo.accdb")


open System.Windows.Forms
open System.Data.OleDb
open System.Data

//Create winform//
let frmMain = new Form()

//Connect to Access Db//
let ADOCon = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;
  Data Source=C:\Users\...\Desktop\FSharpDb.mdb")

let DAdapter = new OleDbDataAdapter("Select * from Names_Table", ADOCon)

let DTable = new DataTable()
DAdapter.Fill(DTable)|>ignore
let view = new DataGridView()
do view.DataSource <- DTable

let ConnectionString = 
    ADOCon.Open()

frmMain.Controls.Add(view)

//Run main form on start up
Application.Run(frmMain)