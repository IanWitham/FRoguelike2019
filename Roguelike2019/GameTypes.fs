module GameTypes

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