namespace Solutions.Tests.Problems

open Solutions.Problems
open Xunit

type EncodeAndDecodeStringsTest() =
    [<Fact>]
    member this.``Case 1``() =
        let strs = ["Hello"; "World"; "F#"; "Programming"]
        let encoded = EncodeAndDecodeStrings.encode strs
        let decoded = EncodeAndDecodeStrings.decode encoded
        Assert.Equal<string list>(strs, decoded)

    [<Fact>]
    member this.``Case 2``() =
        let strs = []
        let encoded = EncodeAndDecodeStrings.encode strs
        let decoded = EncodeAndDecodeStrings.decode encoded
        Assert.Equal<string list>(strs, decoded)
    
    [<Fact>]
    member this.``Case 3``() =
        let strs = ["Hello"; ""; "World"]
        let encoded = EncodeAndDecodeStrings.encode strs
        let decoded = EncodeAndDecodeStrings.decode encoded
        Assert.Equal<string list>(strs, decoded)