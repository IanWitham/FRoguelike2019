module ``GameTypeFunctions Tests``

open System
open Xunit
open Microsoft.Xna.Framework
open GameTypes
open GameTypeFunctions
open MapTypes
open MapFunctions

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
let ``Move horizontal test`` () =
    let entity = { Position=(0, 0); Char=(int)'&'; Color=Color.DarkSeaGreen }
    let tiles = array2D [[ { Blocked = false; BlockSight=false }; { Blocked = false; BlockSight=false } ]]
    let move = (1, 0)
    let movedEntity = MoveEntity entity move
    Assert.Equal(
        { Position=(1, 0); Char=(int)'&'; Color=Color.DarkSeaGreen },
        movedEntity
        )

[<Fact>]
let ``Move vertical test`` () =
    let entity = { Position=(0, 0); Char=(int)'&'; Color=Color.DarkSeaGreen }
    let tiles = array2D [
            [ { Blocked = false; BlockSight=false } ]
            [ { Blocked = false; BlockSight=false } ]]
    let move = (0, 1)
    let movedEntity = MoveEntity entity move
    Assert.Equal(
        { Position=(0, 1); Char=(int)'&'; Color=Color.DarkSeaGreen },
        movedEntity
        )        

