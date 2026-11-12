namespace Ep01.Examples;

// The dotnet CLI built this very project. Commands you will use every day:
//   dotnet new console -o MyApp     create a project        (npm init + a template)
//   dotnet run                      build and run           (npm start)
//   dotnet run -- arg1 arg2         pass args to YOUR app   (npm start -- arg1)
//   dotnet build                    compile only            (tsc)
//   dotnet add package Serilog      add a NuGet package     (npm install serilog)
//   dotnet test                     run unit tests          (npm test)
//
// Project layout: Ep01_Basics.csproj is the "package.json". Every *.cs file in
// the folder (and subfolders) is compiled automatically; no imports between files.
public static class Ex01_DotnetCli
{
    public static void Run()
    {
        Console.WriteLine($".NET runtime : {Environment.Version}");
        Console.WriteLine($"OS           : {Environment.OSVersion}");
        Console.WriteLine($"Working dir  : {Environment.CurrentDirectory}");

        // The assembly (the compiled .dll) is named after the .csproj file.
        Console.WriteLine($"Assembly     : {typeof(Ex01_DotnetCli).Assembly.GetName().Name}");
    }
}
