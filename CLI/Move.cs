namespace CLI {
  internal class Move {
    public static void MovePieceTo(Board board, Piece piece, Coordinate newPosition) {
      CheckMovementValidity(piece, newPosition);
      var tile = board.GetPieceAt(newPosition);
      if (tile != null) {
        Console.WriteLine($"Killed {tile.Sprite}");
        board.RemovePieceAt(newPosition);
      }
      board.RemovePieceAt(piece.Position);
      board.Grid[newPosition.X, newPosition.Y] = piece;
      piece.Position = newPosition;
    }

    public static bool CheckMovementValidity(Piece piece, Coordinate position) {
      if (position.X > 7 || position.Y > 7 || position.X < 0 || position.Y < 0) {
        return false;
      }
      return true;
    }
  }
}