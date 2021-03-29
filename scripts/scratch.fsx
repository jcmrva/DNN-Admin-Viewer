// from the project root, first make sure Core is compiled with dependencies
// dotnet publish .\src\Dnn.Admin.Viewer.Core\

#r "../src/Dnn.Admin.Viewer.Core/bin/Debug/net5.0/publish/Dnn.Admin.Viewer.Core.dll"
#r "nuget: System.Data.SqlClient, 4.8.2"
#r "nuget: Donald, 5.1.3"

open DbSource
open System.Data.SqlClient
open Donald

let connStr = 
    "Data Source=<server>;Initial Catalog=<dnn-db>;User ID=<user-id>;Password=<password>"

let conn = sqlConn connStr

testResult conn

eventLogTypesResult conn

let eventsToday =
    eventLogNewResult conn System.DateTime.Today

eventsToday |> function 
    | Ok data -> List.length data
    | _ -> 0

conn.Dispose()
