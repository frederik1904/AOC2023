using AOC2023.Utils;

namespace AOC2023.Day1;

public class Day1InputMapper : IFileTransformer<Day1InputClass>
{
    public Day1InputClass MemoryMappedFile(List<string> input)
    {
        var res = new Day1InputClass();
        res.Lines = input;
        return res;
    }
}