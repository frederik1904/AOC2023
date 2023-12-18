using AOC2023.Utils;

namespace AOC2023.Day1;

public class Day1 : ISolutionRunner
{
    private readonly Day1InputClass _input;
    private readonly List<char> _numbers = new() { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };

    private readonly Dictionary<string, int> _translation = new()
    {
        { "0", 0 }, { "1", 1 }, { "2", 2 }, { "3", 3 }, { "4", 4 }, { "5", 5 },
        { "6", 6 }, { "7", 7 }, { "8", 8 }, { "9", 9 }, { "one", 1 }, { "two", 2 },
        { "three", 3 }, { "four", 4 }, { "five", 5 }, { "six", 6 }, { "seven", 7 },
        { "eight", 8 }, { "nine", 9 }
    };

    public Day1()
    {
        FileLoaderService<Day1InputClass, Day1InputMapper> fileLoaderService = new("Day1.txt");
        _input = fileLoaderService.ReadInput();
    }

    public string GetName()
    {
        return "Day 1";
    }

    public int CalculatePart1()
    {
        var result = 0;

        foreach (var line in _input.Lines)
        {
            char? lowest = null;
            char? highest = null;
            foreach (var val in line.ToCharArray())
            {
                if (!_numbers.Contains(val))
                    continue;

                lowest ??= val;

                highest = val;
            }

            result += int.Parse(lowest.ToString() + highest.ToString());
        }

        return result;
    }

    public int CalculatePart2()
    {
        var result = 0;
        var words = _translation.Keys.ToList();
        foreach (var line in _input.Lines)
        {
            int? lowest = null;
            int? highest = null;


            for (var i = 0; i < line.Length; i++)
            {
                var substr = line.Substring(i);

                for (var j = 0; j < words.Count; j++)
                {
                    if (!substr.StartsWith(words[j]))
                        continue;
                    lowest = _translation[words[j]];
                }

                if (lowest != null)
                    break;
            }
            
            for (var i = line.Length - 1; i >= 0; i--)
            {
                var substr = line.Substring(i);

                for (var j = 0; j < words.Count; j++)
                {
                    if (!substr.StartsWith(words[j]))
                        continue;
                    highest = _translation[words[j]];
                }

                if (highest != null)
                    break;
            }
            
            result += int.Parse(lowest.ToString() + highest.ToString());;
        }

        return result;
    }
}