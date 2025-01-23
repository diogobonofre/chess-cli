namespace CLI;

internal static class UserInterface
{
    /// <summary>
    /// Receive a game controller and print its board to the command-line.
    /// </summary>
    /// <param name="controller"></param>
    /// <param name="piece"></param>
    public static void ShowBoard(GameController controller, Piece? piece = null)
    {
        for (var x = 0; x < 8; x++)
        {
            Console.Write(1 + x);
            for (var y = 0; y < 8; y++)
            {
                var coordinate = new Coordinate(x, y);
                SetTileColor(controller, piece, coordinate);
                PrintTile(controller, coordinate);
            }

            Console.WriteLine();
        }

        for (var i = 0; i < 8; i++) Console.Write($"  {(char)('A' + i)}");
        Console.WriteLine();
    }

    private static void PrintTile(GameController controller, Coordinate coordinate)
    {
        var piece = controller.Board.GetPieceAt(coordinate);

        if (piece != null)
        {
            Console.ForegroundColor = piece.Color == Color.White ? ConsoleColor.Cyan : ConsoleColor.Magenta;
            Console.Write($" {piece.Sprite} ");
        }
        else
        {
            Console.Write("   ");
        }

        Console.ResetColor();
    }

    private static void SetTileColor(GameController controller, Piece? piece, Coordinate coordinate)
    {
        Console.BackgroundColor = (coordinate.X % 2 == 0 && coordinate.Y % 2 == 0) ||
                                  (coordinate.X % 2 == 1 && coordinate.Y % 2 == 1)
            ? ConsoleColor.White
            : ConsoleColor.Black;

        if (piece == null) return;
        
        var moveCaptureStatus = IsPossibleMoveOrCapture(controller, piece, coordinate);
        
        // TODO: Adapt to switch expression
        if (moveCaptureStatus == 1) Console.BackgroundColor = ConsoleColor.Green;
        if (moveCaptureStatus == 2) Console.BackgroundColor = ConsoleColor.Red;
        if (coordinate == piece.Position) Console.BackgroundColor = ConsoleColor.Blue;
    }

    /// <summary>
    /// Check if the current position at the given board is a possible move or capture for the given piece.
    /// </summary>
    /// <returns>
    /// 1: Coordinate is a possible move
    /// 2: Coordinate is a possible capture
    /// 0: Coordinate is not a possible move or capture
    /// </returns>
    private static int IsPossibleMoveOrCapture(GameController controller, Piece? piece, Coordinate coordinate)
    {
        if (piece == null) throw new ArgumentNullException(nameof(piece), message: "piece can't be null.");

        var coordinatePiece = controller.Board.GetPieceAt(coordinate);
        var possibleMoves = piece.GetPossibleMoves(controller);

        var isCoordinatePossibleMove = possibleMoves.Any(c => c == coordinate);

        return isCoordinatePossibleMove switch
        {
            true when coordinatePiece == null => 1,
            true when piece.Color != coordinatePiece.Color => 2,
            _ => 0
        };
    }

    /// <summary>
    /// Receive a GameController and print the current state of captures of the game.
    /// </summary>
    /// <param name="controller"></param>
    public static void ShowCaptures(GameController controller)
    {
    }

    public static void ShowMoves(GameController controller, Player player)
    {
        if (player.Pieces.Count <= 0)
        {
            Console.WriteLine("The current player does not have any pieces");
            return;
        }

        var pieces = player.Pieces;
        var index = 0;

        while (index != -1)
        {
            Console.Clear();
            ShowBoard(controller, pieces[index]);

            var key = Console.ReadKey();

            index = key.KeyChar switch
            {
                'n' => index < pieces.Count - 1 ? index + 1 : 0,
                'p' => index > 0 ? index - 1 : pieces.Count - 1,
                'x' => -1,
                _ => index
            };
        }
    }
}