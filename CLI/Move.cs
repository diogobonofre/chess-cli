using CLI.Pieces;

namespace CLI;

/// <summary>
///     This class is responsible for managing and abstracting pieces movement
///     logic in the game board.
/// </summary>
public static class Move
{
    /// <summary>
    ///     Check movement validity and move a piece from one tile to another.
    /// </summary>
    /// <param name="controller"></param>
    /// <param name="piece"></param>
    /// <param name="newPosition"></param>
    public static void MovePieceTo(GameController controller, Piece piece, Coordinate newPosition)
    {
        var player = controller.Turn;

        if (player.Color != piece.Color)
        {
            Console.WriteLine("You can't move an enemy piece.");
            return;
        }

        if (!piece.GetPossibleMoves(controller).Contains(newPosition))
        {
            Console.WriteLine("The new position isn't reachable with any valid move.");
            return;
        }

        var pieceAtTile = controller.Board.GetPieceAt(newPosition);
        if (pieceAtTile != null)
        {
            var opponent = player.Color == Color.White ? controller.BlackPlayer : controller.WhitePlayer;
            controller.Board.RemovePieceAt(newPosition);
            opponent.Pieces.Remove(pieceAtTile);
            player.CapturedPieces.Add(pieceAtTile);
        }

        controller.Board.RemovePieceAt(piece.Position);
        controller.Board.Grid[newPosition.X, newPosition.Y] = piece;
        piece.Position = newPosition;

        // add logic to change to transform pawns into another piece when reaching opponent side
        if (piece is Pawn pawn) pawn.HasMoved = true;
        if (piece is Rook rook) rook.HasMoved = true;

        controller.ChangeTurn();
    }

    public static void Castle(GameController controller, Rook rook)
    {
        throw new NotImplementedException();
    }

    public static void EnPassant(GameController controller, Pawn pawn)
    {
        throw new NotImplementedException();
    }

    public static void PawnPromotion(GameController controller, Pawn pawn)
    {
        throw new NotImplementedException();
    }
}