// Learn more about F# at http://fsharp.org

open System
open Microsoft.Xna.Framework
open Microsoft.Xna.Framework.Graphics
open Microsoft.Xna.Framework.Input
open SadConsole.Input

open GameTypes
open GameTypeFunctions
open InputTypes
open InputHandlers
open DrawingFunctions


let width = 80
let height = 25

let player = {X=width / 2; Y=height / 2; Char='@'; Color=Color.Red}
let testNpc = {X=10; Y=10; Char='D'; Color=Color.Green}

let gameMap = InitGameMap width height
Array2D.set gameMap.Tiles 0 0 { Blocked = true; BlockSight = false }
Array2D.set gameMap.Tiles 0 1 { Blocked = true; BlockSight = false }
Array2D.set gameMap.Tiles 0 2 { Blocked = true; BlockSight = false }

let mutable world = {
    Player = player
    Npcs = [testNpc]
    GameMap = gameMap
}

let kb = SadConsole.Input.Keyboard()

let Update gameTime = 
    // Get the key presses for this update cycle
    kb.Update(gameTime)
    let keysDown =
        List.ofSeq kb.KeysDown
        |> List.map (fun x -> x.Key)
    let keysPressed =
        List.ofSeq kb.KeysPressed
        |> List.map (fun x -> x.Key)
    
    for keyPressed in keysPressed do
        
        printfn "KeyPressed! %A" keyPressed

        let command = GetCommand keysDown keyPressed
        // Some commands change the world state, some don't
        match command with
        | Some (Move m)         -> world <- { world with Player = MoveEntity world.GameMap.Tiles world.Player m }
        | Some Quit             -> SadConsole.Game.Instance.Exit()
        | Some ToggleFullScreen -> SadConsole.Settings.ToggleFullScreen()
        | None                  -> () // return unit (i.e. do nothing)

let Draw gameTime =

    let console = SadConsole.Global.CurrentScreen;

    console.Fill(System.Nullable(), System.Nullable(), System.Nullable(0)) |> ignore

    // Render the map
    Array2D.iteri DrawTile world.GameMap.Tiles

    let drawEntity = DrawEntity console
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
    0 // return an integer exit code

