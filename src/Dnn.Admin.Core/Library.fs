[<AutoOpen>]
module Library

open System

type ServerActive =
    | Inactive
    | Active of System.Data.IDbConnection

type SourceServer =
    { Name : string
      ConnStr : string option
      LastAccessed : DateTime option
      Active : ServerActive
    }


[<Measure>] type second

type Refresh =
    | Interval of time:int<second>
    | Backoff of time:int<second> * exp:int

type Notification =
    | DontBotherMe
