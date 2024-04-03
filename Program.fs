// For more information see https://aka.ms/fsharp-console-apps
printfn "NBA basketball statistics"
// Define Coach record
type Coach = {
    Name: string
    FormerPlayer: bool
}

// Define Stats record
type Stats = {
    Wins: int
    Losses: int
}

// Define Team record
type Team = {
    Name: string
    Coach: Coach
    Stats: Stats
}

// Define the list of teams
let teams = [
    { Name = "Oklahoma City Thunder"; Coach = { Name = "Mark Daigneault"; FormerPlayer = false }; Stats = { Wins = 52; Losses = 23 } }
    { Name = "Orlando Magic"; Coach = { Name = "Jamahl Mosley"; FormerPlayer = false }; Stats = { Wins = 44; Losses = 31 } }
    { Name = "Philadelphia 76ers"; Coach = { Name = "Nick Nurse"; FormerPlayer = false }; Stats = { Wins = 41; Losses = 35 } }
    { Name = "Phoenix Suns"; Coach = { Name = "Frank Vogel"; FormerPlayer = false }; Stats = { Wins = 44; Losses = 31 } }
    { Name = "Portland Trail Blazers"; Coach = { Name = "Chauncey Billups"; FormerPlayer = true }; Stats = { Wins = 19; Losses = 56 } }
]

// Filtering the list of successful teams
let winningTeams = teams |> List.filter (fun team -> team.Stats.Wins > team.Stats.Losses)

// Mapping the list to calculate success percentage
let winningPercentages = winningTeams |> List.map (fun team -> 
    let totalGames = float (team.Stats.Wins + team.Stats.Losses)
    let winningPercentage = float team.Stats.Wins / totalGames * 100.0
    (team.Name, winningPercentage))

// Output success percentages
printfn "winning percentages:"
winningPercentages |> List.iter (fun (teamName, percentage) ->
    printfn "%s: %.2f%%" teamName percentage)











// Define Cuisine discriminated union
type Cuisine =
    | Korean
    | Turkish

// Define MovieType discriminated union
type MovieType =
    | Regular
    | IMAX
    | DBOX
    | RegularWithSnacks
    | IMAXWithSnacks
    | DBOXWithSnacks

// Define Genre discriminated union
type Genre =
    | Action
    | Comedy
    | Drama
    | Romance
    | Thriller

// Define Activity discriminated union
type Activity =
    | BoardGame
    | Chill
    | Movie of Genre
    | Restaurant of Cuisine
    | LongDrive of int * float

// Function to calculate the budget for different activities
let calculatingtotalBudget (activity : Activity) =
    match activity with
    | BoardGame | Chill -> 0.0
    | Movie genre ->
        match genre with
        | Action | Thriller -> 17.0
        | Comedy -> 12.0
        | Drama | Romance -> 20.0
    | Restaurant cuisine ->
        match cuisine with
        | Korean -> 70.0
        | Turkish -> 65.0
    | LongDrive (distance, fuelCostPerKm) -> float distance * fuelCostPerKm

// Example usage
let activity1 = Movie Romance
let activity2 = Restaurant Korean
let activity3 = LongDrive (100, 0.50)
printfn "Budget of a Valentine's Day evening."
printfn "Budget for activity 1: %.2f CAD" (calculatingtotalBudget activity1)
printfn "Budget for activity 2: %.2f CAD" (calculatingtotalBudget activity2)
printfn "Budget for activity 3: %.2f CAD" (calculatingtotalBudget activity3)
