using CLI.Pieces;

namespace CLI;

public class GameController(Player whitePlayer, Player blackPlayer)
{
    public Player WhitePlayer { get; set; } = whitePlayer;
    public Player BlackPlayer { get; set; } = blackPlayer;
    public Board Board { get; private set; } = new();
    public Player Turn { get; private set; } = whitePlayer;

    /// <summary>
    /// Give and position black and white player initial pieces.
    /// </summary>
    public void SetupGame()
    {
        AssignPieces(WhitePlayer);
        AssignPieces(BlackPlayer);
    }

    /// <summary>
    /// Alternate turn between players.
    /// </summary>
    public void ChangeTurn()
    {
        Turn = Turn.Color == Color.White ? BlackPlayer : WhitePlayer;
    }
    
    private void AssignPieces(Player player)
    {
        var pawnRow = player.Color == Color.White ? 1 : 6;
        var backRow = player.Color == Color.White ? 0 : 7;
        Piece piece;

        // Pawns
        for (var i = 0; i < 8; i++)
        {
            piece = new Pawn(new Coordinate(pawnRow, i), player.Color);
            Board.SetPieceAt(piece.Position, piece);
            player.Pieces.Add(piece);
        }

        // Rooks
        piece = new Rook(new Coordinate(backRow, 0), player.Color);
        Board.SetPieceAt(piece.Position, piece);
        player.Pieces.Add(piece);

        piece = new Rook(new Coordinate(backRow, 7), player.Color);
        Board.SetPieceAt(piece.Position, piece);
        player.Pieces.Add(piece);

        // Knights
        piece = new Knight(new Coordinate(backRow, 1), player.Color);
        Board.SetPieceAt(piece.Position, piece);
        player.Pieces.Add(piece);

        piece = new Knight(new Coordinate(backRow, 6), player.Color);
        Board.SetPieceAt(piece.Position, piece);
        player.Pieces.Add(piece);

        // Bishops
        piece = new Bishop(new Coordinate(backRow, 2), player.Color);
        Board.SetPieceAt(piece.Position, piece);
        player.Pieces.Add(piece);

        piece = new Bishop(new Coordinate(backRow, 5), player.Color);
        Board.SetPieceAt(piece.Position, piece);
        player.Pieces.Add(piece);

        // Queen
        piece = new Queen(new Coordinate(backRow, 3), player.Color);
        Board.SetPieceAt(piece.Position, piece);
        player.Pieces.Add(piece);

        // King
        piece = new King(new Coordinate(backRow, 4), player.Color);
        Board.SetPieceAt(piece.Position, piece);
        player.Pieces.Add(piece);
    }

    /// <summary>
    /// Check if the current position at the given board is a possible move or capture for the given piece.
    /// </summary>
    /// <returns>
    /// 1: Coordinate is a possible move
    /// 2: Coordinate is a possible capture
    /// 0: Coordinate is not a possible move or capture
    /// </returns>
    public static int IsPossibleMoveOrCapture(GameController controller, Piece? piece, Coordinate coordinate)
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
    /// Check if a given piece exists in the given player pieces list and return its index.
    /// </summary>
    /// <param name="controller"></param>
    /// <param name="piece"></param>
    /// <returns>
    /// If the pieces exist, return its index (non-negative number).
    /// Else, return -1 telling that the piece can't be found in the current list.Get
    /// </returns>
    /// <exception cref="ArgumentOutOfRangeException"></exception>
    public static int GetPieceIndex(GameController controller, Piece piece)
    {
        var player = piece.Color switch
        {
            Color.White => controller.WhitePlayer,
            Color.Black => controller.BlackPlayer,
            _ => throw new ArgumentOutOfRangeException(piece.Color.ToString())
        };

        for (var i = 0; i < player.Pieces.Count; i++)
        {
            if (ReferenceEquals(piece, controller.WhitePlayer.Pieces[i])) return i;
        }

        return -1;
    }
}