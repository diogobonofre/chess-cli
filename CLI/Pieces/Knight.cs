namespace CLI.Pieces {
  internal class Knight : Piece {
    public Knight(Coordinate position, Color color) : base(position, color) {
      Sprite = '♞';
    }

    public override List<Coordinate> GetPossibleMoves(Board board) {
      var possibleMoves = new List<Coordinate>();

      if (IsWithinBounds(Position.X + 2, Position.Y + 1)) {
        possibleMoves.Add(new Coordinate(Position.X + 2, Position.Y + 1));
      }
      if (IsWithinBounds(Position.X + 2, Position.Y - 1)) {
        possibleMoves.Add(new Coordinate(Position.X + 2, Position.Y - 1));
      }
      if (IsWithinBounds(Position.X - 2, Position.Y + 1)) {
        possibleMoves.Add(new Coordinate(Position.X - 2, Position.Y + 1));
      }
      if (IsWithinBounds(Position.X - 2, Position.Y - 1)) {
        possibleMoves.Add(new Coordinate(Position.X - 2, Position.Y - 1));
      }
      if (IsWithinBounds(Position.X + 1, Position.Y + 2)) {
        possibleMoves.Add(new Coordinate(Position.X + 1, Position.Y + 2));
      }
      if (IsWithinBounds(Position.X - 1, Position.Y + 2)) {
        possibleMoves.Add(new Coordinate(Position.X - 1, Position.Y + 2));
      }
      if (IsWithinBounds(Position.X + 1, Position.Y - 2)) {
        possibleMoves.Add(new Coordinate(Position.X + 1, Position.Y - 2));
      }
      if (IsWithinBounds(Position.X - 1, Position.Y - 2)) {
        possibleMoves.Add(new Coordinate(Position.X - 1, Position.Y - 2));
      }

      return possibleMoves;
    }
  }
}
