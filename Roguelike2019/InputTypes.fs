module InputTypes

type Command = 
    | Move of GameTypes.Move
    | Quit 
    | ToggleFullScreen 
