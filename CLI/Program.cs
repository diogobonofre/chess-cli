using CLI.Pieces;

namespace CLI {
  internal static class Program {
    public static void Main() {
      var whitePlayer = new Player(Color.White, "Diogo");
      var blackPlayer = new Player(Color.Black, "Pamela");

      var controller = new GameController(whitePlayer, blackPlayer);

      controller.SetupGame();

      var whitePawn = new Pawn(new Coordinate(4, 4), Color.White);
      controller.Board.SetPieceAt(whitePawn.Position, whitePawn);

      var blackRook = new Rook(new Coordinate(4, 0), Color.Black);
      controller.Board.SetPieceAt(blackRook.Position, blackRook);

      UI.ShowBoard(controller, whitePawn);
      UI.ShowBoard(controller, blackRook);
    }
  }
}