module DrawingFunctions

open GameTypes

let ClearEntity (console : SadConsole.Console) { Position = (x, y); Char = char; Color = color } =
    console.SetGlyph(x, y, 0)

let DrawEntity (console : SadConsole.Console) { Position = (x, y); Char = char; Color = color } =
    console.SetGlyph(x, y, (int) char, color)

let TileColor tile =
    match tile with
    | { Blocked = true } -> Colors.DarkWall
    | _ -> Colors.DarkGround

let DrawTile (console : SadConsole.Console) y x tile =
    match tile with
    | { Blocked = true } ->
        console.SetGlyph(x, y, 1, Microsoft.Xna.Framework.Color.White, TileColor tile)
    | { Blocked = false } -> 
        console.SetGlyph(x, y, (int) '.', Microsoft.Xna.Framework.Color.White, TileColor tile)
