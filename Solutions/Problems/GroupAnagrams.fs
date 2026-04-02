namespace Solutions.Problems

module GroupAnagrams =
    let groupAnagrams (strs: string[]) : string list list =
        strs
        |> Array.groupBy (fun s -> s |> Seq.sort |> Seq.toArray)
        |> Array.map (fun (_, group) -> group |> Array.toList)
        |> Array.toList