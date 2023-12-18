using AOC2023.Utils;

namespace AOC2023.Day4;

public class Day4InputMapper : IFileTransformer<Day4InputClass>
{
    public Day4InputClass MemoryMappedFile(List<string> input)
    {
        var res = new Day4InputClass();

        foreach (var line in input)
        {
            var firstSplit = line.Split(": ");
            var handsSplit = firstSplit[1].Split(" | ");
            var id = int.Parse(firstSplit[0].Split("Card")[1].Trim());
            var game = new Game()
            {
                WinningHand = ConvertToIntList(handsSplit[0]),
                YourHand = ConvertToIntList(handsSplit[1]),
                CardId = id
            };
            res.Games.Add(game);

        }
        
        
        return res;
    }

    private static List<int> ConvertToIntList(string hand)
    {
        return hand.Split(" ").Where(v => v != "").Select(int.Parse).ToList();
    }
}