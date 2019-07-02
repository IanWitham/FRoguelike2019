module GameTypeFunctions

open GameTypes
open MapTypes

let MoveEntity entity (dx, dy) =
    let (x, y) = entity.Position
    { entity with Position = (x + dx, y + dy) }

let IsBlocked (gameMap : MapTypes.GameMap) x y =
    y < 0
    || y > gameMap.Height - 1
    || x < 0
    || x > gameMap.Width - 1
    || gameMap.Tiles.[y,x].Blocked

