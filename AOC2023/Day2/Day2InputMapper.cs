using AOC2023.Day1;
using AOC2023.Utils;

namespace AOC2023.Day2;

public class Day2InputMapper : IFileTransformer<Day2InputClass>
{
    public Day2InputClass MemoryMappedFile(List<string> input)
    {
        var res = new Day2InputClass();
        foreach (var line in input)
        {
            var game = new Game();
            var IDSplit = line.Split(": ");
            game.ID = IDSplit[0].Split(" ")[1];

            var rounds = IDSplit[1].Split("; ");

            foreach (var round in rounds)
            {  
                var roundList = round
                    .Split(", ")
                    .Select(entry => entry
                        .Split(" ")
                    ).Select(colorAmount => new ColorAmount { Amount = int.Parse(colorAmount[0]), Color = colorAmount[1] })
                    .ToList();
                game.ColorAmountsRounds.Add(roundList);
            }
            
            res.Games.Add(game);
        }
        
        return res;
    }
}