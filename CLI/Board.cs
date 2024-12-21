namespace CLI {
  public class Board {
    public Piece?[,] Grid { get; private set; }

    public Board() {
      Grid = new Piece[8, 8];
    }

    public Piece? GetPieceAt(Coordinate position) {
      return Grid[position.X, position.Y];
    }

    public bool SetPieceAt(Coordinate position, Piece piece) {
      if (GetPieceAt(position) != null) {
        return false;
      }
      Grid[position.X, position.Y] = piece;
      return true;
    }

    public void PopulateBoard(string template) {
    }
  }
}
