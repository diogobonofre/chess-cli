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
}