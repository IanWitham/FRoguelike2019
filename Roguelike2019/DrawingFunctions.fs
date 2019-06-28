module DrawingFunctions

open GameTypes
open MapTypes

let ClearEntity (console : SadConsole.Console) { Position = (x, y); Char = char; Color = color } =
    console.SetGlyph(x, y, 0)

let DrawEntity (console : SadConsole.Console) { Position = (x, y); Char = char; Color = color } =
    console.SetGlyph(x, y, char, color)

let TileColor tile =
    match tile with
    | { Blocked = true } -> Colors.DarkWall
    | _ -> Colors.DarkGround

let DrawTile (console : SadConsole.Console) y x tile =
    match tile with
    | { Blocked = true } ->
        console.SetGlyph(x, y, 32 * 7 + 6, TileColor tile, Colors.DarkGrey)
    | { Blocked = false } -> 
        console.SetGlyph(x, y, 46, TileColor tile, Colors.DarkGrey)
