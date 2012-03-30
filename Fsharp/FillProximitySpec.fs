module MinesweeperKata.FillProximitySpec

open NaturalSpec
open Minesweeper
open System

[<Scenario>]
let ``When filling proximity for one row``() =
  Given (1, 1, 3, "*..")
    |> When fillProximity
    |> It should equal ("Field #1\n" + "*10")
    |> Verify