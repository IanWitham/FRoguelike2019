// Learn more about F# at http://fsharp.org

open System
open SadConsole
open Microsoft.Xna.Framework
open Microsoft.Xna.Framework.Graphics
open InputHandlers

//let Console = SadConsole.Console

let width = 80
let height = 25

let playerChar = '@'

let mutable playerPosition = (width / 2, height / 2)

let kb = new SadConsole.Input.Keyboard()



//let Init() : unit = 
//    // Any startup code for your game. We will use an example console for now

let Update (gt : GameTime) : unit = 
    kb.Update(gt)
    let keyList = List.ofSeq kb.KeysPressed
    playerPosition <- handleKeys keyList playerPosition

let Draw (gt : GameTime) : unit =
    let startingConsole = SadConsole.Global.CurrentScreen;
    let playerX, playerY = playerPosition
    startingConsole.Fill(System.Nullable(Color.White), System.Nullable(Color.Black), System.Nullable(0)) |> ignore
    startingConsole.SetGlyph(playerX, playerY, (int) playerChar)

[<EntryPoint>]
let main argv =
    SadConsole.Game.Create(width, height)    

    //SadConsole.Game.OnInitialize <- new Action(Init)
    SadConsole.Game.OnUpdate <- new Action<GameTime>(Update)
    SadConsole.Game.OnDraw <- new Action<GameTime>(Draw)
            
    // Start the game.
    SadConsole.Game.Instance.Run();
    SadConsole.Game.Instance.Dispose();

    printfn "Hello World from F#! %d" width
    0 // return an integer exit code

