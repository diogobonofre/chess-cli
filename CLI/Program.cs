using CLI.Pieces;

namespace CLI {
  internal static class Program {
    public static void Main() {
      var board = new Board();

      List<Piece> pieces = [
        new Rook(new Coordinate(0, 0), Color.White),
        new Knight(new Coordinate(0, 1), Color.White),
        new Bishop(new Coordinate(0, 2), Color.White),
        new King(new Coordinate(0, 3), Color.White),
        new Queen(new Coordinate(0, 4), Color.White),
        new Bishop(new Coordinate(0, 5), Color.White),
        new Knight(new Coordinate(0, 6), Color.White),
        new Rook(new Coordinate(0, 7), Color.White),
        new Pawn(new Coordinate(1, 0), Color.White),
        new Pawn(new Coordinate(1, 1), Color.White),
        new Pawn(new Coordinate(1, 2), Color.White),
        new Pawn(new Coordinate(1, 3), Color.White),
        new Pawn(new Coordinate(1, 4), Color.White),
        new Pawn(new Coordinate(1, 5), Color.White),
        new Pawn(new Coordinate(1, 6), Color.White),
        new Pawn(new Coordinate(1, 7), Color.White),
      ];
      var player = new Player(Color.White, "Diogo", pieces);
      for (int i = 0; i < player.Pieces.Count; i++) {
        var piece = player.Pieces[i];
        board.SetPieceAt(piece.Position, piece);
      }

      List<Piece> pieces2 = [
        new Rook(new Coordinate(7, 0), Color.Black),
        new Knight(new Coordinate(7, 1), Color.Black),
        new Bishop(new Coordinate(7, 2), Color.Black),
        new King(new Coordinate(7, 3), Color.Black),
        new Queen(new Coordinate(7, 4), Color.Black),
        new Bishop(new Coordinate(7, 5), Color.Black),
        new Knight(new Coordinate(7, 6), Color.Black),
        new Rook(new Coordinate(7, 7), Color.Black),
        new Pawn(new Coordinate(6, 0), Color.Black),
        new Pawn(new Coordinate(6, 1), Color.Black),
        new Pawn(new Coordinate(6, 2), Color.Black),
        new Pawn(new Coordinate(6, 3), Color.Black),
        new Pawn(new Coordinate(6, 4), Color.Black),
        new Pawn(new Coordinate(6, 5), Color.Black),
        new Pawn(new Coordinate(6, 6), Color.Black),
        new Pawn(new Coordinate(6, 7), Color.Black),
      ];
      var player2 = new Player(Color.Black, "Bruno", pieces2);
      for (int i = 0; i < player2.Pieces.Count; i++) {
        var piece = player2.Pieces[i];
        board.SetPieceAt(piece.Position, piece);
      }

      Console.WriteLine($"Player 1: {player.Name} - Color: {player.Color}");
      Console.WriteLine($"Player 2: {player2.Name} - Color: {player2.Color}");
      Console.WriteLine("For better visualization whites are dark cyan and blacks are dark yellow");
      UI.ShowBoard(board);
    }
  }
}
