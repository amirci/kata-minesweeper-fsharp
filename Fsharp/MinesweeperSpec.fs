module MinesweeperKata.MinesweeperSpec

open NaturalSpec
open Minesweeper

let minesweeping (fields: string) =
    printMethod ""
    minesweep(fields)

[<Scenario>]
let ``Should work with one row``() =
  Given "1 3\n*.."
    |> When minesweeping           
    |> It should equal ["Field #1"; "*10" ]
    |> Verify                       