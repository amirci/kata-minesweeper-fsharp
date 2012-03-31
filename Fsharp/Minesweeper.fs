module MinesweeperKata.Minesweeper

open System

let parseFieldSize(header:string) =
    match (header.Split ' ' |> Array.toList) with
    | [] -> (0, 0)
    | [_] -> (0, 0)
    | a::b::_ -> (Int32.Parse a, Int32.Parse b)
        

let countProximity(row, line: string, mineField: list<string>) =
    let inRange (a, b) = a >= 0 && b >= 0 && a < mineField.Length && b < line.Length
    let explosive c = if c = '*' then 1 else 0
    let binaryExplosive (a, b) = mineField.Item(a).Chars(b) |> explosive

    let totalExplosiveNeighbours x y = 
        [(x-1, y-1); (x-1, y); (x-1, y+1); 
         (x, y-1); (x, y+1); 
         (x+1, y-1); (x+1, y); (x+1, y+1)]
            |> List.filter inRange
            |> List.map binaryExplosive
            |> List.sum
            |> (fun i -> i.ToString().Chars(0))

    let mapete col c = if c = '.' then (totalExplosiveNeighbours row col) else c

    String.mapi mapete line 

let fillProximity(counter:int, rows, cols, mineField) =
    let header = sprintf "Field #%d" counter
    let filled = mineField |> List.mapi (fun row line -> countProximity(row, line, mineField))
    header :: filled |> String.concat "\n"


let rec createOutput counter lines =
    match lines with
    | [] -> []
    | "0 0"::tail -> createOutput (counter + 1) tail
    | head::tail -> 
        let (rows, cols) = parseFieldSize head
        let inputField = tail |> Seq.take(rows) |> Seq.toList
        let theRest = tail |> Seq.skip(rows) |> Seq.toList
        fillProximity(counter, rows, cols, inputField) :: createOutput (counter + 1) theRest

let minesweep (fields:string) = 
    fields.Split('\n') 
        |> Array.toList
        |> createOutput 1
        |> String.concat "\n\n"
    

        
    


