namespace Solutions.Problems

open System.Collections.Generic

/// 49. Group Anagrams
/// https://leetcode.com/problems/group-anagrams/
module GroupAnagrams =
    /// 1. Group strings by their sorted character sequence using Array.groupBy.
    /// Expected O(n * k * log k) time, where n is the number of strings
    /// and k is the maximum string length.
    let groupAnagrams (strs: string[]) : string list list =
        strs
        |> Array.groupBy (fun s -> s |> Seq.sort |> Seq.toArray)
        |> Array.map (fun (_, group) -> group |> Array.toList)
        |> Array.toList

    /// 2. Group strings by their sorted character sequence using a Dictionary.
    /// Expected O(n * k * log k) time, where n is the number of strings
    /// and k is the maximum string length.
    let groupAnagramsDictionary (strs: string[]) : string list list =
        let anagramMap = Dictionary<string, List<string>>()
        for s in strs do
            let sortedKey = new string(s |> Seq.sort |> Seq.toArray)
            match anagramMap.TryGetValue(sortedKey) with
            | true, group -> group.Add(s)
            | false, _ ->
                let group = List<string>()
                group.Add(s)
                anagramMap.Add(sortedKey, group)
        anagramMap.Values
        |> Seq.map Seq.toList
        |> Seq.toList

    /// 3. Group strings by their sorted character sequence using an immutable Map.
    /// O(n * k * log k + n * k * log g) time, where n is the number of strings,
    /// k is the maximum string length, and g is the number of anagram groups.
    let groupAnagramsUsingImmutableMap (strs: string[]) : string list list =
        let anagramMap =
            strs
            |> Array.fold (fun acc s ->
                let sortedKey = new string(s |> Seq.sort |> Seq.toArray)
                let updatedGroup =
                    match Map.tryFind sortedKey acc with
                    // Prepending takes O(1) and reverses input order within each group.
                    // The problem allows the result in any order.
                    | Some group -> s :: group
                    | None -> [s]
                Map.add sortedKey updatedGroup acc) Map.empty
        anagramMap
        |> Map.toList
        |> List.map snd
