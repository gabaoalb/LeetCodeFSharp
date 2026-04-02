namespace Solutions.Tests.Problems

open Solutions.Problems
open Xunit

type TwoSumTests() =
    [<Fact>]
    member _.``Case 1`` () =
        let nums = [|2;7;11;15|]
        let target = 9
        let expected = [|0;1|]
        let actual = TwoSum.twoSum nums target
        Assert.Equal<int[]>(expected, actual)

    [<Fact>]
    member _.``Case 2`` () =
        let nums = [|3;2;4|]
        let target = 6
        let expected = [|1;2|]
        let actual = TwoSum.twoSum nums target
        Assert.Equal<int[]>(expected, actual)
    
    [<Fact>]
    member _.``Case 3`` () =
        let nums = [|3;3|]
        let target = 6
        let expected = [|0;1|]
        let actual = TwoSum.twoSum nums target
        Assert.Equal<int[]>(expected, actual)
