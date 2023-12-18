namespace AOC2023.Day3;

public class Day3InputClass
{
    public List<List<char>> Board { get; set; } = new List<List<char>>();
    public List<NumberPos> Numbers { get; set; } = new List<NumberPos>();
    public List<Coordinate> Symbols { get; set; } = new List<Coordinate>();
}

public class NumberPos
{
    public NumberPos(int number, int x, int y)
    {
        Number = number;
        this.Coordinate = new Coordinate() { X = x, Y = y };
    }
    
    public int Number;
    public Coordinate Coordinate;

    public override string ToString()
    {
        return $"Number: {Number}, Coordinate: {this.Coordinate.ToString()}";
    }
}

public class Coordinate
{
    public int X;
    public int Y;
    public string Symbol;

    public override string ToString()
    {
        return $"({X}, {Y}, Symbol: {Symbol})";
    }
}