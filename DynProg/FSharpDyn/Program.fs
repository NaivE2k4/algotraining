open subsequences

[|3;1;2;3;4;5;4;7|]
|> gis
|> printfn "%A"


[|3;1;2;3;4;5;4;7|]
|> gis2
|> printfn "%A"

[|3;1;2;3;4;5;4;7|]
|> gis3
|> printfn "%A"

[|3;1;2;3;4;5;4;7|]
|> gis4
|> printfn "%A"

let str1 = "ABCABC"
let str2 = "ADFABF"
levenstein str1 str2
|>printfn "%A"