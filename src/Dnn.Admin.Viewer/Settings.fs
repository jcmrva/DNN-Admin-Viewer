module Settings

open Elmish
open Avalonia.FuncUI
open Avalonia.FuncUI.Types
open Avalonia.Controls
open Avalonia.Layout
open Avalonia.FuncUI.DSL

type SidebarPosition = | Left | Right

type Model =
    { SidebarPosn : SidebarPosition
    }

type Msg = 
    FlipSidebar

let init = 
    { SidebarPosn = Left }, Cmd.none

let update (msg: Msg) (model: Model) =
    match msg with
    | FlipSidebar ->
        let posn = if model.SidebarPosn = Left then Right else Left
        { model with SidebarPosn = posn }
        , Cmd.none

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
                    TextBlock.create [
                        TextBlock.text (sprintf "%A" model.SidebarPosn)
                    ]               
                ]
            ]
        ]
    ]
