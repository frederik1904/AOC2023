using System.IO.MemoryMappedFiles;

namespace AOC2023.Utils;

public interface IFileTransformer<out TOutputFileType>
{
    public TOutputFileType MemoryMappedFile(List<String> input);
}