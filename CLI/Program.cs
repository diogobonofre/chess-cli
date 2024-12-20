using CLI.Pieces;

namespace CLI {
  internal static class Program {
    public static void Main() {
      Rook rook1 = new Rook(new Coordinate(1, 1), Color.White);
      Knight knight1 = new Knight(new Coordinate(2, 1), Color.White);
      Bishop bishop1 = new Bishop(new Coordinate(3, 1), Color.White);
      King king = new King(new Coordinate(4, 1), Color.White);
      Queen queen = new Queen(new Coordinate(5, 1), Color.White);
      Bishop bishop2 = new Bishop(new Coordinate(6, 1), Color.White);
      Knight knight2 = new Knight(new Coordinate(7, 1), Color.White);
      Rook rook2 = new Rook(new Coordinate(8, 1), Color.White);
      List<Piece> pieces = [rook1, rook2, knight1, knight2, bishop1, bishop2, king, queen];
      for (int i = 0; i < 8; i++) {
        pieces.Add(new Pawn(new Coordinate(i + 1, 2), Color.White));
      }

      Player player = new Player(Color.White, "Diogo", pieces);
      Console.WriteLine(player.Name);
      Console.WriteLine(player.Color);
      foreach (Piece piece in player.Pieces) {
        Console.WriteLine($"{piece.Sprite} ({piece.Position.X}, {piece.Position.Y})");
      }
    }
  }
}
