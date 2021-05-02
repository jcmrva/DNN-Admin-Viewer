[<RequireQualifiedAccess>]
module Log

open Elmish
open Avalonia.FuncUI
open Avalonia.FuncUI.Types
open Avalonia.Controls
open Avalonia.Layout
open Avalonia.FuncUI.DSL
open System
open Microsoft.FSharp.Reflection

type Msg =
    | ServerAlreadyExists of string
    | ServerTabAdded of string
    | Start

type LogEntry =
    { detail : string
      timestamp : DateTime
      msg : Msg
    }
    static member New dtl msg =
        { detail = dtl
          timestamp = DateTime.Now
          msg = msg
        }

type Model =
    LogEntry list

let init : Model * Msg =
    [ ], Start

let toString (x:'a) = 
    match FSharpValue.GetUnionFields (x, typeof<'a>) with
    | case, _ -> case.Name

let update (msg: Msg) (model: Model) =
    let update' dtl =
        (LogEntry.New dtl msg) :: model

    match msg with
    | ServerAlreadyExists s ->
        $"{s} already exists in server list."
    | ServerTabAdded s ->
        $"{s} added to server list."
    | Start ->
        "Application Started."
    |> update'

let private logEntryView (e:LogEntry) =
    TextBlock.create [ TextBlock.text <| e.ToString () ] :> IView

let view model =
    DockPanel.create [
        DockPanel.children [
            StackPanel.create [
                StackPanel.dock Dock.Bottom
                StackPanel.margin 5.0
                StackPanel.spacing 5.0
                StackPanel.children (List.map logEntryView model)
            ]
        ]
    ]
