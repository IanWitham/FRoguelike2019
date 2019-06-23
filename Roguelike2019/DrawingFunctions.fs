module DrawingFunctions

open GameTypes

let drawEntity (console : SadConsole.Console) entity = console.SetGlyph(entity.X, entity.Y, (int) entity.Char, entity.Color)
