module Server

open Elmish
open Avalonia.FuncUI
open Avalonia.FuncUI.Types
open Avalonia.Controls
open Avalonia.Layout
open Avalonia.FuncUI.DSL

type Model = 
    string * SourceServer option
    

type Msg = 
    | Start
    | Suspend
    | Delete

let init = 
    None, Cmd.none

let update (msg: Msg) (model: Model) =
    match msg with
    | _ -> 
        model , Cmd.none

let view (model:Model) dispatch =
    DockPanel.create [
        DockPanel.children [
            StackPanel.create [
                StackPanel.dock Dock.Bottom
                StackPanel.children [      
                    TextBlock.create [
                        TextBlock.text (sprintf "%A" (model))
                    ]               
                ]
            ]
        ]
    ]
