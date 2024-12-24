using CLI.Pieces;

namespace CLI {
  internal static class Program {
    public static void Main() {
      var board = new Board();
      var player = new Player(Color.White, "Diogo");

      var rook = new Rook(new Coordinate(2, 6), Color.White);
      board.SetPieceAt(rook.Position, rook);

      var whiteBishop = new Bishop(new Coordinate(5, 7), Color.White);
      board.SetPieceAt(whiteBishop.Position, whiteBishop);

      var blackBishop = new Bishop(new Coordinate(5, 5), Color.Black);
      board.SetPieceAt(blackBishop.Position, blackBishop);

      var whitePawn = new Pawn(new Coordinate(2, 0), Color.White);
      board.SetPieceAt(whitePawn.Position, whitePawn);

      var blackPawn = new Pawn(new Coordinate(6, 6), Color.Black);
      board.SetPieceAt(blackPawn.Position, blackPawn);

      var queen = new Queen(new Coordinate(3, 4), Color.Black);
      board.SetPieceAt(queen.Position, queen);

      var blackKnight = new Knight(new Coordinate(7, 7), Color.Black);
      board.SetPieceAt(blackKnight.Position, blackKnight);

      var whiteKnight = new Knight(new Coordinate(4, 4), Color.White);
      board.SetPieceAt(whiteKnight.Position, whiteKnight);

      var whiteKing = new King(new Coordinate(3, 3), Color.White);
      board.SetPieceAt(whiteKing.Position, whiteKing);

      var blackKing = new King(new Coordinate(3, 6), Color.Black);
      board.SetPieceAt(blackKing.Position, blackKing);

      Console.Clear();

      UI.ShowBoard(board, whitePawn);
      Thread.Sleep(2000);
      Console.Clear();

      UI.ShowBoard(board, blackPawn);
      Thread.Sleep(2000);
      Console.Clear();

      UI.ShowBoard(board, rook);
      Thread.Sleep(2000);
      Console.Clear();

      UI.ShowBoard(board, whiteBishop);
      Thread.Sleep(2000);
      Console.Clear();

      UI.ShowBoard(board, blackBishop);
      Thread.Sleep(2000);
      Console.Clear();

      UI.ShowBoard(board, whiteKnight);
      Thread.Sleep(2000);
      Console.Clear();

      UI.ShowBoard(board, blackKnight);
      Thread.Sleep(2000);
      Console.Clear();

      UI.ShowBoard(board, queen);
      Thread.Sleep(2000);
      Console.Clear();

      UI.ShowBoard(board, whiteKing);
      Thread.Sleep(2000);
      Console.Clear();

      UI.ShowBoard(board, blackKing);
      Thread.Sleep(2000);
    }
  }
}