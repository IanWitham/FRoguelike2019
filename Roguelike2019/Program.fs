// Learn more about F# at http://fsharp.org

open System
open Microsoft.Xna.Framework
open Microsoft.Xna.Framework.Graphics
open Microsoft.Xna.Framework.Input
open SadConsole.Input
open SadConsole

open GameTypes
open GameTypeFunctions
open InputTypes
open InputHandlers
open DrawingFunctions


let width = 40
let height = 25

let player = {
    Position=(width / 2, height / 2)
    Char='@'
    Color=Colors.Red
    }
let testNpc = {
    Position=(10, 10)
    Char='D'
    Color=Colors.Green
    }

let gameMap = InitGameMap width height
Array2D.set gameMap.Tiles 0 0 { Blocked = true; BlockSight = false }
Array2D.set gameMap.Tiles 0 1 { Blocked = true; BlockSight = false }
Array2D.set gameMap.Tiles 0 2 { Blocked = true; BlockSight = false }

let mutable world = {
    Player = player
    Npcs = [testNpc]
    GameMap = gameMap
}

let mutable mapConsole : SadConsole.Console = null

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
        let command = GetCommand keysDown keyPressed
        // Some commands change the world state, some don't
        match command with
        | Some (Move m)         ->
            // Clear player's existing position
            let (x, y) = world.Player.Position
            let (dx, dy) = m
            if not <| IsBlocked world.GameMap (x+dx) (y+dy)  then
                DrawTile mapConsole y x world.GameMap.Tiles.[y,x]
                world <- { world with Player = MoveEntity world.Player m }
                DrawEntity mapConsole world.Player
            else ()
        | Some Quit             -> SadConsole.Game.Instance.Exit()
        | Some ToggleFullScreen -> SadConsole.Settings.ToggleFullScreen()
        | None                  -> () // return unit (i.e. do nothing)

let Init () = 

    //let fontMaster = SadConsole.Global.LoadFont("Resources/c64_upp.font")
    //let font =  fontMaster.GetFont(Font.FontSizes.One)

    mapConsole <- SadConsole.Console(width, height)//, font)
    SadConsole.Global.CurrentScreen.Children.Add(mapConsole)
    // Render the map
    Array2D.iteri (DrawTile mapConsole) world.GameMap.Tiles
    List.iter (DrawEntity mapConsole) world.Npcs 
    // Make sure the entity layer is transparent
    DrawEntity mapConsole world.Player

// let Draw gameTime =
//     ()

[<EntryPoint>]
let main argv =

    SadConsole.Game.Create("Resources/c64_upp.font", width, height)    
    SadConsole.Settings.UseHardwareFullScreen <- false

    //SadConsole.Game.OnInitialize <- new Action(Init)
    SadConsole.Game.OnUpdate <- new Action<GameTime>(Update)
    //SadConsole.Game.OnDraw <- new Action<GameTime>(Draw)
    SadConsole.Game.OnInitialize <- new Action(Init)

    // Start the game.
    SadConsole.Game.Instance.Run();

    SadConsole.Game.Instance.Dispose();
    0 // return an integer exit code

