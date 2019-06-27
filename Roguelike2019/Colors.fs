module Colors

open Microsoft.Xna.Framework

let ColorFromInt (i : int) = Color( i >>> 16 &&& 255, i >>> 8 &&& 255, i &&& 255)

let Black =         ColorFromInt 0x000000
let White =         ColorFromInt 0xffffff
let Red =           ColorFromInt 0x68372b
let Cyan =          ColorFromInt 0x70a4b2
let Purple =        ColorFromInt 0x6f3d86
let Green =         ColorFromInt 0x588d43
let Blue =          ColorFromInt 0x352879
let Yellow =        ColorFromInt 0xb8c76f
let Orange =        ColorFromInt 0x6f4f25
let Brown =         ColorFromInt 0x433900
let LightRed =      ColorFromInt 0x9A6759
let DarkGrey =      ColorFromInt 0x444444
let Grey =          ColorFromInt 0x6c6c6c
let LightGreen =    ColorFromInt 0x9ad284
let LightBlue =     ColorFromInt 0x6c5eb5
let LightGrey =     ColorFromInt 0x959595

let DarkWall = Blue
let DarkGround = LightBlue
