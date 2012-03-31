module MinesweeperKata.Minesweeper

open System

let parseFieldSize(header:string) =
    match (header.Split ' ' |> Array.toList) with
    | [] -> (0, 0)
    | [_] -> (0, 0)
    | a::b::_ -> (Int32.Parse a, Int32.Parse b)
        

let countProximity(row, line: string, mineField: list<string>) =
    let explosive c = if c = '*' then 1 else 0
    let neighbours x y = 
        [(x-1, y-1); (x-1, y); (x-1, y+1); 
         (x, y-1); (x, y+1); 
         (x+1, y-1); (x+1, y); (x+1, y+1)]
            |> List.filter (fun (a , b) -> a >= 0 && b >= 0 && a < mineField.Length && b < line.Length )
            |> List.map (fun (a, b) -> mineField.Item(a).Chars(b) |> explosive)
            |> List.sum

    let mapete col c = if c = '.' then (neighbours row col).ToString().Chars(0) else c

    String.mapi mapete line 

let fillProximity(counter:int, rows, cols, mineField) =
    let header = String.Format("Field #{0}", counter) 
    let output = mineField |> List.mapi (fun row line -> countProximity(row, line, mineField))
    header :: output |> String.concat "\n"


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
        |> fun l -> createOutput 1 l
        |> String.concat "\n"
        
    


