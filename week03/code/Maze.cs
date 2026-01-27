public class Maze
{
    private readonly Dictionary<(int, int), bool[]> _mazeMap;
    private int _currX = 1;
    private int _currY = 1;

    public Maze(Dictionary<(int, int), bool[]> mazeMap)
    {
        _mazeMap = mazeMap;
    }

    // Index 0 = Left, 1 = Right, 2 = Up, 3 = Down
    public void MoveLeft() { if (CanMove(0)) _currX--; }
    public void MoveRight() { if (CanMove(1)) _currX++; }
    public void MoveUp() { if (CanMove(2)) _currY--; }
    public void MoveDown() { if (CanMove(3)) _currY++; }

    private bool CanMove(int directionIndex)
    {
        return _mazeMap.ContainsKey((_currX, _currY)) && _mazeMap[(_currX, _currY)][directionIndex];
    }

    /// <summary>
    /// Returns the current location as a string. 
    /// This resolves the CS1061 error in your test file.
    /// </summary>
    public string GetStatus()
    {
        return $"({_currX}, {_currY})";
    }
}