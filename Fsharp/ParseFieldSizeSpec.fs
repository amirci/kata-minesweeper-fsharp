module MinesweeperKata.ParseFieldSizeSpec

open NaturalSpec
open Minesweeper
open System

[<ScenarioTemplate("3 4", 3, 4)>]
[<ScenarioTemplate("9899 769", 9899, 769)>]
[<ScenarioTemplate("0 0", 0, 0)>]
let ``When parsing valid field sizes with`` (input, e1, e2) =
  Given input
    |> When parseFieldSize
    |> It should equal (e1, e2)
    |> Verify

[<Scenario>]
let ``Should return zero if empty``() =
  Given ""
    |> When parseFieldSize
    |> It should equal (0, 0)
    |> Verify

[<Scenario>]
let ``Should return zero if has only one element``() =
  Given "3"
    |> When parseFieldSize
    |> It should equal (0, 0)
    |> Verify

[<Scenario>]
let ``Should ignore the rest of the elements``() =
  Given "3 9 16 21"
    |> When parseFieldSize
    |> It should equal (3, 9)
    |> Verify
