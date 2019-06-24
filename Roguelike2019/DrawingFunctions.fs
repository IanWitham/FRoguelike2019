module DrawingFunctions

open GameTypes
open GameTypeFunctions

let drawEntity (console : SadConsole.Console) entity =
    console.SetGlyph(entity.X, entity.Y, (int) entity.Char, entity.Color)

let DrawTile width i tile =
    let tileColor = 
        match tile with
        | { BlockSight = true } -> Colors.DarkWall
        | _ -> Colors.DarkGround
    let (x, y) = IndexToCoordinate width i
    SadConsole.Global.CurrentScreen.SetBackground(x, y, tileColor)