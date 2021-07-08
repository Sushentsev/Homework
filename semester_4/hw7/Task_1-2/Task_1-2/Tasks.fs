namespace Tasks

module Task1 =

    /// <summary>
    /// Implements the calculations with essential rounding.
    /// </summary>
    type RoundingBuilder(arg : int) = 

        member this.Bind(m : float, f) =
            (m, arg) |> System.Math.Round |> f

        member this.Return(m : float) =
            (m, arg) |> System.Math.Round

module Task2 = 
    
    /// <summary>
    /// Implements the calculations with numbers written as strings.
    /// </summary>
    type CalculationBuilder() =

        member this.Bind(m, f) =
            match System.Int32.TryParse(m) with
            | (true, int) -> f int
            | _ -> None

        member this.Return(x) = 
            Some x