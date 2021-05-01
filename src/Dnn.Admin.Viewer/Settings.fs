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
      NewServerName : string
    }

type Msg =
    | FlipSidebar
    | AddServer
    | ServerName of string

let init =
    { SidebarPosn = Left; NewServerName = ""; }
    , Cmd.none

let update (msg: Msg) (model: Model) =
    match msg with
    | FlipSidebar ->
        let posn = if model.SidebarPosn = Left then Right else Left
        { model with SidebarPosn = posn }
        , Cmd.none
    | ServerName n ->
        { model with NewServerName = n }
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
                        Button.content "Toggle Sidebar"
                    ]
                    Button.create [
                        Button.onClick
                            (fun _ -> AddServer |> dispatch)
                        Button.content "Add Server"
                    ]
                    TextBox.create [
                        TextBox.maxLength 20
                        TextBox.text model.NewServerName
                        TextBox.onTextChanged
                            (ServerName >> dispatch)
                    ]
                ]
            ]
        ]
    ]
