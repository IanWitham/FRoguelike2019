// Learn more about F# at http://fsharp.org

open System
open SadConsole
open Microsoft.Xna.Framework
open Microsoft.Xna.Framework.Graphics
open Microsoft.Xna.Framework.Input

open GameTypes
open GameTypeFunctions

open InputTypes
open InputHandlers

//let Console = SadConsole.Console

let width = 80
let height = 25

let player = {X=width / 2; Y=height / 2; Char='@'; Color=Color.Red}
let testNpc = {X=10; Y=10; Char='D'; Color=Color.Green}

let gameMap =
    InitGameMap width 25
    |> SetGameMapTile { Blocked = true; BlockSight = true } (CoordinateToIndex 80 30 22) 
    |> SetGameMapTile { Blocked = true; BlockSight = true } (CoordinateToIndex 80 31 22) 
    |> SetGameMapTile { Blocked = true; BlockSight = true } (CoordinateToIndex 80 32 22) 

let mutable world = {
    Player = player
    Npcs = [testNpc]
    GameMap = gameMap
}

let kb = new SadConsole.Input.Keyboard()



//let Init() : unit = 
//    // Any startup code for your game. We will use an example console for now


let Update (gt : GameTime) : unit = 
    
    kb.Update(gt)
    let keysPressed = List.ofSeq kb.KeysPressed // ofSeq converts Enumerable to F# List type
    let keysDown = List.ofSeq kb.KeysDown;
    
    // Only handle one keypress per update. Is this a problem? ¯\_(ツ)_/¯
    // Also pass in keysDown to check for modifiers
    let command =
        if keysPressed.IsEmpty then None
        else GetCommand keysDown keysPressed.Head

    // Some commands change the world state, some don't
    match command with
    | Some (Move m)         -> world <- { world with Player = MoveEntity world.Player m }
    | Some Quit             -> SadConsole.Game.Instance.Exit()
    | Some ToggleFullScreen -> SadConsole.Settings.ToggleFullScreen()
    | None                  -> () // return unit (i.e. do nothing)

let DrawTile width i tile =
    let tileColor = match tile with
    | { BlockSight = true } -> Colors.DarkWall
    | _ -> Colors.DarkGround
    let (x, y) = IndexToCoordinate width i
    SadConsole.Global.CurrentScreen.SetBackground(x, y, tileColor)

let Draw (gt : GameTime) : unit =

    let console = SadConsole.Global.CurrentScreen;

    console.Fill(System.Nullable(), System.Nullable(), System.Nullable(0)) |> ignore

    List.iteri (DrawTile world.GameMap.Width) world.GameMap.Tiles

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

