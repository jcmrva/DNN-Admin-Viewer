module Settings

open Elmish
open Avalonia.FuncUI
open Avalonia.FuncUI.Types
open Avalonia.Controls
open Avalonia.Layout
open Avalonia.FuncUI.DSL
open System

type SidebarPosition = | Left | Right

type Model =
    { SidebarPosn : SidebarPosition
    }

type Msg = 
    | FlipSidebar
    | AddServer of name:string

let init = 
    { SidebarPosn = Left }, Cmd.none

let update (msg: Msg) (model: Model) =
    match msg with
    | FlipSidebar ->
        let posn = if model.SidebarPosn = Left then Right else Left
        { model with SidebarPosn = posn }
        , Cmd.none
    
    | _ -> model, Cmd.none

let view model dispatch =
    DockPanel.create [
        DockPanel.children [
            StackPanel.create [
                StackPanel.dock Dock.Bottom
                StackPanel.margin 5.0
                StackPanel.spacing 5.0
                StackPanel.children [
                    Button.create [
                        Button.onClick (fun _ -> dispatch FlipSidebar)
                        Button.content "toggle sidebar"
                    ]
                    Button.create [
                        Button.onClick (fun _ -> dispatch (AddServer $"Test {DateTime.Now.Millisecond}"))
                        Button.content "Add Server"
                    ]
                ]
            ]
        ]
    ]
