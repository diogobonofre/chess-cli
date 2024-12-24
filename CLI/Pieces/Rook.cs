
namespace CLI.Pieces {
  internal class Rook : Piece {
    public Rook(Coordinate position, Color color) : base(position, color) {
      Sprite = '♜';
    }

    public override List<Coordinate> GetPossibleMoves(Board board) {
      var possibleMoves = new List<Coordinate>();

      for (int i = 1; i < 8; i++) {
        if (IsWithinBounds(Position.X + i, Position.Y)) {
          possibleMoves.Add(new Coordinate(Position.X + i, Position.Y));
        }
        if (IsWithinBounds(Position.X - i, Position.Y)) {
          possibleMoves.Add(new Coordinate(Position.X - i, Position.Y));
        }
        if (IsWithinBounds(Position.X, Position.Y + i)) {
          possibleMoves.Add(new Coordinate(Position.X, Position.Y + i));
        }
        if (IsWithinBounds(Position.X, Position.Y - i)) {
          possibleMoves.Add(new Coordinate(Position.X, Position.Y - i));
        }
      }

      return possibleMoves;
    }
  }
}
