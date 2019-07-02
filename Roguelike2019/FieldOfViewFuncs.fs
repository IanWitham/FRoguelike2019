module FieldOfView

open GameTypes
open MapTypes

let private transformOctant row col octant =
    match octant with
    | 0 -> ( col, -row )
    | 1 -> ( row, col )
    | 2 -> ( row, col )
    | 2 -> ( row, col )

type private octantDefinition = {
    direction:(int * int)
    range:(int * int)
}



let Octant maxDistance = 
    List.map (fun y -> List.map (fun x -> (x, y)) [0..y]) [0..maxDistance]

let OctantTransforms =
    [
        fun (x, y) -> (x, -y)
        fun (x, y) -> (-x, -y)
        fun (x, y) -> (-y, x)
        fun (x, y) -> (-y, -x)
        fun (x, y) -> (-x, y)
        fun (x, y) -> (x, y)
        fun (x, y) -> (y, -x)
        fun (x, y) -> (y, x)
    ]

let Octants maxDistance = 
    List.map (fun transform -> List.map (List.map transform) (Octant maxDistance)) OctantTransforms
    

    