module MessagingTest

let printerAgent = MailboxProcessor.Start(fun inbox->
    
    // message processing funtiom
    let rec messageLoop = async {

        // read message if there is one
        let! msg = inbox.Receive()

        // process a message
        printfn "message is: %s" msg

        //Loop totop
        return! messageLoop
        }

    // start the loop
    messageLoop
    )


// test
printerAgent.Post "Now is the time for all messages to be posted"
