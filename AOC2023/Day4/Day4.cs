using AOC2023.Utils;

namespace AOC2023.Day4;

public class Day4 : ISolutionRunner
{
    private readonly Day4InputClass _input;


    public Day4()
    {
        FileLoaderService<Day4InputClass, Day4InputMapper> fileLoaderService = new("Day4.txt");
        _input = fileLoaderService.ReadInput();
    }

    public string GetName()
    {
        return "Day 4";
    }

    public int CalculatePart1()
    {
        return _input
            .Games
            .Sum(g =>
            {
                return g.WinningHand
                    .Intersect(g.YourHand)
                    .Aggregate(0, (acc, _) => acc == 0 ? 1 : acc * 2);
            });
    }
    
    public int CalculatePart2()
    {
        Dictionary<int, int> dict = new Dictionary<int, int>();
        for (var i = 1; i <= _input.Games.Count; i++)
        {
            dict.Add(i, 0);
        }
        
        _input
            .Games
            .ForEach(g =>
            {
                var result = 0;
                var intersects = g.WinningHand
                    .Intersect(g.YourHand)
                    .Count();
                dict[g.CardId] += 1;
                var valBefore = dict[g.CardId];
                for (int i = 1; i <= intersects; i++)
                    dict[g.CardId + i] += valBefore;
            });
    
        return dict.Keys.Sum(key => dict[key]);
    }
}