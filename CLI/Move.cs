namespace CLI {
  /// <summary>
  /// This class is responsible for managing and abstracting pieces movement 
  /// logic in the game board.
  /// </summary>
  public static class Move {
    /// <summary>
    /// Check movement validity and move a piece from one tile to another.
    /// </summary>
    /// <param name="board"></param>
    /// <param name="player"></param>
    /// <param name="piece"></param>
    /// <param name="newPosition"></param>
    public static void MovePieceTo(Board board, Player player, Piece piece, Coordinate newPosition) {
      if (piece.Color != player.Color) {
        Console.WriteLine("You can't move an enemy piece.");
        return;
      }

      if (!piece.GetPossibleMoves(board).Contains(newPosition)) {
        Console.WriteLine("The new position isn't reachable with any valid move.");
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