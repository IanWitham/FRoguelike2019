module InputHandlers

open System
open Microsoft.Xna.Framework.Input

open GameTypes
open GameTypeFunctions
open SadConsole.Input

let folder world (key : AsciiKey) =
    match key.Key with
        | Keys.Left -> {world with Player = Move world.Player (-1) 0}
        | Keys.Right -> {world with Player = Move world.Player 1 0}
        | Keys.Up -> {world with Player = Move world.Player 0 (-1)}
        | Keys.Down -> {world with Player = Move world.Player 0 1}
        | _ -> world

let handleKeys world keys =
    List.fold folder world keys


