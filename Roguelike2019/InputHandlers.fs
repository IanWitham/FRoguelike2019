module InputHandlers

open Microsoft.Xna.Framework.Input
open InputTypes
open GameTypes

let GetCommand keysDown keyPressed =
    match keyPressed with
    | Keys.Left ->      Some <| Move { DX = (-1); DY = 0 }
    | Keys.Right ->     Some <| Move { DX = 1; DY = 0 }
    | Keys.Up ->        Some <| Move { DX = 0; DY = (-1) }
    | Keys.Down ->      Some <| Move { DX = 0; DY = 1 }
    | Keys.Escape ->    Some Quit
    | Keys.F5 when List.contains Keys.LeftAlt keysDown -> Some ToggleFullScreen
    | _ -> None
