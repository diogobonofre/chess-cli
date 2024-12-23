namespace CLI {
  internal static class Program {
    public static void Main() {
      var board = new Board();

      var player = new Player(Color.White, "Diogo");
      var player2 = new Player(Color.Black, "Bruno");

      var gameController = new GameController(board: board, players: [player, player2]);

      gameController.GivePlayerPieces();

      board.PlacePlayerPieces(player);
      board.PlacePlayerPieces(player2);

      gameController.RefreshScreen();

      board.RemovePieceAt(new Coordinate(6, 0));
      gameController.RefreshScreen();

      var rook = board.GetPieceAt(new Coordinate(7, 0));
      if (rook == null) return;

      Move.MovePieceTo(board, player2, rook, new Coordinate(1, 0));
      gameController.RefreshScreen();
      Thread.Sleep(1000);

      Move.MovePieceTo(board, player2, rook, new Coordinate(1, 1));
      gameController.RefreshScreen();
      Thread.Sleep(1000);

      Move.MovePieceTo(board, player2, rook, new Coordinate(1, 2));
      gameController.RefreshScreen();
      Thread.Sleep(1000);

      Move.MovePieceTo(board, player2, rook, new Coordinate(1, 3));
      gameController.RefreshScreen();
      Thread.Sleep(1000);

      Move.MovePieceTo(board, player2, rook, new Coordinate(1, 4));
      gameController.RefreshScreen();
      Thread.Sleep(1000);

      Move.MovePieceTo(board, player2, rook, new Coordinate(1, 5));
      gameController.RefreshScreen();
      Thread.Sleep(1000);

      Move.MovePieceTo(board, player2, rook, new Coordinate(1, 6));
      gameController.RefreshScreen();
      Thread.Sleep(1000);

      Move.MovePieceTo(board, player2, rook, new Coordinate(1, 7));
      gameController.RefreshScreen();
      Thread.Sleep(1000);

      Move.MovePieceTo(board, player2, rook, new Coordinate(0, 7));
      gameController.RefreshScreen();
      Thread.Sleep(1000);

      Move.MovePieceTo(board, player2, rook, new Coordinate(0, 6));
      gameController.RefreshScreen();
      Thread.Sleep(1000);

      Move.MovePieceTo(board, player2, rook, new Coordinate(0, 5));
      gameController.RefreshScreen();
      Thread.Sleep(1000);

      Move.MovePieceTo(board, player2, rook, new Coordinate(0, 4));
      gameController.RefreshScreen();
      Thread.Sleep(1000);

      Move.MovePieceTo(board, player2, rook, new Coordinate(0, 3));
      gameController.RefreshScreen();
      Thread.Sleep(1000);

      Move.MovePieceTo(board, player2, rook, new Coordinate(0, 2));
      gameController.RefreshScreen();
      Thread.Sleep(1000);

      Move.MovePieceTo(board, player2, rook, new Coordinate(0, 1));
      gameController.RefreshScreen();
      Thread.Sleep(1000);

      Move.MovePieceTo(board, player2, rook, new Coordinate(0, 0));
      gameController.RefreshScreen();
      board.PlacePlayerPieces(player);
      Thread.Sleep(1000);
    }
  }
}