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

[<Scenario>]
let ``When passing suggested cases``() =
  let expected = ["Field #1"; 
                  "*100"    ; 
                  "2210"    ; 
                  "1*10"    ; 
                  "1110"    ;
                  "\n"      ;
                  "Field #2"; 
                  "**100"   ; 
                  "33200"   ; 
                  "1*100"   ] |> String.concat "\n" 

  Given ["4 4"  ; 
         "*..." ; 
         "...." ; 
         ".*.." ; 
         "...." ;
         "3 5"  ; 
         "**..."; 
         "....."; 
         ".*...";
         "0 0"  ] |> String.concat "\n" 
    |> When minesweeping           
    |> It should equal (expected.Replace("\n\n", "\n"))
    |> Verify                       

    