module DrawingFunctions

open GameTypes

let DrawEntity (console : SadConsole.Console) entity =
    console.SetGlyph(entity.X, entity.Y, (int) entity.Char, entity.Color)

let TileColor tile =
    match tile with
    | { Blocked = true } -> Colors.DarkWall
    | _ -> Colors.DarkGround

let DrawTile y x tile =
    SadConsole.Global.CurrentScreen.SetBackground(x, y, TileColor tile)