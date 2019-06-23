module GameTypes

type Tile = { Blocked: bool; BlockSight: bool }

type GameMap = { Tiles: Tile list; Width: int; Height: int; }

type Entity = {
    X : int;
    Y : int;
    Char : char;
    Color : Microsoft.Xna.Framework.Color;
    }

type World = {
    Player : Entity;
    Npcs : Entity list;
}