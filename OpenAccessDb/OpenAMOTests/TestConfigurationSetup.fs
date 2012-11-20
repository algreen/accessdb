module TestConfigurationSetup

    open System
    open System.Configuration

    type SetupConfiguration = {
        CustomerWebServiceUrl   :   string
        AmoDatabaseLocation     :   string
    }

    let defaultConfiguration = {
        CustomerWebServiceUrl   =   "http://localhost"
        AmoDatabaseLocation     =   "Data Source=localhost; Initial Catalog=amo;Integrated Security=SSPI"
    }

    let getKey key = 
        let reader = new AppSettingsReader()
        try
            Some (reader.GetValue(key, typeof<string>).ToString())
        with
        |   _ -> None

    let GetKeyValue key = 
        let value = getKey key
        match value with
        | Some s -> s
        | None -> ""

    let amoDatabaseLocation = GetKeyValue "AmoDatabaseLocation"
    let customerWebServiceUrl = GetKeyValue "CustomerWebServiceUrl"

    let LoadConfiguration config =
        {
            config with
                AmoDatabaseLocation = amoDatabaseLocation
                CustomerWebServiceUrl = customerWebServiceUrl
        }

    let GetConfiguration =
        defaultConfiguration |> LoadConfiguration