namespace AOC2023.Day2;

public class Day2InputClass
{
    public List<Game> Games { get; set; } = new List<Game>();
}

public class Game
{
    public string ID { get; set; }
    public List<List<ColorAmount>> ColorAmountsRounds { get; set; } = new List<List<ColorAmount>>();
}

public class ColorAmount
{
    public int Amount { get; set; }
    public string Color { get; set; }
}