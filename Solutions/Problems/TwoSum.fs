namespace Solutions.Problems

/// 1. Two Sum
/// https://leetcode.com/problems/two-sum/
module TwoSum =
    /// 1. Brute force: search pairs of distinct indices. O(n²) time.
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

    /// 2. Sort value-index pairs and search using two pointers. O(n log n) time.
    let twoSumSorting (nums: int[]) target =
        // 1. Create value-index pairs and sort by value
        let sorted = 
            nums 
            |> Array.mapi (fun i x -> (x, i)) 
            |> Array.sortBy fst

        // 2. Recursive function that replaces the 'while' with pointers
        let rec loop left right =
            if left >= right then 
                [||] // Base case: pointers have crossed
            else
                let (valL, idxL) = sorted.[left]
                let (valR, idxR) = sorted.[right]
                match valL + valR with
                | s when s = target -> [| idxL; idxR |]
                | s when s < target -> loop (left + 1) right
                | _                 -> loop left (right - 1)

        loop 0 (sorted.Length - 1)

    /// 3. Build an immutable Map, then search for complements. O(n log n) time.
    let twoSumMapTwoPasses nums target =
        let mutable map = Map.empty
        nums |> Seq.indexed |> Seq.iter (fun (i, x) -> map <- Map.add x i map)
        nums |> Seq.indexed |> Seq.pick (fun (i, x) ->
            let diff = target - x
            match Map.tryFind diff map with
            | Some(idx) when idx <> i -> Some([| i; idx |])
            | _ -> None)

    /// 4. Search for complements using an immutable Map in one pass. O(n log n) time.
    let twoSum nums target =
        nums 
        |> Seq.indexed
        |> Seq.scan (fun (map, _) (i, x) ->
            let diff = target - x
            match Map.tryFind diff map with
            | Some(idx) -> (map, Some([| idx; i |]))
            | None -> (Map.add x i map, None)
        ) (Map.empty, None)
        |> Seq.pick (fun (_, res) -> res)