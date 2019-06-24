module InputHandlers

open Microsoft.Xna.Framework.Input
open InputTypes

let GetCommand keysDown keyPressed =
    match keyPressed with
    | Keys.Left ->      Some <| Move (-1, 0)
    | Keys.Right ->     Some <| Move (1, 0)
    | Keys.Up ->        Some <| Move (0, -1)
    | Keys.Down ->      Some <| Move (0, 1)
    | Keys.Escape ->    Some Quit
    | Keys.F5 when List.contains Keys.LeftAlt keysDown -> Some ToggleFullScreen
    | _ -> None
