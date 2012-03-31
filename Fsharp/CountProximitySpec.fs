module MinesweeperKata.CountProximitySpec

open NaturalSpec
open Minesweeper
open System

[<Scenario>]
let ``When counting proximity for one row``() =
  Given (0, "*..", ["*.."])
    |> When countProximity
    |> It should equal "*10"
    |> Verify

