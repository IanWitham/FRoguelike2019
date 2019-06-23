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