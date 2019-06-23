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