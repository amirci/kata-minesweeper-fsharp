module MinesweeperKata.Minesweeper

open System

let parseFieldSize(header:string) =
    match (header.Split ' ' |> Array.toList) with
    | [] -> (0, 0)
    | [_] -> (0, 0)
    | a::b::_ -> (Int32.Parse a, Int32.Parse b)
        

let countProximity(row, line, mineField) =
    let neighbours x y = 
        [1; 2; 3]

    let mapete col c =
        match c with
        | '.' -> List.sum(neighbours row col).ToString().Chars(0)
        | _   -> c

    line |> String.mapi(mapete)

let fillProximity(counter:int, rows, cols, mineField) =
    let header = String.Format("Field #{0}", counter) 
    let output = mineField |> List.mapi (fun row line -> countProximity(row, line, mineField))
    header :: output |> String.concat "\n"


let rec createOutput(counter, lines) =
    match lines with
    | [] -> []
    | "0 0"::tail -> createOutput(counter + 1, tail)
    | head::tail -> 
        let (rows, cols) = parseFieldSize head
        let inputField = tail |> Seq.take(rows) |> Seq.toList
        let theRest = tail |> Seq.skip(rows) |> Seq.toList
        fillProximity(counter, rows, cols, inputField) :: createOutput(counter + 1, theRest)

let minesweep (fields:string) = 
    fields.Split('\n') 
        |> Array.toList
        |> fun l -> createOutput(1, l)
        |> String.concat "\n"
        
    


