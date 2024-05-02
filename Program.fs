module demo.Demo
open System
let defaultV = '-'
let mutable board = Array2D.create 3 3 defaultV


let player1 = 'X'
let player2 = 'O' 



let rec printBoard () = 
  for i = 0 to 2 do
    for j = 0 to 2 do
      printf " %c |" board.[i,j]
    printfn ""
    printfn "---|---|---|"

let rec checkwin () : char =
  let mutable winner = defaultV
  for i = 0 to 2 do
    if board.[i,0] = board.[i,1] && board.[i,0] = board.[i, 2] && board.[i,0] <> defaultV then
      winner <- board.[i,0]
    else if board.[0,i] = board.[1,i] && board.[0,i] = board.[2, i] && board.[0,i] <> defaultV then
      winner <- board.[0,i]
  if board.[0,0] = board.[1,1] && board.[0,0] = board.[2, 2] && board.[0,0] <> defaultV then
    winner <- board.[0,0]
  else if board.[0,2] = board.[1,1] && board.[0,2] = board.[2,0] && board.[0,2] <> defaultV then
    winner <- board.[0,2]
  winner



let mutable p = 0

let rec rungame () = 
  let winner = checkwin ()
  if winner = defaultV then
    printBoard ()
    let mutable x = -1
    let mutable y = -1
    if p = 0 then
      printfn "Player: %c" player1
    else if p = 1 then
      printfn "Player: %c" player2
    let rec getPlace () = 
      let mutable px = 0
      let mutable py = 0
      printf "Input X: "
      let ix = Console.ReadLine()
      Int32.TryParse(ix, &px)
      printf "Input Y: "
      let iy = Console.ReadLine()
      Int32.TryParse(iy, &py)
      if board.[px,py] <> defaultV then
        getPlace ()
      else 
        x <- px
        y <- py
    getPlace ()
    if p = 0 then
      board.[x,y] <- player1
      p <- 1
    else if p = 1 then
      board.[x,y] <- player2
      p <- 0
    rungame ()
  else
    printBoard ()
    printfn "Player %c won!" winner
    board <- Array2D.create 3 3 ' '
      
let startGame = 
  printfn "Hello Player!"
  rungame ()
   
startGame
