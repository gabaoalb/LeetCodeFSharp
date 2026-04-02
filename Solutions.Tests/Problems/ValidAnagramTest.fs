namespace Solutions.Tests.Problems

open Solutions.Problems
open Xunit

type ValidAnagramTests() =
    [<Fact>]
    member _.``Case 1`` () =
        let s = "anagram"
        let t = "nagaram"
        let expected = true
        let actual = ValidAnagram.isAnagram s t
        Assert.Equal(expected, actual)

    [<Fact>]
    member _.``Case 2`` () =
        let s = "rat"
        let t = "car"
        let expected = false
        let actual = ValidAnagram.isAnagram s t
        Assert.Equal(expected, actual)
