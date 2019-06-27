module GameTypeFunctions

open GameTypes

let MoveEntity entity (dx, dy) =
    let (x, y) = entity.Position
    { entity with Position = (x + dx, y + dy) }

let InitTile x y = { Blocked = true; BlockSight = true; }

let InitGameMap width height =
    {
        Width = width
        Height = height
        Tiles = Array2D.init height width InitTile
    }

let IsBlocked (gameMap : GameMap) x y =
    y < 0
    || y > gameMap.Height - 1
    || x < 0
    || x > gameMap.Width - 1
    || gameMap.Tiles.[y,x].Blocked

