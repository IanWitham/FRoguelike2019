module MapTypes

type Tile = { Blocked: bool; BlockSight: bool }

type GameMap = { Tiles: Tile [,]; Width: int; Height: int; }

type Rect = 
    {
        X : int
        Y : int
        W : int
        H : int
    }


