namespace Solutions.Tests.Problems

open Solutions.Problems
open Xunit

type GroupAnagramsTests() =
    let normalize (groups: string list list) =
            groups
            |> List.map (fun g -> g |> List.sort |> String.concat "|")
            |> List.sort

    [<Fact>]
    member _.``Case 1`` () =
        let strs = [|"eat"; "tea"; "tan"; "ate"; "nat"; "bat"|]
        let expected = [["bat"]; ["nat"; "tan"]; ["ate"; "eat"; "tea"]]
        let actual = GroupAnagrams.groupAnagrams strs
        
        let expectedN = normalize expected
        let actualN = normalize actual

        Assert.Equal<string list>(expectedN, actualN)

    [<Fact>]
    member _.``Case 2`` () =
        let strs = [|""|]
        let expected = [[""]]
        let actual = GroupAnagrams.groupAnagrams strs
        
        let expectedN = normalize expected
        let actualN = normalize actual

        Assert.Equal<string list>(expectedN, actualN)

    [<Fact>]
    member _.``Case 3`` () =
        let strs = [|"a"|]
        let expected = [["a"]]
        let actual = GroupAnagrams.groupAnagrams strs
        
        let expectedN = normalize expected
        let actualN = normalize actual

        Assert.Equal<string list>(expectedN, actualN)
