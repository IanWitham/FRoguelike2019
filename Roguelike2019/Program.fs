// Learn more about F# at http://fsharp.org

open System
open SadConsole
open Microsoft.Xna.Framework;
open Microsoft.Xna.Framework.Graphics;

//let Console = SadConsole.Console

let width = 80
let height = 25

let Init() : unit = 
    // Any startup code for your game. We will use an example console for now
    let startingConsole = SadConsole.Global.CurrentScreen;
    startingConsole.FillWithRandomGarbage();
    startingConsole.Fill (Rectangle (3, 3, 27, 5), System.Nullable(Color.Red), System.Nullable(Color.Black), System.Nullable(0), System.Nullable(SpriteEffects.None)) |> ignore
    startingConsole.Print(6, 5, "Hello from SadConsole", ColorAnsi.CyanBright);

[<EntryPoint>]
let main argv =
    SadConsole.Game.Create(width, height)    

    // Hook the start event so we can add consoles to the system.
    SadConsole.Game.OnInitialize <- new Action(Init);
            
    // Start the game.
    SadConsole.Game.Instance.Run();
    SadConsole.Game.Instance.Dispose();
    printfn "Hello World from F#! %d" width
    0 // return an integer exit code

