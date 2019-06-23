// Learn more about F# at http://fsharp.org

open System
open SadConsole
open Microsoft.Xna.Framework
open Microsoft.Xna.Framework.Graphics
open Microsoft.Xna.Framework.Input

open GameTypes

open InputHandlers

//let Console = SadConsole.Console

let width = 80
let height = 25

let player = {X=width / 2; Y=height / 2; Char='@'; Color=Color.Red}
let testNpc = {X=10; Y=10; Char='D'; Color=Color.Green}

let mutable world = {
    Player = player;
    Npcs = [testNpc]
}

let kb = new SadConsole.Input.Keyboard()



//let Init() : unit = 
//    // Any startup code for your game. We will use an example console for now


let Update (gt : GameTime) : unit = 
    kb.Update(gt)
    let keyList = List.ofSeq kb.KeysPressed
    
    // Handle fullscreen toggle outside of the gamestate type.
    // I.e. it's not a "state" that should be saved with the game.
    if SadConsole.Global.KeyboardState.IsKeyPressed(Keys.Enter) && SadConsole.Global.KeyboardState.IsKeyDown(Keys.LeftAlt)
        then SadConsole.Settings.ToggleFullScreen() |> ignore

    world <- handleKeys world keyList

let Draw (gt : GameTime) : unit =

    let console = SadConsole.Global.CurrentScreen;

    kb.Update(gt)
    if SadConsole.Global.KeyboardState.IsKeyPressed(Keys.Escape)
        then SadConsole.Game.Instance.Exit() |> ignore

    console.Fill(System.Nullable(Color.White), System.Nullable(Color.Black), System.Nullable(0)) |> ignore

    let drawEntity = DrawingFunctions.drawEntity console

    // Render Npcs
    List.iter drawEntity world.Npcs 

    // Render player
    drawEntity world.Player |> ignore

[<EntryPoint>]
let main argv =
    SadConsole.Game.Create(width, height)    

    SadConsole.Settings.UseHardwareFullScreen <- false

    //SadConsole.Game.OnInitialize <- new Action(Init)
    SadConsole.Game.OnUpdate <- new Action<GameTime>(Update)
    SadConsole.Game.OnDraw <- new Action<GameTime>(Draw)
            
    // Start the game.
    SadConsole.Game.Instance.Run();
    SadConsole.Game.Instance.Dispose();

    printfn "Hello World from F#! %d" width
    0 // return an integer exit code

