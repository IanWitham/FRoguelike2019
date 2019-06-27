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
open MapTypes
open MapFunctions


let screenWidth = 40
let screenHeight = 25

let mapWidth = 80
let mapHeight = 40

let roomMinSize = 6
let roomMaxSize = 10
let maxRooms = 30

let player = {
    Position=(21, 16)
    Char=0
    Color=Colors.Red
    }
let testNpc = {
    Position=(10, 10)
    Char=0
    Color=Colors.Green
    }

let gameMap = InitGameMap maxRooms roomMinSize roomMaxSize mapWidth mapHeight 

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
                mapConsole.Position <- Point((screenWidth/2) - (x+dx), (screenHeight / 2) - (y+dy))
            else ()
        | Some Quit             -> SadConsole.Game.Instance.Exit()
        | Some ToggleFullScreen -> SadConsole.Settings.ToggleFullScreen()
        | None                  -> () // return unit (i.e. do nothing)



let Init () = 

    //let fontMaster = SadConsole.Global.LoadFont("Resources/c64_upp.font")
    //let font =  fontMaster.GetFont(Font.FontSizes.One)

    mapConsole <- SadConsole.Console(mapWidth, mapHeight)//, font)
    SadConsole.Global.CurrentScreen.Children.Add(mapConsole)
    // Render the map
    Array2D.iteri (DrawTile mapConsole) world.GameMap.Tiles
    List.iter (DrawEntity mapConsole) world.Npcs 
    // Make sure the entity layer is transparent
    DrawEntity mapConsole world.Player

    // center the player
    let (x, y) = world.Player.Position
    mapConsole.Position <- Point((screenWidth/2) - x, (screenHeight / 2) - y)

// let Draw gameTime =
//     ()

[<EntryPoint>]
let main argv =

    SadConsole.Game.Create("Resources/c64_upp.font", screenWidth, screenHeight)    
    SadConsole.Settings.UseHardwareFullScreen <- false

    //SadConsole.Game.OnInitialize <- new Action(Init)
    SadConsole.Game.OnUpdate <- new Action<GameTime>(Update)
    //SadConsole.Game.OnDraw <- new Action<GameTime>(Draw)
    SadConsole.Game.OnInitialize <- new Action(Init)

    // Start the game.
    SadConsole.Game.Instance.Run();

    SadConsole.Game.Instance.Dispose();
    0 // return an integer exit code

