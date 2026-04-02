namespace Solutions.Problems

module TopKFrequentElements =
    let topKFrequent (nums: int[]) (k: int) : int[] =
        nums
        |> Array.countBy id
        |> Array.sortByDescending snd
        |> Array.take k
        |> Array.map fst