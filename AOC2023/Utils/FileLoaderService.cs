namespace AOC2023.Utils;

public class FileLoaderService<TOutputType, TFileTransformer> where TFileTransformer : IFileTransformer<TOutputType>, new()
{
    private string _path;
    private TFileTransformer _fileTransformer;

    public FileLoaderService(string filename)
    {
        _path = $"C:\\work\\Automitation\\AOC2023\\AOC2023\\Files\\{filename}";
        _fileTransformer = new TFileTransformer();
    }

    public TOutputType ReadInput()
    {
        var input = ReadFile();
        return _fileTransformer.MemoryMappedFile(input);
    }


    private List<string> ReadFile()
    {
        var lines = new List<string>();
        using var sr = new StreamReader(_path);
        string line;
        while ((line = sr.ReadLine()) != null)
        {
            lines.Add(line);
        }

        return lines;
    }
}