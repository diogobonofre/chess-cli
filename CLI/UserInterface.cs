namespace CLI;

internal static class UserInterface
{
    private static bool _showDebugInfo;

    /// <summary>
    ///     Receive a game controller and print its board to the command-line.
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

        var moveCaptureStatus = GameController.IsPossibleMoveOrCapture(controller, piece, coordinate);

        // TODO: Adapt to switch expression
        // TODO: Adapt color based on the original color of the tile (dark color to black tiles and light color for white)
        if (moveCaptureStatus == 1) Console.BackgroundColor = ConsoleColor.Green;
        if (moveCaptureStatus == 2) Console.BackgroundColor = ConsoleColor.Red;
        if (coordinate == piece.Position) Console.BackgroundColor = ConsoleColor.Blue;
    }

    /// <summary>
    ///     Receive a GameController and print the current state of captures of the game.
    /// </summary>
    /// <param name="controller"></param>
    private static void ShowStatistics(GameController controller)
    {
        Console.WriteLine($"{controller.WhitePlayer.Name} (White): ");
        foreach (var piece in controller.WhitePlayer.CapturedPieces) Console.Write(piece.Sprite);

        Console.WriteLine($"{controller.BlackPlayer.Name} (Black): ");
        foreach (var piece in controller.BlackPlayer.CapturedPieces) Console.Write(piece.Sprite);
    }

    public static void ShowMoves(GameController controller, Player player)
    {
        if (controller.Turn != player) controller.ChangeTurn();

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

            if (_showDebugInfo) ShowDebugInfo(controller, pieces[index]);

            ShowBoard(controller, pieces[index]);

            var key = Console.ReadKey();

            if (key.KeyChar == 'd') _showDebugInfo = !_showDebugInfo;

            // Maybe move keybindings responsibilities to main game loop?
            index = key.KeyChar switch
            {
                'n' => index < pieces.Count - 1 ? index + 1 : 0,
                'p' => index > 0 ? index - 1 : pieces.Count - 1,
                'x' => -1,
                _ => index
            };
        }
    }

    private static void ShowDebugInfo(GameController controller, Piece? piece = null)
    {
        ShowStatistics(controller);
        Console.WriteLine($"Current turn: {controller.Turn.Name}");

        if (piece == null) return;
        Console.WriteLine($"Piece sprite: {piece.Sprite}");
        Console.WriteLine($"Piece color: {piece.Color}");
        Console.WriteLine($"Piece index: {GameController.GetPieceIndex(controller, piece)}");
        Console.WriteLine($"Piece coordinate: {piece.Position.X}, {piece.Position.Y}");
        Console.Write("Piece possible moves coordinates: ");
        foreach (var move in piece.GetPossibleMoves(controller)) Console.Write($"{move} ");
        Console.WriteLine();
    }
}
