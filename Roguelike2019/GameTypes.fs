module GameTypes

type Entity = {
    Position : (int * int);
    Char : int;
    Color : Microsoft.Xna.Framework.Color;
    }

type World = {
    Player : Entity;
    Npcs : Entity list;
    GameMap : MapTypes.GameMap;
}