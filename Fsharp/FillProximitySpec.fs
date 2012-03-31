module MinesweeperKata.FillProximitySpec

open NaturalSpec
open Minesweeper
open System

[<Scenario>]
let ``When filling proximity for one row``() =
  Given (1, 1, 3, ["*.."])
    |> When fillProximity
    |> It should equal ("Field #1\n" + "*10")
    |> Verify

[<Scenario>]
let ``When filling proximity for two rows``() =
  Given (1, 2, 3, ["*..";"..."])
    |> When fillProximity
    |> It should equal ("Field #1\n" + "*10\n110")
    |> Verify