namespace Solutions.Problems

open System

module EncodeAndDecodeStrings =
    let encode (strs: string list) : string =
        strs
        |> Seq.map(fun (str: string) -> $"{str.Length}#{str}")
        |> String.concat ""

    let decode (str: string) : string list =
        
        let rec loop (currentS: string) (acc: string list) =
            if String.IsNullOrEmpty(currentS) then
                List.rev acc
            else
                let sepIdx = currentS.IndexOf('#')
                if sepIdx <> -1 then
                    let len = int (currentS.[0..sepIdx-1])
                    let start = sepIdx + 1
                    let end' = start + len
                    let word = currentS.[start..end'-1]
                    loop currentS.[end'..] (word :: acc)
                else
                    List.rev acc

        loop str [] 