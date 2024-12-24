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

    public abstract List<Coordinate> GetPossibleMoves(Board board);

    public bool IsMoveValid(Board board, Coordinate position) {
      return GetPossibleMoves(board).Contains(position);
    }

    protected static bool IsWithinBounds(int x, int y) {
      return x >= 0 && x < 8 && y >= 0 && y < 8;
    }
  }
}