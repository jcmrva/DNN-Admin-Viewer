module Summary 

open Elmish
open Avalonia.FuncUI
open Avalonia.FuncUI.Types
open Avalonia.Controls
open Avalonia.Layout
open Avalonia.FuncUI.DSL

type Model =
    { placeholder : bool
    }

type Msg = 
    NoOp

let init = 
    { placeholder = true }, Cmd.none

let update (msg: Msg) (model: Model) =
    match msg with
    | _ ->
        model
        , Cmd.none

let view model dispatch =
    DockPanel.create [
    ]
