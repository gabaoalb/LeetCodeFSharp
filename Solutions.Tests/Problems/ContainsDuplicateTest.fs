namespace Solutions.Tests.Problems

open Solutions.Problems
open Xunit

type ContainsDuplicateTests() =
    let assertAllImplementations nums expected =
        let implementations =
            [ "Brute force", ContainsDuplicate.containsDuplicateBruteForce
              "Sorting", ContainsDuplicate.containsDuplicateSorting
              "HashSet", ContainsDuplicate.containsDuplicate
              "Immutable Set", ContainsDuplicate.containsDuplicateImmutableSet
              "Set count", ContainsDuplicate.containsDuplicateSetLength ]

        for name, implementation in implementations do
            let actual = implementation nums
            Assert.True((actual = expected), $"{name}: expected {expected}, got {actual}.")

    [<Fact>]
    member _.``Case 1`` () =
        let nums = [|1; 2; 3; 1|]
        let expected = true
        assertAllImplementations nums expected

    [<Fact>]
    member _.``Case 2`` () =
        let nums = [|1; 2; 3; 4|]
        let expected = false
        assertAllImplementations nums expected

    [<Fact>]
    member _.``Case 3`` () =
        let nums = [|1; 1; 1; 3; 3; 4; 3; 2; 4; 2|]
        let expected = true
        assertAllImplementations nums expected
