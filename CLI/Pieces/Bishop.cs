namespace CLI.Pieces {
  internal class Bishop : Piece {
    public Bishop(Coordinate position, Color color) : base(position, color) {
      Sprite = '♝';
    }

    public override List<Coordinate> GetPossibleMoves(Board board) {
      var possibleMoves = new List<Coordinate>();

      for (int i = 1; i < 8; i++) {
        if (IsWithinBounds(Position.X + i, Position.Y + i)) {
          possibleMoves.Add(new Coordinate(Position.X + i, Position.Y + i));
        }
        if (IsWithinBounds(Position.X + i, Position.Y - i)) {
          possibleMoves.Add(new Coordinate(Position.X + i, Position.Y - i));
        }
        if (IsWithinBounds(Position.X - i, Position.Y + i)) {
          possibleMoves.Add(new Coordinate(Position.X - i, Position.Y + i));
        }
        if (IsWithinBounds(Position.X - i, Position.Y - i)) {
          possibleMoves.Add(new Coordinate(Position.X - i, Position.Y - i));
        }
      }

      return possibleMoves;
    }
  }
}