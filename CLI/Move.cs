namespace CLI {
  public static class Move {
    public static void MovePieceTo(Board board, Player player, Piece piece, Coordinate newPosition) {
      if (piece.Color != player.Color) {
        Console.WriteLine("You can't move an enemy piece.");
        return;
      }
      CheckMovementValidity(piece, newPosition);
      var possiblePiece = board.GetPieceAt(newPosition);
      if (possiblePiece != null) {
        Console.WriteLine($"Killed {possiblePiece.Sprite}");
        player.CapturedPieces.Add(possiblePiece);
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