namespace CLI {
  internal static class UI {
    /// <summary>
    /// Receive a board and print it to the command-line.
    /// </summary>
    /// <param name="board"></param>
    public static void ShowBoard(Board board, Piece? piece = null) {
      for (int i = 7; i >= 0; i--) {
        Console.Write(i + 1);
        for (int j = 7; j >= 0; j--) {
          Console.BackgroundColor = i % 2 == 0 && j % 2 == 0 || i % 2 == 1 && j % 2 == 1
            ? ConsoleColor.White
            : ConsoleColor.Black;
          if (piece != null) IsPossibleMoveOrCapture(board, piece, new Coordinate(i, j));
          var tile = board.Grid[i, j];
          if (tile != null) {
            Console.ForegroundColor = tile.Color == Color.White
              ? ConsoleColor.DarkCyan
              : ConsoleColor.DarkYellow;
            Console.Write($" {tile.Sprite} ");
          }

          else if (i % 2 == 0 && j % 2 == 0 || i % 2 == 1 && j % 2 == 1) {
            Console.Write("   ");
          }
          else {
            Console.Write("   ");
          }
          Console.ResetColor();
        }
        Console.WriteLine();
      }
      Console.WriteLine("  A  B  C  D  E  F  G  H ");
    }

    /// <summary>
    /// Check if the current position at the given board is a possible move or capture for the given piece.
    /// </summary>
    /// <param name="board"></param>
    /// <param name="piece"></param>
    /// <param name="position"></param>
    private static void IsPossibleMoveOrCapture(Board board, Piece piece, Coordinate position) {
      if (piece.GetPossibleMoves(board).Contains(position)) {
        Console.BackgroundColor = Console.BackgroundColor == ConsoleColor.White
        ? ConsoleColor.Green
        : ConsoleColor.DarkGreen;
        var pieceAtPosition = board.GetPieceAt(position);
        if (pieceAtPosition != null && pieceAtPosition != piece && pieceAtPosition.Color != piece.Color) {
          Console.BackgroundColor = Console.BackgroundColor == ConsoleColor.White
          ? ConsoleColor.Red
          : ConsoleColor.DarkRed;
        }
      }
    }

    /// <summary>
    /// Receive a player and print it current status to the command-line.
    /// </summary>
    /// <param name="player"></param>
    public static void PlayersStatus(List<Player> players) {
      foreach (var player in players) {
        Console.Write($"{player.Name} ({player.Color}): ");
        foreach (var piece in player.CapturedPieces) {
          if (player.Color == Color.White) {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
          }
          else {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
          }
          Console.Write($"{piece.Sprite} ");
        }
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine();
      }
    }
  }
}
