module GameTypeFunctions

open GameTypes

let Move entity dx dy = { entity with X = entity.X + dx; Y = entity.Y + dy }

let InitTile _ = { Blocked = false; BlockSight = false; }

let InitGameMap width height = { Width = width; Height = height; Tiles = List.init (width * height) InitTile }

let CoordinateToIndex width x y = 
    (x % width) + (y * width)

let SetTile tiles newTile i = 
    List.mapi (fun i2 originalTile -> if i = i2 then newTile else originalTile) tiles
    

