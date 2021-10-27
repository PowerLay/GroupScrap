open System.IO

[<EntryPoint>]
let main argv =
    let url = argv.[0]
    let dir = Directory.GetCurrentDirectory()

    System
        .Diagnostics
        .Process
        .Start($"{dir}/GetWeb.exe", url)
        .WaitForExit()

    let generalList = $"{dir}/generalList.txt"

    if File.Exists(generalList) then
        File.Delete(generalList)

    System
        .Diagnostics
        .Process
        .Start($"{dir}/Parse.exe", "generalList.txt")
        .WaitForExit()

    let engineDir = $"{dir}/comparison_engine"

    System
        .Diagnostics
        .Process
        .Start(
            $"{dir}/comparison_engine/comparison_engine.exe",
            $"{engineDir}/groupeList {generalList} {dir}/outputList"
        )
        .WaitForExit()

    0
