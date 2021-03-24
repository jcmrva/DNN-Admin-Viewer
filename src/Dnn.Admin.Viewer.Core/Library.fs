[<AutoOpen>]
module Library

open System

type SourceServer =
    { Name : string
      ConnStr : string
      LastAccessed : DateTime option
      Active : bool
    }


[<Measure>] type second

type Refresh =
    | Interval of int<second>
    | Backoff

type Notification =
    | DontBotherMe
