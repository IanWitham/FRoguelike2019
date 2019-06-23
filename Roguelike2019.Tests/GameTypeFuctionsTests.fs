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
    let tile = InitTile 0
    Assert.Equal({ Blocked = false; BlockSight = false }, tile)

[<Fact>]
let ``InitGameMap test`` () =
    let gameMap = InitGameMap 3 2
    Assert.Equal({
        Width = 3;
        Height = 2;
        Tiles = [ InitTile 0; InitTile 1; InitTile 2; InitTile 3; InitTile 4; InitTile 5; ]
        }, gameMap)

[<Fact>]
let ``CoordinateToIndex test`` () = 
    Assert.Equal(4, CoordinateToIndex 3 1 1)
    Assert.Equal(18, CoordinateToIndex 13 5 1)

[<Fact>]
let ``SetTile test`` () =
    let tiles = [
        { Blocked = true; BlockSight = true }
        { Blocked = true; BlockSight = false }
        { Blocked = false; BlockSight = true }
    ]
    let actual = SetTile tiles { Blocked = false; BlockSight = false } 1
    Assert.Equal({ Blocked = true; BlockSight = true }, actual.[0])
    Assert.Equal({ Blocked = false; BlockSight = false }, actual.[1])
    Assert.Equal({ Blocked = false; BlockSight = true }, actual.[2])

[<Fact>]
let ``Move test`` () =
    let entity = { X=0; Y=0; Char='&'; Color=Color.DarkSeaGreen }
    let movedEntity = Move entity 10 20
    Assert.Equal(
        {X=10; Y=20; Char='&'; Color=Color.DarkSeaGreen },
        movedEntity
        )

[<Fact>]
let ``Move test 2`` () =
    let entity = { X=89; Y=4; Char='='; Color=Color.Chartreuse }
    let movedEntity = Move entity (-3) (-40)
    Assert.Equal(
        {X=86; Y=(-36); Char='='; Color=Color.Chartreuse },
        movedEntity
        )