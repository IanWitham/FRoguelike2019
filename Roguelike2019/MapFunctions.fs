module MapFunctions

open MapTypes

let CreateRoom gameMap rect =
    let length1 = rect.H - 2
    let length2 = rect.W - 2
    // define an open rectangle
    let roomTiles : Tile [,] =
        Array2D.create 
            length1
            length2
            { Blocked = false; BlockSight = false; }
    // copy to the map
    Array2D.blit
        roomTiles
        0 0
        gameMap.Tiles
        (rect.Y + 1) (rect.X + 1)
        length1 length2

let CreateHTunnel gameMap x1 x2 y =
    for x in [x1..x2] do
        gameMap.Tiles.[y,x] <- { Blocked = false; BlockSight = false; }

let CreateVTunnel gameMap y1 y2 x = 
    for y in [y1..y2] do
        gameMap.Tiles.[y,x] <- { Blocked = false; BlockSight = false; }

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

let private roomFolder (roomSource : Rect seq, rooms : Rect list) i =
    let roomSource2 = Seq.skipWhile (fun randRoom -> List.exists (RectsOverlap randRoom) rooms ) roomSource
    let (roomSourceHead, roomSourceTail) = (Seq.head roomSource2, Seq.tail roomSource2)
    (roomSourceTail, roomSourceHead :: rooms)

let InitGameMap maxRooms roomMinSize roomMaxSize mapWidth mapHeight =
    let tiles = Array2D.create mapHeight mapWidth { Blocked=true; BlockSight=true }
    let rnd = System.Random()
    let gameMap = { Tiles = tiles; Width = mapWidth; Height = mapHeight; }

    let infiniteRooms = Seq.initInfinite <| RandomRoom rnd roomMinSize roomMaxSize mapWidth mapHeight

    let (_, rooms) = Seq.fold roomFolder (infiniteRooms, []) (seq { 1 .. maxRooms })

    List.iter (fun r -> CreateRoom gameMap r ) rooms
    gameMap
