// Learn more about F# at http://fsharp.net
// See the 'F# Tutorial' project for more help.

let kill (p: System.Diagnostics.Process) =
    p.Kill()
    ()

let protect f =
    fun p ->
        try
            f p
        with _ -> ()

let protectedKill = protect(kill)

[<EntryPoint>]
let main argv = 
    System.Diagnostics.Process.GetProcessesByName("chrome")
    |> Array.iter (fun p -> protectedKill p)
    0 // return an integer exit code
