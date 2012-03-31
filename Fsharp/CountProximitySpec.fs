module MinesweeperKata.CountProximitySpec

open NaturalSpec
open Minesweeper
open System

[<Scenario>]
let ``When counting proximity for first row``() =
  Given (0, "*..", ["*.."])
    |> When countProximity
    |> It should equal "*10"
    |> Verify

[<Scenario>]
let ``When counting proximity for second row``() =
  Given (1, ".*.", ["*.."; ".*."])
    |> When countProximity
    |> It should equal "2*1"
    |> Verify

[<Scenario>]
let ``When counting proximity for the third row``() =
  Given (2, "**..", ["*..*"; 
                     ".*.."; 
                     "**.."])
    |> When countProximity
    |> It should equal "**20"
    |> Verify
