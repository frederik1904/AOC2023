using AOC2023.Day1;
using AOC2023.Utils;

namespace AOC2023.Day2;

public class Day2 : ISolutionRunner
{
    private readonly Day2InputClass _input;

    public Day2()
    {
        FileLoaderService<Day2InputClass, Day2InputMapper> fileLoaderService = new("Day2.txt");
        _input = fileLoaderService.ReadInput();
    }

    public string GetName()
    {
        return "Day 2";
    }

    public int CalculatePart1()
    {
        var limitDict = new Dictionary<string, int>()
        {
            { "red", 12 }, { "green", 13 }, { "blue", 14 }
        };

        return _input.Games
            .Where(game =>
                game.ColorAmountsRounds
                    .TrueForAll(round => round
                        .TrueForAll(pick => limitDict[pick.Color] >= pick.Amount)
                    )
            ).Select(game => int.Parse(game.ID))
            .Sum();
        
    }

    public int CalculatePart2()
    {
        var result = 0;

        foreach (var game in _input.Games)
        {
            var minimumCubes = new Dictionary<string, int>()
            {
                { "red", 0 }, { "green", 0 }, { "blue", 0 }
            };

            foreach (var color in game.ColorAmountsRounds.SelectMany(round => round.Where(color => minimumCubes[color.Color] < color.Amount)))
            {
                minimumCubes[color.Color] = color.Amount;
            }

            result += minimumCubes.Values.Aggregate(1, (acc, cur) => acc * cur);
        }
        
        return result;
    }
}