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

let str3 = "ABCDABCDA"
prefixfunc str3
|>printfn "%A"

let str4 = "AAAB"
prefixfunc str4
|>printfn "%A"

KMP "ABCDABCDA" "ABC"
|> printfn "%A"