module GameTypeFunctions

open GameTypes

let MoveEntity (tiles : Tile [,]) entity (dx, dy) =
    try
        match tiles.[ entity.Y+dy, entity.X+dx ] with
        | { Blocked = false } -> { entity with X = entity.X + dx; Y = entity.Y + dy }
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
