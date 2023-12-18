namespace AOC2023.Day4;

public class Day4InputClass
{
    public List<Game> Games = new List<Game>();
}

public class Game
{
    public int CardId;
    public List<int> WinningHand = new List<int>();
    public List<int> YourHand = new List<int>();
}