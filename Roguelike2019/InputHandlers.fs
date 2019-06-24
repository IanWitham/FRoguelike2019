module InputHandlers

open System
open Microsoft.Xna.Framework.Input

open InputTypes
open GameTypes
open GameTypeFunctions
open SadConsole.Input

let GetCommand (keysDown : AsciiKey list) (key : AsciiKey) =
    let getKey (ak : AsciiKey) = ak.Key
    let asciiKeysDown = List.map getKey keysDown
    match getKey key with
    | Keys.Left ->      Some <| Move { DX = (-1); DY = 0 }
    | Keys.Right ->     Some <| Move { DX = 1; DY = 0 }
    | Keys.Up ->        Some <| Move { DX = 0; DY = (-1) }
    | Keys.Down ->      Some <| Move { DX = 0; DY = 1 }
    | Keys.Escape ->    Some Quit
    | Keys.F5 when List.contains Keys.LeftAlt asciiKeysDown -> Some ToggleFullScreen
    | _ -> None
