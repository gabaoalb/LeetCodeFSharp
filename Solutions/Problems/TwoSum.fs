namespace Solutions.Problems

module TwoSum =
    let twoSumBruteForce nums target =
        nums
        |> Seq.indexed
        |> Seq.collect (fun (i, x) ->
            nums
            |> Seq.indexed
            |> Seq.filter (fun (j, _) -> j > i)
            |> Seq.map (fun (j, y) -> (i, j, x + y)))
        |> Seq.find (fun (_, _, sum) -> sum = target)
        |> fun (i, j, _) -> [| i; j |]

    let twoSumSorting (nums: int[]) target =
        // 1. Cria pares (valor, índice) e ordena pelo valor
        let sorted = 
            nums 
            |> Array.mapi (fun i x -> (x, i)) 
            |> Array.sortBy fst

        // 2. Função recursiva que substitui o 'while' com os ponteiros
        let rec loop left right =
            if left >= right then 
                [||] // Caso base: ponteiros se cruzaram
            else
                let (valL, idxL) = sorted.[left]
                let (valR, idxR) = sorted.[right]
                match valL + valR with
                | s when s = target -> [| idxL; idxR |]
                | s when s < target -> loop (left + 1) right
                | _                 -> loop left (right - 1)

        loop 0 (sorted.Length - 1)

    let twoSumHashMapTwoPasses nums target =
        let mutable map = Map.empty
        nums |> Seq.indexed |> Seq.iter (fun (i, x) -> map <- Map.add x i map)
        nums |> Seq.indexed |> Seq.pick (fun (i, x) ->
            let diff = target - x
            match Map.tryFind diff map with
            | Some(idx) when idx <> i -> Some([| i; idx |])
            | _ -> None)

    let twoSum nums target =
        nums 
        |> Seq.indexed
        |> Seq.scan (fun (map, result) (i, x) ->
            let diff = target - x
            match Map.tryFind diff map with
            | Some(idx) -> (map, Some([| idx; i |]))
            | None -> (Map.add x i map, None)
        ) (Map.empty, None)
        //|> snd
        //|> Option.get
        |> Seq.pick (fun (_, res) -> res)