module PeopleData

open FSharp.Data

type Person = {
    FirstName: string
    LastName: string
    }

[<Literal>]
let connectionString =
    // AdventureWorks on Azure now hosted by Red Gate software
    // http://sqlblog.com/blogs/jamie_thomson/archive/2013/05/20/adventureworks-on-azure-now-hosted-by-red-gate-software.aspx
    @"Server=mhknbn2kdz.database.windows.net;Database=AdventureWorks2012;User=sqlfamily;Password=sqlf@m1ly"

[<Literal>]
let getPeopleSql = 
    @"select top 10 FirstName, LastName from person.person"

type GetPeopleQuery= SqlCommandProvider<getPeopleSql, connectionString>

let getPeople() =
    use getPeopleQuery = new GetPeopleQuery()
    async {
        let! people = getPeopleQuery.AsyncExecute()
        return people |> Seq.map (fun p -> {FirstName=p.FirstName; LastName=p.LastName}) |> List.ofSeq
    }
