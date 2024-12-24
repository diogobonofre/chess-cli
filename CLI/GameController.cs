using CLI.Pieces;

namespace CLI {
  public class GameController {
    public List<Player> Players { get; private set; } = [];
    public Color Turn { get; set; } = Color.White;
    public Board Board { get; set; } = new Board();

    public GameController() { }

    public GameController(Board board, List<Player> players) {
      Board = board;
      Players = players;
    }

    public void GivePlayerPieces() {
      foreach (var p in Players) {
        if (p.Color == Color.White) {
          p.Pieces = [
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
            new Pawn(new Coordinate(1, 7), Color.White)
          ];
        }
        else {
          p.Pieces = [
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
        }
      }
    }
  }
}
