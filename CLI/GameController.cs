using CLI.Pieces;

namespace CLI {
  public class GameController {
    private Player _whitePlayer { get; set; }
    private Player _blackPlayer { get; set; }
    public Board Board { get; private set; } = new Board();
    private Color _turn { get; set; } = Color.White;

    public GameController(Player whitePlayer, Player blackPlayer) {
      _whitePlayer = whitePlayer;
      _blackPlayer = blackPlayer;
    }

    /// <summary>
    /// 
    /// </summary>
    public void SetupGame() {
      AssignPieces(_whitePlayer);
      AssignPieces(_blackPlayer);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="player"></param>
    private void AssignPieces(Player player) {
      int pawnRow = player.Color == Color.White ? 1 : 6;
      int backRow = player.Color == Color.White ? 0 : 7;
      Piece piece;

      // Pawns
      for (int i = 0; i < 8; i++) {
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
}
