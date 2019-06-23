module GameTypeFunctions

open GameTypes

let Move entity dx dy = { entity with X = entity.X + dx; Y = entity.Y + dy }

let InitTile _ = { Blocked = false; BlockSight = false; }

let InitGameMap width height = { Width = width; Height = height; Tiles = List.init (width * height) InitTile }