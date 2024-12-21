namespace CLI {
  static internal class UI {
    /// <summary>
    /// Receive a board and print it to the command-line.
    /// </summary>
    /// <param name="board"></param>
    public static void ShowBoard(Board board) {
      for (int i = 7; i >= 0; i--) {
        Console.Write(i + 1);
        for (int j = 7; j >= 0; j--) {
          if (i % 2 == 0 && j % 2 == 0 || i % 2 == 1 && j % 2 == 1) {
            Console.BackgroundColor = ConsoleColor.White;
          } else {
            Console.BackgroundColor = ConsoleColor.Black;
          }
          var tile = board.Grid[i, j];
          if (tile != null) {
            if (tile.Color == Color.White) {
              Console.ForegroundColor = ConsoleColor.DarkCyan;
            } else {
              Console.ForegroundColor = ConsoleColor.DarkYellow;
            }
            Console.Write($" {tile.Sprite} ");
          } else if (i % 2 == 0 && j % 2 == 0 || i % 2 == 1 && j % 2 == 1) {
            Console.Write("   ");
          } else {
            Console.Write("   ");
          }
          Console.ForegroundColor = ConsoleColor.White;
          Console.BackgroundColor = ConsoleColor.Black;
        }
        Console.WriteLine();
      }
      Console.WriteLine("  A  B  C  D  E  F  G  H ");
    }
  }
}
