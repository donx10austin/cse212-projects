public class Maze
{
    private readonly Dictionary<(int, int), bool[]> _mazeMap;
    private int _currX;
    private int _currY;

    public Maze(Dictionary<(int, int), bool[]> mazeMap, int startX, int startY)
    {
        _mazeMap = mazeMap;
        _currX = startX;
        _currY = startY;
    }

    // Index 0 = Left, 1 = Right, 2 = Up, 3 = Down
    
    public void MoveLeft()
    {
        // Check if movement is possible from current position
        if (_mazeMap[(_currX, _currY)][0])
        {
            _currX -= 1;
        }
    }

    public void MoveRight()
    {
        if (_mazeMap[(_currX, _currY)][1])
        {
            _currX += 1;
        }
    }

    public void MoveUp()
    {
        if (_mazeMap[(_currX, _currY)][2])
        {
            _currY += 1;
        }
    }

    public void MoveDown()
    {
        if (_mazeMap[(_currX, _currY)][3])
        {
            _currY -= 1;
        }
    }

    // Optional: Add a way to get the current position for testing
    public (int, int) GetStatus() => (_currX, _currY);
}