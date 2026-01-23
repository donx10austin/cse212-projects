public class Maze
{
    private readonly Dictionary<(int, int), bool[]> _mazeMap;
    private int _currX;
    private int _currY;

    public Maze(Dictionary<(int, int), bool[]> mazeMap)
    {
        _mazeMap = mazeMap;
        _currX = 1;
        _currY = 1;
    }

    // Index 0 = Left, 1 = Right, 2 = Up, 3 = Down
    
    public void MoveLeft()
    {
        // Check if movement is possible from current position
        if (_mazeMap[(_currX, _currY)][0])
        {
            _currX -= 1;
        }
        else
        {
            throw new InvalidOperationException("Can't go that way!");
        }
    }

    public void MoveRight()
    {
        if (_mazeMap[(_currX, _currY)][1])
        {
            _currX += 1;
        }
        else
        {
            throw new InvalidOperationException("Can't go that way!");
        }
    }

    public void MoveUp()
    {
        if (_mazeMap[(_currX, _currY)][2])
        {
            _currY += 1;
        }
        else
        {
            throw new InvalidOperationException("Can't go that way!");
        }
    }

    public void MoveDown()
    {
        if (_mazeMap[(_currX, _currY)][3])
        {
            _currY -= 1;
        }
        else
        {
            throw new InvalidOperationException("Can't go that way!");
        }
    }

    // Optional: Add a way to get the current position for testing
    public string GetStatus() => $"Current location (x={_currX}, y={_currY})";
}