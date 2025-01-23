namespace CLI;

// Piece constructor need to check if the tile is empty in order to create
// a piece in that coordinate
public abstract class Piece(Coordinate position, Color color)
{
    public Coordinate Position { get; set; } = position;
    public Color Color { get; set; } = color;
    public char Sprite { get; set; }
    
    /// <summary>
    /// Given some game, calculate all possible moves for the current piece instance.
    /// </summary>
    /// <param name="controller"></param>
    /// <returns>List of the possible moves in coordinates</returns>
    public abstract List<Coordinate> GetPossibleMoves(GameController controller);

    /// <summary>
    /// Check if a piece contains some coordinate in its possible moves at a given game.
    /// </summary>
    /// <param name="controller"></param>
    /// <param name="position"></param>
    /// <returns>
    /// True if the piece can reach the position in one move, if not, false
    /// </returns>
    public bool IsMoveValid(GameController controller, Coordinate position)
    {
        return GetPossibleMoves(controller).Contains(position);
    }
    
    protected static bool IsWithinBounds(int x, int y)
    {
        return x is >= 0 and < 8 && y is >= 0 and < 8;
    }
    
    protected static bool IsWithinBounds(Coordinate position)
    {
        return position.X is >= 0 and < 8 && position.Y is >= 0 and < 8;
    }
}