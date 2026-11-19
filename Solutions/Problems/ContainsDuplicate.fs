namespace Solutions.Problems

open System.Collections.Generic

/// 217. Contains Duplicate
/// https://leetcode.com/problems/contains-duplicate/
module ContainsDuplicate =
    /// 1. Brute force: search pairs of distinct indices. O(n²) time.
    let containsDuplicateBruteForce (nums: int[]) : bool =
        nums
        |> Array.indexed
        |> Array.exists (fun (index, num) ->
            // Enumerate the remaining indices without copying the array suffix.
            seq { index + 1 .. nums.Length - 1 }
            |> Seq.map (fun otherIndex -> nums.[otherIndex])
            |> Seq.exists (fun otherNum -> num = otherNum))

    /// 2. Sort a copy of the array and check adjacent values. O(n log n) time.
    let containsDuplicateSorting (nums: int[]) : bool =
        let sorted = Array.sort nums
        sorted
        |> Array.pairwise
        |> Array.exists (fun (a, b) -> a = b)

    /// 3. Track seen numbers using a HashSet and stop at the first duplicate. O(n) expected time.
    let containsDuplicate (nums: int[]) : bool =
        let seen = HashSet<int>()
        nums
        // Add returns false when the number is already present.
        |> Array.exists (fun num -> not (seen.Add num))

    /// 4. Track seen numbers using an immutable Set and tail recursion. O(n log n) time.
    let containsDuplicateImmutableSet (nums: int[]) : bool =
        let rec check index seen =
            if index >= nums.Length then
                false
            elif Set.contains nums.[index] seen then
                true
            else
                check (index + 1) (Set.add nums.[index] seen)

        check 0 Set.empty

    /// 5. Build an immutable Set and compare its count with the array length. O(n log n) time.
    let containsDuplicateSetLength (nums: int[]) : bool =
        let uniqueNums = Set.ofArray nums
        uniqueNums.Count <> nums.Length
