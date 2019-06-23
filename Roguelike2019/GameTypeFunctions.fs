module GameTypeFunctions

let Move (entity : GameTypes.Entity) dx dy = { entity with X = entity.X + dx; Y = entity.Y + dy }


