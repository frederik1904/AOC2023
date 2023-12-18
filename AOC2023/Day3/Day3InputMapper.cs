using System.Text.RegularExpressions;
using AOC2023.Day1;
using AOC2023.Utils;

namespace AOC2023.Day3;

public class Day3InputMapper : IFileTransformer<Day3InputClass>
{
    public Day3InputClass MemoryMappedFile(List<string> input)
    {
        var res = new Day3InputClass();
        
        Regex numberRegex = new Regex(@"\d+");
        Regex symbolRegex = new Regex(@"[^0-9.\r\n]");
        
        for (var i = 0; i < input.Count; i++)
        {
            var numbers = numberRegex.Matches(input[i]);

            foreach (Match match in numbers)
            {
                res.Numbers.Add(new NumberPos(int.Parse(match.Value), match.Index, i));
            }

            var symbols = symbolRegex.Matches(input[i]);
            
            foreach (Match match in symbols)
            {
                res.Symbols.Add(new Coordinate(){X = match.Index, Y = i, Symbol = match.Value});
            }
            
            res.Board.Add(input[i].ToCharArray().ToList());
        }
        return res;
    }
}