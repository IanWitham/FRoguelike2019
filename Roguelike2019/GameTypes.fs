module GameTypes

type Tile = { Blocked: bool; BlockSight: bool }

type GameMap = { Tiles: Tile [,]; Width: int; Height: int; }

type Entity = {
    Position : (int * int);
    Char : char;
    Color : Microsoft.Xna.Framework.Color;
    }

type World = {
    Player : Entity;
    Npcs : Entity list;
    GameMap : GameMap;
}