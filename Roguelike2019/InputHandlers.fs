module InputHandlers

open System
open Microsoft.Xna.Framework.Input

open GameTypes
open GameTypeFunctions
open SadConsole.Input

let folder world (key : AsciiKey) =

    let movePlayer dx dy = {world with Player = Move world.Player dx dy}

    match key.Key with
        | Keys.Left -> movePlayer (-1) 0
        | Keys.Right -> movePlayer 1 0
        | Keys.Up -> movePlayer 0 (-1)
        | Keys.Down -> movePlayer 0 1
        | _ -> world

let handleKeys world keys =
    List.fold folder world keys


