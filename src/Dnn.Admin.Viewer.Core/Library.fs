[<AutoOpen>]
module Library

open System

type ServerActive =
    | Inactive
    | Active of System.Data.IDbConnection

type SourceServer =
    { Name : string
      ConnStr : string
      LastAccessed : DateTime option
      Active : ServerActive
    }


[<Measure>] type second

type Refresh =
    | Interval of int<second>
    | Backoff

type Notification =
    | DontBotherMe
