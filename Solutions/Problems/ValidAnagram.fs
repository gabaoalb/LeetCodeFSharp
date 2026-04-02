namespace Solutions.Problems

open System.Collections.Generic

/// 242. Valid Anagram
/// https://leetcode.com/problems/valid-anagram/
/// Given two strings s and t, return true if t is an anagram of s, and false otherwise.
/// String & Hashing Problems
module ValidAnagram =
    let isAnagramSorting (s: string) (t: string) : bool =
        if s.Length <> t.Length then
            false
        else
            let sortedS = s.ToCharArray() |> Array.sort
            let sortedT = t.ToCharArray() |> Array.sort
            sortedS = sortedT

    let isAnagramHashMapTwoPasses (s: string) (t: string) : bool =
        if s.Length <> t.Length then
            false
        else
            let charCount = Dictionary<char, int>()
            s
            |> Seq.iter (fun c ->
                if charCount.ContainsKey(c) then
                    charCount.[c] <- charCount.[c] + 1
                else
                    charCount.[c] <- 1)
            t
            |> Seq.iter (fun c ->
                if charCount.ContainsKey(c) then
                    charCount.[c] <- charCount.[c] - 1
                else
                    charCount.[c] <- -1)
            charCount.Values
            |> Seq.forall (fun count -> count = 0)

    let isAnagramHashMapOnePass (s: string) (t: string) : bool =
        if s.Length <> t.Length then
            false
        else
            let charCount = Dictionary<char, int>()
            Seq.zip s t
            |> Seq.iter (fun (cS, cT) ->
                if charCount.ContainsKey(cS) then
                    charCount.[cS] <- charCount.[cS] + 1
                else
                    charCount.[cS] <- 1

                if charCount.ContainsKey(cT) then
                    charCount.[cT] <- charCount.[cT] - 1
                else
                    charCount.[cT] <- -1)

            charCount.Values
            |> Seq.forall (fun count -> count = 0)

    let isAnagramHashTableArray (s: string) (t: string) : bool =
        if s.Length <> t.Length then
            false
        else
            let charCount = Array.zeroCreate 26
            Seq.zip s t
            |> Seq.iter (fun (cS, cT) ->
                charCount.[int cS - int 'a'] <- charCount.[int cS - int 'a'] + 1
                charCount.[int cT - int 'a'] <- charCount.[int cT - int 'a'] - 1)
            charCount
            |> Array.forall (fun count -> count = 0)

    let isAnagram (s: string) (t: string) : bool =
        isAnagramHashTableArray s t