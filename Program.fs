open System.IO

[<EntryPoint>]
let main argv =
    let url = argv.[0]
    let dir = Directory.GetCurrentDirectory()
    printfn "%s" dir

    let getWeb =
        System.Diagnostics.Process.Start($"{dir}/GetWeb.exe", url)

    let generalList = $"{dir}/generalList.txt"

    if File.Exists(generalList) then
        File.Delete(generalList)

    getWeb.WaitForExit()

    if getWeb.ExitCode <> 0 then
        failwith $"Exception {getWeb.ExitCode}"

    let parse =
        System.Diagnostics.Process.Start($"{dir}/Parse.exe", $"{dir}/ans.html")

    parse.WaitForExit()

    let comparison_engine =
        System.Diagnostics.Process.Start($"{dir}/comparison_engine.exe")

    comparison_engine.WaitForExit()

    0
