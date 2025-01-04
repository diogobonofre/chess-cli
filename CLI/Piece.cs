namespace CLI {
  public abstract class Piece {
    public Coordinate Position { get; set; }
    public Color Color { get; set; }
    public char Sprite { get; set; }
    // Piece constructor need to check if the tile is empty in order to create
    // a piece in that coordinate
    protected Piece(Coordinate position, Color color) {
      Position = position;
      Color = color;
    }

    /// <summary>
    /// Given some game, calculate all possible moves for the current piece instance.
    /// </summary>
    /// <param name="controller"></param>
    /// <returns>List of the possible moves in coordinates</returns>
    public abstract List<Coordinate> GetPossibleMoves(GameController controller);

    /// <summary>
    /// Check if a piece contains some coordinate in it's possible moves at a given game.
    /// </summary>
    /// <param name="controller"></param>
    /// <param name="position"></param>
    /// <returns>
    /// True if the piece can reach the position in one move, if not, false
    /// </returns>
    public bool IsMoveValid(GameController controller, Coordinate position) {
      return GetPossibleMoves(controller).Contains(position);
    }

    protected static bool IsWithinBounds(int x, int y) {
      return x >= 0 && x < 8 && y >= 0 && y < 8;
    }
  }
}