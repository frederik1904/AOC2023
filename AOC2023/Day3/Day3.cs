using AOC2023.Day1;
using AOC2023.Utils;

namespace AOC2023.Day3;

public class Day3 : ISolutionRunner
{
    private readonly Day3InputClass _input;


    public Day3()
    {
        FileLoaderService<Day3InputClass, Day3InputMapper> fileLoaderService = new("Day3.txt");
        _input = fileLoaderService.ReadInput();
    }

    public string GetName()
    {
        return "Day 3";
    }

    public int CalculatePart1()
    {
        return _input.Numbers
            .Where(numberPos => _input.Symbols
                .Exists(symbol => Collision(numberPos, symbol))
            ).Select(np => np.Number)
            .Sum();

    }

    private static bool Collision(NumberPos NPHardProblem, Coordinate c2)
    {
        var lengthOfNum = NPHardProblem.Number.ToString().Length;

        if (
            NPHardProblem.Coordinate.Y - 1 > c2.Y
            || NPHardProblem.Coordinate.Y + 1 < c2.Y)
        {
            return false;
        }

        if (
            NPHardProblem.Coordinate.X - 1 > c2.X
            || NPHardProblem.Coordinate.X + lengthOfNum < c2.X
        )
        {
            return false;
        }

        return true;
    }

    public int CalculatePart2()
    {
        return _input
            .Symbols
            .Where(symb => symb.Symbol.Equals("*"))
            .Select(symb =>
            {
                var collisions = _input.Numbers.Where(n => Collision(n, symb)).ToList();
                return collisions.Count <= 1 ? 0 : collisions.Aggregate(1, (acc, curr) => acc * curr.Number);
            }).Sum();
    }
}