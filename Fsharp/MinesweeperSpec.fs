module MinesweeperKata.MinesweeperSpec

open NaturalSpec
open Minesweeper
open System

let minesweeping (fields: string) =
    printMethod ""
    minesweep(fields)

[<Scenario>]
let ``When passing one row``() =
  Given "1 3\n*.."
    |> When minesweeping           
    |> It should equal (["Field #1"; "*10" ] |> String.concat "\n")
    |> Verify                       


[<Scenario>]
let ``When passing two rows``() =
  Given "2 3\n*..\n*.."
    |> When minesweeping           
    |> It should equal (["Field #1"; "*20"; "*20" ] |> String.concat "\n")
    |> Verify                       

