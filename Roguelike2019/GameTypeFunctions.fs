﻿module GameTypeFunctions

open GameTypes

let MoveEntity entity (dx, dy) = { entity with X = entity.X + dx; Y = entity.Y + dy }

let InitTile _ = { Blocked = false; BlockSight = false; }

let InitGameMap width height = { Width = width; Height = height; Tiles = List.init (width * height) InitTile }

let CoordinateToIndex width x y = 
    x + (y * width)

let IndexToCoordinate width i = 
    (i % width, i / width)

let SetTile newTile i tiles = 
    List.mapi (fun i2 originalTile -> if i = i2 then newTile else originalTile) tiles

let SetGameMapTile newTile i gameMap = 
    { gameMap with Tiles = SetTile newTile i gameMap.Tiles }
    

