namespace CLI {
  /// <summary>
  /// This class is responsible for managing and abstracting pieces movement 
  /// logic in the game board.
  /// </summary>
  public static class Move {
    public static void MovePieceTo(Board board, Player player, Piece piece, Coordinate newPosition) {
      if (piece.Color != player.Color) {
        Console.WriteLine("You can't move an enemy piece.");
        return;
      }
      var pieceAtTile = board.GetPieceAt(newPosition);
      if (pieceAtTile != null) {
        Console.WriteLine($"Killed {pieceAtTile.Sprite}");
        player.CapturedPieces.Add(pieceAtTile);
        board.RemovePieceAt(newPosition);
      }
      board.RemovePieceAt(piece.Position);
      board.Grid[newPosition.X, newPosition.Y] = piece;
      piece.Position = newPosition;
    }
  }
}