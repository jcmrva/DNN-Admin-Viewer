namespace Dnn.Admin.Viewer
open Avalonia.Layout

module Shell =
    open Elmish
    open Avalonia
    open Avalonia.Controls
    open Avalonia.Input
    open Avalonia.FuncUI.DSL
    open Avalonia.FuncUI
    open Avalonia.FuncUI.Builder
    open Avalonia.FuncUI.Components.Hosts
    open Avalonia.FuncUI.Elmish

    type State =
        { 
          settings : Settings.Model
        
        }

    type DockPosn' = | Left | Right

    type Msg =
        | SettingsMsg of Settings.Msg
        | SummaryMsg of Summary.Msg
        | DockPosn of DockPosn'


    let init =
        let settings, _ = Settings.init

        { settings = settings },
        Cmd.none

    let update (msg: Msg) (state: State): State * Cmd<_> =
        match msg with
        | SettingsMsg msg ->
            let m, _ =
                Settings.update msg state.settings

            { state with settings = m }
            ,Cmd.none
        | _ -> 
            state, Cmd.none

    let view (state: State) dispatch =
        let dockPosn =
            if state.settings.SidebarPosn = Settings.Left then
                Dock.Left
            else
                Dock.Right
        let tabs = 
            TabControl.create [
                TabControl.tabStripPlacement dockPosn
                TabControl.viewItems [
                    TabItem.create [                            
                        TabItem.header "Summary"
                        TabItem.content (Summary.view () (SummaryMsg >> dispatch)) 
                    ]
                    TabItem.create [
                        TabItem.verticalAlignment VerticalAlignment.Bottom
                        TabItem.header "Settings"
                        TabItem.content (Settings.view state.settings (SettingsMsg >> dispatch)) 
                    ]
                ]
            ] 
        DockPanel.create [
            DockPanel.children [ tabs ]
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
