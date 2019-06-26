module GameTypeFunctions

open GameTypes

let MoveEntity (tiles : Tile [,]) entity (dx, dy) =
    let (x, y) = entity.Position
    try
        match tiles.[ y+dy, x+dx ] with
        | { Blocked = false } -> { entity with Position = (x + dx, y + dy) }
        | _ -> entity
    with
    | :? System.IndexOutOfRangeException -> entity

let InitTile x y = { Blocked = false; BlockSight = false; }

let InitGameMap width height =
    {
        Width = width
        Height = height
        Tiles = Array2D.init height width InitTile
    }
