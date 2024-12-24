namespace CLI.Pieces {
  internal class Rook : Piece {
    public Rook(Coordinate position, Color color) : base(position, color) {
      Sprite = '♜';
    }

    public override List<Coordinate> GetPossibleMoves(Board board) {
      var possibleMoves = new List<Coordinate>();

      var top = false;
      var left = false;
      var right = false;
      var bottom = false;

      for (int i = 1; i < 8; i++) {
        if (!top && IsWithinBounds(Position.X + i, Position.Y)) {
          if (board.GetPieceAt(new Coordinate(Position.X + i, Position.Y)) != null) top = true;
          possibleMoves.Add(new Coordinate(Position.X + i, Position.Y));
        }
        if (!bottom && IsWithinBounds(Position.X - i, Position.Y)) {
          if (board.GetPieceAt(new Coordinate(Position.X - i, Position.Y)) != null) bottom = true;
          possibleMoves.Add(new Coordinate(Position.X - i, Position.Y));
        }
        if (!left && IsWithinBounds(Position.X, Position.Y + i)) {
          if (board.GetPieceAt(new Coordinate(Position.X, Position.Y + i)) != null) left = true;
          possibleMoves.Add(new Coordinate(Position.X, Position.Y + i));
        }
        if (!right && IsWithinBounds(Position.X, Position.Y - i)) {
          if (board.GetPieceAt(new Coordinate(Position.X, Position.Y - i)) != null) right = true;
          possibleMoves.Add(new Coordinate(Position.X, Position.Y - i));
        }
      }

      return possibleMoves;
    }
  }
}
