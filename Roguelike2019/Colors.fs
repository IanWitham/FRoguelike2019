module Colors

open Microsoft.Xna.Framework

let ColorFromInt (i : int) = Color( i >>> 16 &&& 255, i >>> 8 &&& 255, i &&& 255)

let Black = ColorFromInt 0x000000
let DarkGrey = ColorFromInt 0x626262
let MidGrey = ColorFromInt 0x898989
let LightGrey = ColorFromInt 0xadadad
let White = ColorFromInt 0xffffff
let Red = ColorFromInt 0x9f4e44
let LightRed = ColorFromInt 0xcb7e75
let Brown = ColorFromInt 0x6d5412
let LightBrown = ColorFromInt 0xa1683c
let Yellow = ColorFromInt 0xc9d487
let LightGreen = ColorFromInt 0x9ae29b
let Green = ColorFromInt 0x5cab5e
let Cyan = ColorFromInt 0x6abfc6
let LightBlue = ColorFromInt 0x887ecb
let Blue = ColorFromInt 0x50459b
let Magenta = ColorFromInt 0xa057a3

let DarkWall = Blue
let DarkGround = LightBlue
