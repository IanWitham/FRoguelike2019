module InputHandlers

open System
open Microsoft.Xna.Framework.Input

let folder (playerX, playerY) (key : SadConsole.Input.AsciiKey) =
    match key.Key with
        | Keys.Left -> (playerX - 1, playerY)
        | Keys.Right -> (playerX + 1, playerY)
        | Keys.Up -> (playerX, playerY - 1)
        | Keys.Down -> (playerX, playerY + 1)
        | Keys.None -> (playerX, playerY)

let handleKeys keys gameState =
    List.fold folder gameState keys


