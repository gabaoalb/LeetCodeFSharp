namespace Solutions.Tests.Problems

open Solutions.Problems
open Xunit

type ContainsDuplicateTests() =
    [<Fact>]
    member _.``Case 1`` () =
        let nums = [|1; 2; 3; 1|]
        let expected = true
        let actual = ContainsDuplicate.containsDuplicate nums
        Assert.Equal(expected, actual)
    [<Fact>]
    member _.``Case 2`` () =
        let nums = [|1; 2; 3; 4|]
        let expected = false
        let actual = ContainsDuplicate.containsDuplicate nums
        Assert.Equal(expected, actual)
    [<Fact>]
    member _.``Case 3`` () =
        let nums = [|1; 1; 1; 3; 3; 4; 3; 2; 4; 2|]
        let expected = true
        let actual = ContainsDuplicate.containsDuplicate nums
        Assert.Equal(expected, actual)