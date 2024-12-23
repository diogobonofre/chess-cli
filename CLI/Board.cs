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

    public void RemovePieceAt(Coordinate position) {
      if (GetPieceAt(position) != null) {
        Grid[position.X, position.Y] = null;
      }
    }

    public void PlacePlayerPieces(Player player) {
      foreach (var piece in player.Pieces) {
        SetPieceAt(piece.Position, piece);
      }
    }
  }
}
