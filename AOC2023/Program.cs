// See https://aka.ms/new-console-template for more information

using System.Diagnostics;
using AOC2023.Day1;
using AOC2023.Day2;
using AOC2023.Utils;
using static System.Console;

List<ISolutionRunner> solutions = new() { new Day1(), new Day2() };
var stopwatch = new Stopwatch();
const int runs = 5;

WriteLine("{0,8} | {1,8} | {2,8}", "Name", "Result", $"AVG. time (ms) of {runs} runs");
WriteLine("-------------------------------------------------------------------------");
foreach (var runner in solutions)
{
    stopwatch.Reset();
    stopwatch.Start();
    var part1Result = -1;
    for (var i = 0; i < runs; i++)
    {
        part1Result = runner.CalculatePart1();
    }

    stopwatch.Stop();

    var elapsedPart1 = stopwatch.Elapsed;
    WriteLine("{0,8} | {1,8} | {2,8}", runner.GetName(), part1Result, elapsedPart1.Milliseconds / runs);

    stopwatch.Reset();
    stopwatch.Start();
    
    var part2Result = -1;
    for (var i = 0; i < runs; i++)
    {
        part2Result = runner.CalculatePart2();
    }
    
    stopwatch.Stop();
    var elapsedPart2 = stopwatch.Elapsed;
    WriteLine("{0,8} | {1,8} | {2,8}", runner.GetName(), part2Result, elapsedPart2.Milliseconds / runs);
    
}