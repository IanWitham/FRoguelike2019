module InputTypes

type Command = 
    | Move of ( int * int )
    | Quit 
    | ToggleFullScreen 
