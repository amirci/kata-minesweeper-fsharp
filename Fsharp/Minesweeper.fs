module MinesweeperKata.Minesweeper

open System

let parseFieldSize(header:string) =
    (1, 3)

let fillProximity(rows, cols, mineField) =
    "*10"

let rec createOutput(lines, outputCount:int) =
    match lines with
    | [] -> []
    | "0 0"::tail -> createOutput(tail, outputCount + 1)
    | head::tail -> 
        let (rows, cols) = parseFieldSize head
        let inputField = tail |> Seq.take(rows) |> Seq.toList
        let theRest = tail |> Seq.skip(rows) |> Seq.toList
        String.Format("Field #{0}", outputCount) :: fillProximity(rows, cols, inputField) :: createOutput(theRest, outputCount + 1)


let minesweep (fields:string) = createOutput(fields.Split('\n') |> Array.toList, 1)
    


