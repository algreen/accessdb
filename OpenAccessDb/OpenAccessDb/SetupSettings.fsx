module SetupSettings

    open System
    open System.Configuration

    type accessApplication = {
        WorkingDirectory    :   string

    }   

    let getSetting key =
        let reader = new AppSettingsReader()
        try
            Some (reader.GetValue(key, typeof<string>).ToString())
        with
        | _ -> None


    let GetSetting key = 
        let value = getSetting key
        match value with
        | Some v -> v
        | None -> ""

    let workingDir = GetSetting "WorkingDir"


    let LoadConfiguration config = 
        { config with
            WorkingDirectory = workingDir

            }


