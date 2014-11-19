namespace PeopleConsole

open PeopleData

module Program =
    [<EntryPoint>]
    let main argv =
        getPeople() |> Async.RunSynchronously |> Seq.iter (fun person ->
            printfn "%s %s" person.FirstName person.LastName )
        0