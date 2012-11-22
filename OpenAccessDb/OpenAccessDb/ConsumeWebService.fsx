

#I "C:\Program Files\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.5\System.ServiceModel.dll"
#r "System.ServiceModel"
open System.ServiceModel
open System
open Microsoft.FSharp.Linq
#I "C:\Program Files\Reference Assemblies\Microsoft\FSharp\3.0\Runtime\v4.0\Type Providers\FSharp.Data.TypeProviders.dll"
#r "FSharp.Data.TypeProviders"
open Microsoft.FSharp.Data.TypeProviders



type CustomerService = WsdlService<"http://ewasdev.development.lizearle.com/LizEarle/CRM.WebService/1.8.0/CRM/CustomerService200906.asmx?WSDL">

try
  let customerServiceClient = CustomerService.GetCustomerService200906Soap12() 
    let customerRegistration = 
      let serviceCustomerRegistration = new CustomerService.ServiceTypes.GetCustomerRequest()
      do serviceCustomerRegistration.CustomerAccountNumber <- "1234545"
      do serviceCustomerRegistration.MessageHeader <- new CustomerService.ServiceTypes.MessageHeader()
      serviceCustomerRegistration

      myCustomer = customerServiceClient.GetCustomer(customerRegistration)
      printfn "Service Returned: %s" (myCustomer.CompleteCustomerDetails)
with
    | :? ServerTooBusyException as exn ->
        let innerMessage =
            match (exn.InnerException) with
            | null -> ""
            | innerExn -> innerExn.Message
        printfn "An exception occurred:\n %s\n %s" exn.Message innerMessage
    | exn -> printfn "An exception occurred: %s" exn.Message


// -------------------- ---- //
// Customer Service Settings //
//---------------------------//

let serviceUrl          = "http://ewasdev.development.lizearle.com/LizEarle/CRM.WebService/1.8.0/CRM/CustomerService200906.asmx"
let serviceUsername     = "s-crmService"
let servicePassword     = "p@ssw0rd"

type Credentials = {
    Username    :   string
    Password    :   string
}

let NetworkCredentials credentials = 
  new NetworkCredential(credentials.Username, credentials.Password)

let customerServiceClient = CustomerService.GetCustomerService200906Soap12() 
let customerRegistration = new CustomerService.ServiceTypes.GetCustomerRequest()
do customerRegistration.CustomerAccountNumber <- "1234545"
do customerRegistration.MessageHeader <- new CustomerService.ServiceTypes.MessageHeader()

let myCustomer = customerServiceClient.GetCustomer(customerRegistration)
let newList = myCustomer.ResponseHeader.StatusDetails
//    |> List.filter (fun i -> i.

printfn "Service Returned: %s" (myCustomer.ResponseHeader.StatusDetails)

