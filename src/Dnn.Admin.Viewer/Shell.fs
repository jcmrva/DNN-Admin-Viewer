module Shell

open Avalonia.Layout

open Elmish
open Avalonia
open Avalonia.Controls
open Avalonia.Input
open Avalonia.FuncUI.DSL
open Avalonia.FuncUI
open Avalonia.FuncUI.Builder
open Avalonia.FuncUI.Components.Hosts
open Avalonia.FuncUI.Elmish
open Avalonia.FuncUI.Types

type Model =
    { summary : Summary.Model
      settings : Settings.Model
      servers : Map<string, SourceServer option>
    }

type Msg =
    | SettingsMsg of Settings.Msg
    | SummaryMsg of Summary.Msg
    | ServerMsg of Server.Msg * name:string



let init =
    let settings, _ = Settings.init
    let summary, _ = Summary.init

    { summary = summary; settings = settings; servers = Map.empty },
    Cmd.none

let update (msg: Msg) (model: Model): Model * Cmd<_> =
    match msg with
    | SettingsMsg (Settings.AddServer n) ->
        let s = 
            match model.servers |> Map.tryFind n with
            | Some _ ->                
                model.servers
            | None ->
                Map.add n None model.servers

        { model with servers = s }, Cmd.none
    | SettingsMsg msg ->
        let m, _ =
            Settings.update msg model.settings

        { model with settings = m }
        , Cmd.none
    | ServerMsg (msg, name) ->
        let m, _ =
            Server.update msg (name, Map.find name model.servers)
        let s =
            model.servers |> Map.change name (fun _ -> snd m |> Some)

        { model with servers = s }
        , Cmd.none
    | _ -> 
        model, Cmd.none


let view (state: Model) dispatch =
    
    let TabItem' attr =
        TabItem.create attr :> IView // for TabControl.create compat

    let dockPosition =
        if state.settings.SidebarPosn = Settings.Left then
            Dock.Left
        else
            Dock.Right

    let serverTab (name:string) =
        let servModel = 
            state.servers |> Map.find name |> fun s -> (name, s)
        TabItem' [                            
            TabItem.header name
            TabItem.content (Server.view servModel (ServerMsg >> dispatch)) 
        ]

    let serverTabs =
        state.servers |> Map.toList |> List.map (fst >> serverTab)

    let tabs =
            [
                TabItem' [
                    TabItem.header "Summary"
                    TabItem.content (Summary.view state.summary (SummaryMsg >> dispatch)) 
                ]
                TabItem' [
                    TabItem.verticalAlignment VerticalAlignment.Bottom
                    TabItem.header "Settings"
                    TabItem.content (Settings.view state.settings (SettingsMsg >> dispatch)) 
                ]
            ]
            |> List.append serverTabs

    let tabCtrl = 
        TabControl.create [
            TabControl.tabStripPlacement dockPosition
            TabControl.viewItems tabs
        ] 
    DockPanel.create [
        DockPanel.children [ tabCtrl ]
    ]

type MainWindow() as this =
    inherit HostWindow()
    do
        base.Title <- "DNN Admin Viewer"
        base.Width <- 800.0
        base.Height <- 600.0
        base.MinWidth <- 800.0
        base.MinHeight <- 600.0

        //this.VisualRoot.VisualRoot.Renderer.DrawFps <- true
        //this.VisualRoot.VisualRoot.Renderer.DrawDirtyRects <- true

        Elmish.Program.mkProgram (fun () -> init) update view
        |> Program.withHost this
        |> Program.run
