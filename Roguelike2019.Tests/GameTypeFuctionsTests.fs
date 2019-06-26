module ``GameTypeFunctions Tests``

open System
open Xunit
open Microsoft.Xna.Framework
open GameTypes
open GameTypeFunctions

[<Fact>]
let ``My test`` () =
    Assert.True(true)

[<Fact>]
let ``InitTile test`` () =
    let tile = InitTile 0 0
    Assert.Equal({ Blocked = false; BlockSight = false }, tile)

[<Fact>]
let ``InitTile test 2`` =    
    let tile = InitTile 4 7
    Assert.Equal({ Blocked = false; BlockSight = false }, tile)    

[<Fact>]
let ``InitGameMap test`` () =
    let gameMap = InitGameMap 3 2
    Assert.Equal({
        Width = 3;
        Height = 2;
        Tiles = 
        array2D [
                [ InitTile 0 0; InitTile 1 0; InitTile 2 0 ]
                [ InitTile 0 1; InitTile 1 1; InitTile 2 1 ] ]
        }, gameMap)

[<Fact>]
let ``Move horizontal test`` () =
    let entity = { Position=(0, 0); Char='&'; Color=Color.DarkSeaGreen }
    let tiles = array2D [[ { Blocked = false; BlockSight=false }; { Blocked = false; BlockSight=false } ]]
    let move = (1, 0)
    let movedEntity = MoveEntity tiles entity move
    Assert.Equal(
        { Position=(1, 0); Char='&'; Color=Color.DarkSeaGreen },
        movedEntity
        )

[<Fact>]
let ``Move vertical test`` () =
    let entity = { Position=(0, 0); Char='&'; Color=Color.DarkSeaGreen }
    let tiles = array2D [
            [ { Blocked = false; BlockSight=false } ]
            [ { Blocked = false; BlockSight=false } ]]
    let move = (0, 1)
    let movedEntity = MoveEntity tiles entity move
    Assert.Equal(
        { Position=(0, 1); Char='&'; Color=Color.DarkSeaGreen },
        movedEntity
        )        

