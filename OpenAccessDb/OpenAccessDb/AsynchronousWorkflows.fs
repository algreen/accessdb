// Running asynchronous workflows
//http://fsharpforfunandprofit.com/posts/concurrency-async-and-parallel/

module AsynchronousWorkflows

open System

let task1 = async { return 10+10 }
let task2 = async { return 20+20 }

Async.RunSynchronously (Async.Parallel [task1; task2 ])


// Sleep for 2 seconds
let sleepWorkflow = async {
    printfn "Starting sleep workflow at %O" DateTime.Now.TimeOfDay
    do! Async.Sleep 2000
    printfn "Finished sleep workflow at %O" DateTime.Now.TimeOfDay
}

Async.RunSynchronously sleepWorkflow

// Composing workflows in series and parallel

let sleepWorkflowMs ms = async {
        printfn "%i ms workflow started" ms
        do! Async.Sleep ms
        printfn "%i ms workflow finished" ms
    }

// Run this workflow in parallel

let sleep1 = sleepWorkflowMs 1000
let sleep2 = sleepWorkflowMs 2000

// run them in parallel
//#time
[sleep1; sleep2]
    |> Async.Parallel
    |> Async.RunSynchronously
//#time