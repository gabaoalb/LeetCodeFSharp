namespace Solutions.Tests.Problems

open Solutions.Problems
open Xunit

type TopKFrequentElementsTests() =
    let assertSameElements (expected: int[]) (actual: int[]) =
        Assert.Equal<int[]>(Array.sort expected, Array.sort actual)

    [<Fact>]
    member _.``Case 1`` () =
        let nums = [|1;1;1;2;2;3|]
        let k = 2
        let expected = [|1;2|]
        let actual = TopKFrequentElements.topKFrequent nums k
        assertSameElements expected actual

    [<Fact>]
    member _.``Case 2`` () =
        let nums = [|1|]
        let k = 1
        let expected = [|1|]
        let actual = TopKFrequentElements.topKFrequent nums k
        assertSameElements expected actual

    [<Fact>]
    member _.``Case 3`` () =
        let nums = [|1;2;1;2;1;2;3;1;3;2|]
        let k = 2
        let expected = [|1;2|]
        let actual = TopKFrequentElements.topKFrequent nums k
        assertSameElements expected actual
