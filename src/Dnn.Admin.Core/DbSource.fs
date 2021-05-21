module DbSource

open System
open System.Data
open System.Data.SqlClient
open Donald

let sqlConn connStr =
    new SqlConnection(connStr)
    
type EventLogType =
    { LogTypeKey : string
      Name : string
      Owner : string
      IsActive : bool
      KeepRecentEntries : int
    }
    static member fromDataReader (rd:IDataReader) =
      { LogTypeKey = rd.ReadString "LogTypeKey"
        Name = rd.ReadString "Name"
        Owner = rd.ReadString "Owner"
        IsActive = rd.ReadBoolean "IsActive"
        KeepRecentEntries = rd.ReadInt32 "KeepRecentEntries"
      }

let eventLogTypesQuery conn =
    dbCommand conn {
        cmdText "
            SELECT ELT.LogTypeKey
              , ELT.LogTypeFriendlyName as Name
              , ELT.LogTypeOwner as Owner
              , CAST(case ELC.LoggingIsActive when 1 then 1 else 0 end as bit) as IsActive
              , CAST(ISNULL(ELC.KeepMostRecent, -1) as int) as KeepRecentEntries
            FROM dbo.EventLogTypes as ELT
            LEFT JOIN dbo.EventLogConfig as ELC on ELC.LogTypeKey = ELT.LogTypeKey
            "
    }
let eventLogTypesResult conn =
    eventLogTypesQuery conn
    |> DbConn.query EventLogType.fromDataReader

type EventLog =
    { LogGUID : string
      LogTypeKey : string
      LogConfigID : int
      LogCreateDate : DateTime
      LogServerName : string
      LogPortalID : int
      LogPortalName : string
    }
    static member fromDataReader (rd:IDataReader) =
      { LogGUID = rd.ReadString "LogGUID"
        LogTypeKey = rd.ReadString "LogTypeKey"
        LogConfigID = rd.ReadInt32 "LogConfigID"
        LogCreateDate = rd.ReadDateTime "LogCreateDate"
        LogServerName = rd.ReadString "LogServerName"
        LogPortalID = rd.ReadInt32 "LogPortalID"
        LogPortalName = rd.ReadString "LogPortalName"
      }

let eventLogSelect = "
            SELECT LogGUID
              , LogTypeKey
              , LogConfigID
              , LogCreateDate
              , LogServerName
              , LogPortalID
              , LogPortalName
            FROM dbo.EventLog
            "

let eventLogAllQuery conn =
    dbCommand conn {
        cmdText eventLogSelect
    }
let eventLogAllResult conn =
    eventLogAllQuery conn 
    |> DbConn.query EventLog.fromDataReader

let eventLogNewQuery conn dt =
    dbCommand conn {
        cmdText $"{eventLogSelect} WHERE LogCreateDate >= @dt"
        cmdParam [ "dt", SqlType.DateTime dt ]
    }
let eventLogNewResult conn dt =
    eventLogNewQuery conn dt 
    |> DbConn.query EventLog.fromDataReader


let testCmd conn =
    dbCommand conn {
        cmdText "SELECT 'test' as Test"
    }

let testResult conn =
    conn |> testCmd |> DbConn.querySingle (fun rd -> rd.ReadString "Test")
