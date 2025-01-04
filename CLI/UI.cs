namespace CLI {
  internal static class UI {
    /// <summary>
    /// Receive a game controller and print it's board to the command-line.
    /// </summary>
    /// <param name="controller"></param>
    /// <param name="piece"></param>
    public static void ShowBoard(GameController controller, Piece? piece = null) {
      for (int x = 0; x < 8; x++) {
        Console.Write(1 + x);
        for (int y = 0; y < 8; y++) {
          var coordinate = new Coordinate(x, y);
          SetTileColor(controller, piece, coordinate);
          PrintTile(controller, coordinate);
        }
        Console.WriteLine();
      }
      for (int i = 0; i < 8; i++) Console.Write(string.Format("  {0}", (char)('A' + i)));
      Console.WriteLine();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="controller"></param>
    /// <param name="coordinate"></param>
    private static void PrintTile(GameController controller, Coordinate coordinate) {
      var piece = controller.Board.GetPieceAt(coordinate);

      if (piece != null) {
        Console.ForegroundColor = piece.Color == Color.White ? ConsoleColor.Cyan : ConsoleColor.Magenta;
        Console.Write($" {piece.Sprite} ");
      } else {
        Console.Write("   ");
      }

      Console.ResetColor();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="controller"></param>
    /// <param name="piece"></param>
    /// <param name="coordinate"></param>
    private static void SetTileColor(GameController controller, Piece? piece, Coordinate coordinate) {
      Console.BackgroundColor = (coordinate.X % 2 == 0 && coordinate.Y % 2 == 0) || (coordinate.X % 2 == 1 && coordinate.Y % 2 == 1)
        ? ConsoleColor.White
        : ConsoleColor.Black;

      if (piece != null) {
        int moveCaptureStatus = IsPossibleMoveOrCapture(controller, piece, coordinate);
        if (moveCaptureStatus == 1) Console.BackgroundColor = ConsoleColor.Green;
        if (moveCaptureStatus == 2) Console.BackgroundColor = ConsoleColor.Red;
        if (coordinate == piece.Position) Console.BackgroundColor = ConsoleColor.Blue;
      }
    }

    /// <summary>
    /// Check if the current position at the given board is a possible move or capture for the given piece.
    /// </summary>
    /// <returns>
    /// 1: Coordinate is a possible move
    /// 2: Coordinate is a possible capture
    /// 0: Coordinate is not a possible move or capture
    /// </returns>
    private static int IsPossibleMoveOrCapture(GameController controller, Piece? piece, Coordinate coordinate) {
      if (piece == null) throw new ArgumentNullException(nameof(piece), message: "piece can't be null.");

      var coordinatePiece = controller.Board.GetPieceAt(coordinate);
      var possibleMoves = piece.GetPossibleMoves(controller.Board);

      bool isCoordinatePossibleMove = possibleMoves.Any(c => c == coordinate);

      if (isCoordinatePossibleMove && coordinatePiece == null) return 1;
      if (isCoordinatePossibleMove && coordinatePiece != null && piece.Color != coordinatePiece.Color) return 2;
      return 0;
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
          } else {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
          }
          Console.Write($"{piece.Sprite} ");
        }
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine();
      }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="controller"></param>
    /// <param name="player"></param>
    public static void ShowMoves(GameController controller, Player player) {
      if (player.Pieces.Count <= 0) {
        Console.WriteLine("The current player does not have any pieces");
        return;
      }

      var pieces = player.Pieces;
      var index = 0;

      while (true) {
        Console.Clear();
        ShowBoard(controller, pieces[index]);

        var key = Console.ReadKey();

        if (key.KeyChar == 'n') index = index < pieces.Count - 1 ? index + 1 : 0;
        if (key.KeyChar == 'p') index = index > 0 ? index - 1 : pieces.Count - 1;
        if (key.KeyChar == 'x') break;
      }
    }
  }
}