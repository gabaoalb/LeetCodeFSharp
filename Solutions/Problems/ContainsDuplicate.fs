namespace Solutions.Problems

open System.Collections.Generic

/// 217. Contains Duplicate
/// https://leetcode.com/problems/contains-duplicate/
/// Given an integer array nums, return true if any value appears at least twice in the array, and return false if every element is distinct.
/// Array & Hashing Problems
module ContainsDuplicate =
    let containsDuplicateBruteForce (nums: int[]) : bool =
        nums
        |> Array.exists (fun num ->
            nums
            |> Array.exists (fun otherNum -> num = otherNum))

    let containsDuplicateSorting (nums: int[]) : bool =
        let sorted = Array.sort nums
        sorted
        |> Array.pairwise
        |> Array.exists (fun (a, b) -> a = b)

    let containsDuplicate (nums: int[]) : bool =
        let seen = HashSet<int>()
        nums
        |> Array.exists (fun num ->
            if seen.Contains(num) then
                true
            else
                seen.Add(num) |> ignore
                false)

    let containsDuplicateHashSetLength (nums: int[]) : bool =
        let seen = HashSet<int>(nums)
        seen.Count <> nums.Length