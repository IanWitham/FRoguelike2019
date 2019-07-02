module MapFunctions

open MapTypes

let private WallTile = { Blocked = true; BlockSight = true; Visible = false; Explored = false }
let private OpenTile = { Blocked = false; BlockSight = false; Visible = false; Explored = false }

let CreateRoom gameMap rect =
    let length1 = rect.H - 2
    let length2 = rect.W - 2
    // define an open rectangle
    let roomTiles : Tile [,] =
        Array2D.create 
            length1
            length2
            OpenTile
    // copy to the map
    Array2D.blit
        roomTiles
        0 0
        gameMap.Tiles
        (rect.Y + 1) (rect.X + 1)
        length1 length2

let CreateHTunnel gameMap x1 x2 y =
    for x in [x1..x2] do
        gameMap.Tiles.[y,x] <- OpenTile

let CreateVTunnel gameMap y1 y2 x = 
    for y in [y1..y2] do
        gameMap.Tiles.[y,x] <- OpenTile

let RectCenter rect =
    (rect.X + rect.W / 2, rect.Y + rect.H / 2)

let RectsOverlap (rect1 : Rect) (rect2 : Rect) =
    rect1.X <= rect2.X + rect2.W
    && rect2.X <= rect1.X + rect1.W
    && rect1.Y <= rect2.Y + rect2.H
    && rect2.Y <= rect1.Y + rect1.H

let RandomRoom (rnd : System.Random) roomMinSize roomMaxSize mapWidth mapHeight i =
    let w = rnd.Next(roomMinSize, roomMaxSize + 1)
    let h = rnd.Next(roomMinSize, roomMaxSize + 1)
    let x = rnd.Next(0, mapWidth - w)
    let y = rnd.Next(0, mapHeight - h)
    { X = x; Y = y; W = w; H = h }

//let private roomFolder (rooms : Rect list) randomRoom =
//    // accumulates a list of non overlapping rooms
//    let roomSource2 = Seq.skipWhile (fun randRoom -> List.exists (RectsOverlap randRoom) rooms ) roomSource
//    let (roomSourceHead, roomSourceTail) = (Seq.head roomSource2, Seq.tail roomSource2)
//    (roomSourceTail, roomSourceHead :: rooms)

let rec private filterOutOverlaps (rooms : Rect list) =
    match rooms with
    | x :: xs -> x :: (filterOutOverlaps <| List.filter (RectsOverlap x >> not) xs)
    | [] -> []

let private joinRooms gameMap (rnd : System.Random) (r1, r2) =
    let x1, y1 = RectCenter r1
    let x2, y2 = RectCenter r2
    match rnd.Next(1) with
    | 0 ->
        CreateHTunnel gameMap x1 x2 y1
        CreateVTunnel gameMap y1 y2 x2
    | _ ->
        CreateVTunnel gameMap y1 y2 x2
        CreateHTunnel gameMap x1 x2 y1

let InitGameMap maxRoomTries roomMinSize roomMaxSize mapWidth mapHeight =
    let tiles = Array2D.create mapHeight mapWidth WallTile
    let rng = System.Random()
    let gameMap = { Tiles = tiles; Width = mapWidth; Height = mapHeight; }

    // create no more than maxRoomTries non-overlapping random rooms    
    let rooms =
        List.init maxRoomTries (RandomRoom rng roomMinSize roomMaxSize mapWidth mapHeight)
        |> filterOutOverlaps
    
    List.iter (fun r -> CreateRoom gameMap r ) rooms

    // create corridors
    List.pairwise rooms |> List.iter (joinRooms gameMap rng)

    (gameMap, RectCenter <| List.head rooms)
